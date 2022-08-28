using UnityEngine;

public static class GameQuitter {
    public static void initialiseGameQuitter() {
        GameEvents.escapePressed.AddListener(quitGame);
    }

    private static void quitGame() {
        Application.Quit();
    }
}
