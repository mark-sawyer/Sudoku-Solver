using System.Linq;

public static class AllGroupsOfNine {
    private static GroupOfNine[] rowGroups;
    private static GroupOfNine[] colGroups;
    private static GroupOfNine[] squareGroups;
    public static GroupOfNine[] allGroups { get; private set; }

    public static void createGroupsOfNine() {
        createGroupsOfType(GroupType.ROW);
        createGroupsOfType(GroupType.COL);
        createGroupsOfType(GroupType.SQUARE);
        allGroups = rowGroups.Concat(colGroups).Concat(squareGroups).ToArray();
    }

    private static void createGroupsOfType(GroupType groupType) {
        GroupOfNine[] groupOfNineArray = new GroupOfNine[9];

        switch (groupType) {
            case GroupType.ROW:
                rowGroups = groupOfNineArray;
                break;
            case GroupType.COL:
                colGroups = groupOfNineArray;
                break;
            case GroupType.SQUARE:
                squareGroups = groupOfNineArray;
                break;
        }

        for (int i = 0; i < 9; i++) {
            groupOfNineArray[i] = new GroupOfNine(groupType, i + 1);
        }
    }
}
