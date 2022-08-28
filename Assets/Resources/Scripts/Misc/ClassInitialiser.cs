using UnityEngine;

public class ClassInitialiser : MonoBehaviour {
    void Start() {
        SelectedSpace.initialiseSelectedSpace();
        DigitChanger.initialiseDigitChanger();
        GameQuitter.initialiseGameQuitter();
        AllGroupsOfNine.createGroupsOfNine();
        SpaceSpriteUpdater.initialiseSpaceSpriteUpdater();
        SolveButtonToggle.initialiseSolveButtonToggle();
    }
}
