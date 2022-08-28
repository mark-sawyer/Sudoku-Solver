
public static class DigitChanger {
    public static void initialiseDigitChanger() {
        GameEvents.digitPressed.AddListener(changeSelectedDigit);
        GameEvents.backSpacePressed.AddListener(removeSelectedDigit);
    }

    private static void changeSelectedDigit(Digit newDigit) {
        Space space = SelectedSpace.space;
        if (space != null) changeDigit(space, newDigit);
    }

    public static void removeSelectedDigit() {
        Space space = SelectedSpace.space;
        if (space != null) changeDigit(space, Digit.NONE);
    }

    public static void changeDigit(Space space, Digit newDigit) {
        SpaceSpriteUpdater.updateSprite(space, newDigit);
        Digit oldDigit = space.digit;
        space.digit = newDigit;
        NeighbourSpaceUpdater.updateNeighbours(space, oldDigit, newDigit);
        SolveButtonChecker.checkForConflict();
    }
}
