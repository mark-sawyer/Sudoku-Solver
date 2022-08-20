
public static class DigitChanger {
    public static void initialiseDigitChanger() {
        GameEvents.digitPressed.AddListener(changeDigit);
        GameEvents.backSpacePressed.AddListener(removeDigit);
    }

    private static void changeDigit(Digit newDigit) {
        Space space = SelectedSpace.space;
        if (space != null) space.enterDigit(newDigit);
    }

    private static void removeDigit() {
        Space space = SelectedSpace.space;
        if (space != null) space.removeDigit();       
    }
}
