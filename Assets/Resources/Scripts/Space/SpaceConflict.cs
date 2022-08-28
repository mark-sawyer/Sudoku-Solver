using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceConflict : MonoBehaviour {
    void Start() {
        GameEvents.solveClicked.AddListener(turnOffSprite);
        GameEvents.solveOver.AddListener(turnOnSprite);
    }

    private void turnOffSprite() {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void turnOnSprite() {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
