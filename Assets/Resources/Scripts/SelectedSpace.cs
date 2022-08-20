using UnityEngine;

public static class SelectedSpace {
    public static Space space { get; private set; }

    public static void initialiseSelectedSpace() {
        GameEvents.nothingClicked.AddListener(unselectSpace);
    }

    public static void changeSelectedSpace(Space newSpace) {
        removeCurrentSpaceBorder();
        space = newSpace;
        space.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

    private static void unselectSpace() {
        removeCurrentSpaceBorder();
        space = null;
    }

    private static void removeCurrentSpaceBorder() {
        if (space != null) {
            space.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
