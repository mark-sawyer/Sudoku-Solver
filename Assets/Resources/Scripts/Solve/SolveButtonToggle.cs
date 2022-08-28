using UnityEngine;

public static class SolveButtonToggle {
    private static bool toggle;

    public static void initialiseSolveButtonToggle() {
        GameEvents.solveClicked.AddListener(toggleOff);
        GameEvents.solveOver.AddListener(toggleOn);
    }

    public static void toggleSolveButton(bool conflictExists) {
        if (toggle) {
            GameObject solve = GameObject.Find("solve");
            solve.GetComponent<BoxCollider2D>().enabled = !conflictExists;
            solve.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = conflictExists;
        }
    }

    private static void toggleOff() {
        toggle = false;
    }

    private static void toggleOn() {
        toggle = true;
    }
}
