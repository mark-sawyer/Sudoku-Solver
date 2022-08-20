using UnityEngine;

public class GroupOfNineHolder : MonoBehaviour {
    public GroupOfNine[] rowGroups { get; private set; }
    public GroupOfNine[] colGroups { get; private set; }
    public GroupOfNine[] squareGroups { get; private set; }

    private void Start() {
        rowGroups = new GroupOfNine[9];
        colGroups = new GroupOfNine[9];
        squareGroups = new GroupOfNine[9];

        createGroupsOfType(GroupType.ROW);
        createGroupsOfType(GroupType.COL);
        createGroupsOfType(GroupType.SQUARE);
    }

    private void createGroupsOfType(GroupType groupType) {
        for (int i = 0; i < 9; i++) {
            GroupOfNine groupOfNine = new GroupOfNine(groupType, i + 1);
            switch (groupType) {
                case GroupType.ROW:
                    rowGroups[i] = groupOfNine;
                    break;
                case GroupType.COL:
                    colGroups[i] = groupOfNine;
                    break;
                case GroupType.SQUARE:
                    squareGroups[i] = groupOfNine;
                    break;
            }
        }
    }
}
