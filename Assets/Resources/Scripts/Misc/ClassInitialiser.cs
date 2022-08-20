using UnityEngine;

public class ClassInitialiser : MonoBehaviour {
    void Awake() {
        SelectedSpace.initialiseSelectedSpace();
        DigitChanger.initialiseDigitChanger();
    }
}
