using UnityEngine;

public abstract class DisableableButton : MonoBehaviour {
    private Vector3 defaultPosition;

    private void Start() {
        defaultPosition = transform.position;
        GameEvents.solveClicked.AddListener(disableButton);
        GameEvents.solveOver.AddListener(enableButton);
    }

    private void disableButton() {
        transform.position = new Vector3(1000, 1000);
    }

    private void enableButton() {
        transform.position = defaultPosition;
    }
}
