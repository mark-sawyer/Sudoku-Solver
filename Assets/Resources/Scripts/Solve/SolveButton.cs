using System.Collections;
using System.Collections.Generic;

public class SolveButton : DisableableButton, IClickable {
    public static int level { get; private set; }
    private bool foundSpaceSolution;
    private bool foundGroupSolution;
    private List<StateNode> stateNodes = new List<StateNode>();
    private StateNode currentStateNode;
    private bool stopped;

    private void Awake() {
        GameEvents.stopClicked.AddListener(stopClicked);
    }

    public void clicked() {
        GameEvents.solveClicked.Invoke();
        StartCoroutine(solve());
    }

    public IEnumerator solve() {
        resetSolve();
        currentStateNode = new StateNode();
        findNecessaryDigits();
        if (EmptySpaceExists.emptySpaceExists() && !ImpossibleBoardChecker.boardImpossible()) {
            GameEvents.appearStop.Invoke();
            banPairsThatCreateImpossibleBoards();
            stateNodes.Add(currentStateNode);
            while (EmptySpaceExists.emptySpaceExists()) {
                yield return null;
                if (stopped || currentStateNode == null) break;
                tryNextState();
                findNecessaryDigits();
                banPairsThatCreateImpossibleBoards();
                updateCurrentStateNode();
            }
        }
        resetSolve();
        GameEvents.solveOver.Invoke();
    }

    private void updateCurrentStateNode() {
        if (currentStateNode == null) return;
        if (currentStateNode.triedEveryPair()) backTrackLevel();        
        else {
            level++;
            currentStateNode = new StateNode();
            stateNodes.Add(currentStateNode);
        }
    }

    private void tryNextState() {
        if (currentStateNode == null) return;
        if (!currentStateNode.triedEveryPair()) currentStateNode.tryNextPair();
        else {
            backTrackLevel();
            tryNextState();
        }
    }

    private void backTrackLevel() {
        stateNodes.Remove(currentStateNode);
        level--;
        undoNoSpaceBansOfLowerLevel();
        currentStateNode = stateNodes.Count > 0 ? stateNodes[stateNodes.Count - 1] : null;
    }

    private void findNecessaryDigits() {
        if (currentStateNode == null) return;
        do {
            findSpaceSolution();
            findGroupOfNineSolution();
        } while (foundSpaceSolution || foundGroupSolution);
    }

    private void findSpaceSolution() {
        foundSpaceSolution = false;
        foreach (Space space in SpaceArray.spaceArray) {
            if (space.digit == Digit.NONE) {
                Digit onlyPossibleDigit = space.digitBans.onlyPossibleDigit();
                if (onlyPossibleDigit != Digit.NONE) {
                    DigitChanger.changeDigit(space, onlyPossibleDigit);
                    foundSpaceSolution = true;
                    break;
                }
            }
        }
    }

    private void findGroupOfNineSolution() {
        foundGroupSolution = false;
        foreach (GroupOfNine groupOfNine in AllGroupsOfNine.allGroups) {
            SpaceDigitPair spaceDigitPair = groupOfNine.spaceNeedingDigit();
            if (spaceDigitPair.digit != Digit.NONE) {
                DigitChanger.changeDigit(spaceDigitPair.space, spaceDigitPair.digit);
                foundGroupSolution = true;
                break;
            }
        }
    }

    private void banPairsThatCreateImpossibleBoards() {
        if (currentStateNode == null) return;
        List<SpaceDigitPair> possiblePairs = PossibleSpaceDigitPairGetter.getPairs();
        SavedBoardDigits savedBoardDigits = new SavedBoardDigits();
        foreach (SpaceDigitPair pair in possiblePairs) {
            DigitChanger.changeDigit(pair.space, pair.digit);
            findNecessaryDigits();
            if (ImpossibleBoardChecker.boardImpossible()) pair.space.digitBans.addNoSpaceBan(pair.digit);
            savedBoardDigits.changeBoard();
        }
    }

    private void undoNoSpaceBansOfLowerLevel() {
        foreach (Space space in SpaceArray.spaceArray) {
            space.digitBans.removeNoSpaceBansOfLowerLevel();
        }
    }

    private void resetSolve() {
        stopped = false;
        level = 0;
        stateNodes.Clear();
        foreach (Space space in SpaceArray.spaceArray) {
            space.digitBans.clearNoSpaceBans();
        }
    }

    private void stopClicked() {
        stopped = true;
    }
}
