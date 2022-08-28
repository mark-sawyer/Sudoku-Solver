
public static class SolveButtonChecker {
    public static void checkForConflict() {
        bool conflictExists = false;

        foreach (Space space in SpaceArray.spaceArray) {
            conflictExists = space.digitBans.inConflict();
            if (conflictExists) break;
        }

        SolveButtonToggle.toggleSolveButton(conflictExists);
    }
}
