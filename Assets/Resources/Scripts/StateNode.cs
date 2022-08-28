using System.Collections.Generic;

public class StateNode {
    public SavedBoardDigits savedBoardDigits { get; private set; }
    public List<SpaceDigitPair> possibleSpaceDigitPairs { get; private set; }
    private int index;

    public StateNode() {
        savedBoardDigits = new SavedBoardDigits();
        possibleSpaceDigitPairs = PossibleSpaceDigitPairGetter.getPairs();
        index = 0;
    }

    public void tryNextPair() {
        savedBoardDigits.changeBoard();
        SpaceDigitPair spaceDigitPairToTry = possibleSpaceDigitPairs[index];
        DigitChanger.changeDigit(spaceDigitPairToTry.space, spaceDigitPairToTry.digit);
        index++;
    }

    public bool triedEveryPair() {
        return index == possibleSpaceDigitPairs.Count;
    }
}
