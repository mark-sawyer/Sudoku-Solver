using UnityEngine;

public class StopButton : MonoBehaviour, IClickable {
    private void Start() {
        GameEvents.appearStop.AddListener(turnOn);
        GameEvents.solveOver.AddListener(turnOff);
    }

    private void turnOn() {
        enable(true);
    }

    private void turnOff() {
        enable(false);
    }

    public void clicked() {
        enable(false);
        GameEvents.stopClicked.Invoke();
    }

    private void enable(bool b) {
        GetComponent<BoxCollider2D>().enabled = b;
        GetComponent<SpriteRenderer>().enabled = b;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = b;
    }
}
