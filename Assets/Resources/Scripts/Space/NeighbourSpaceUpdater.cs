
public static class NeighbourSpaceUpdater {
    public static void updateNeighbours(Space space, Digit oldDigit, Digit newDigit) {
        GroupOfNine[] groupsOfNine = space.groupsOfNine;
        changeBans(groupsOfNine, space, oldDigit, newDigit);
        adjustConflictAlerts(groupsOfNine);
    }

    private static void changeBans(GroupOfNine[] groupsOfNine, Space space, Digit oldDigit, Digit newDigit) {
        DigitBans digitBans;
        foreach (GroupOfNine groupOfNine in groupsOfNine) {
            foreach (Space neighbourSpace in groupOfNine.spaces) {
                digitBans = neighbourSpace.digitBans;
                digitBans.removeOldBan(oldDigit, space);
                digitBans.addNewBan(newDigit, space);
            }
        }
    }

    private static void adjustConflictAlerts(GroupOfNine[] groupsOfNine) {
        DigitBans digitBans;
        bool inConflict;
        foreach (GroupOfNine groupOfNine in groupsOfNine) {
            foreach (Space neighbourSpace in groupOfNine.spaces) {
                digitBans = neighbourSpace.digitBans;
                inConflict = digitBans.inConflict();
                SpaceSpriteUpdater.adjustConflictAlert(neighbourSpace, inConflict);
            }
        }
    }
}
