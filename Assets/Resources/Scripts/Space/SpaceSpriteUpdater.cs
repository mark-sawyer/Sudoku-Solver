using UnityEngine;

public static class SpaceSpriteUpdater {
    private static bool updateSpaceConflictAlerts;

    public static void initialiseSpaceSpriteUpdater() {
        GameEvents.solveClicked.AddListener(turnOffSpaceConflictAlerts);
        GameEvents.solveOver.AddListener(turnOnSpaceConflictAlerts);
    }

    public static void updateSprite(Space space, Digit digit) {
        SpriteRenderer sr = space.GetComponent<SpriteRenderer>();
        if (digit == Digit.NONE) sr.enabled = false;
        else {
            sr.enabled = true;
            sr.sprite = DigitToSprite.digitToSprite(digit);
        }
    }

    public static void adjustConflictAlert(Space space, bool inConflict) {
        if (updateSpaceConflictAlerts) {
            space.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = inConflict;
        }
    }

    private static void turnOnSpaceConflictAlerts() {
        updateSpaceConflictAlerts = true;
    }

    private static void turnOffSpaceConflictAlerts() {
        updateSpaceConflictAlerts = false;
    }
}
