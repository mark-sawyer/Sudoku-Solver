using UnityEngine;

public class Space : MonoBehaviour, IClickable {
    [SerializeField] public Digit digit { get; set; }
    public bool conflicted { get; private set; }
    public GroupOfNine[] groupsOfNine { get; private set; }
    public DigitBans digitBans { get; private set; }

    public void Awake() {
        groupsOfNine = new GroupOfNine[3];
        digitBans = new DigitBans(this);
        GameEvents.solveClicked.AddListener(turnOffCollider);
        GameEvents.solveOver.AddListener(turnOnCollider);
    }

    public void clicked() {
        SelectedSpace.changeSelectedSpace(this);
    }

    public void assignGroupOfNine(GroupOfNine groupOfNine, GroupType groupType) {
        switch (groupType) {
            case GroupType.ROW:
                groupsOfNine[0] = groupOfNine;
                break;
            case GroupType.COL:
                groupsOfNine[1] = groupOfNine;
                break;
            case GroupType.SQUARE:
                groupsOfNine[2] = groupOfNine;
                break;
        }
    }

    private void turnOffCollider() {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void turnOnCollider() {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
