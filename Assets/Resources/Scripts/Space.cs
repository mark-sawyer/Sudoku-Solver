using UnityEngine;

public class Space : MonoBehaviour, IClickable {
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Digit digit;
    private GroupOfNine rowGroup;
    private GroupOfNine colGroup;
    private GroupOfNine squareGroup;
    private DigitBans digitBans = new DigitBans();

    public void clicked() {
        SelectedSpace.changeSelectedSpace(this);
    }

    public void enterDigit(Digit newDigit) {
        sr.enabled = true;
        sr.sprite = DigitToSprite.digitToSprite(newDigit);
        updateOtherSpaceBans(digit, newDigit);
        digit = newDigit;
        updateOtherSpaceConflicts();
    }

    public void removeDigit() {
        sr.enabled = false;
        updateOtherSpaceBans(digit, Digit.NONE);
        digit = Digit.NONE;
        updateOtherSpaceConflicts();
    }

    public void assignGroupOfNine(GroupOfNine groupOfNine, GroupType groupType) {
        switch (groupType) {
            case GroupType.ROW:
                rowGroup = groupOfNine;
                break;
            case GroupType.COL:
                colGroup = groupOfNine;
                break;
            case GroupType.SQUARE:
                squareGroup = groupOfNine;
                break;
        }
    }

    public Digit getDigit() {
        return digit;
    }

    public void updateBans(Space changedSpace, Digit oldDigit, Digit newDigit) {
        if (changedSpace == this) return;
        digitBans.removeOldBan(oldDigit, changedSpace);
        digitBans.addNewBan(newDigit, changedSpace);
    }

    public void checkForConflict() {
        bool conflicted;
        if (digit == Digit.NONE) conflicted = false;
        else conflicted = digitBans.digitIsBanned(digit);
        turnConflictOnOrOff(conflicted);
    }

    private void turnConflictOnOrOff(bool b) {
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = b;
    }

    private void updateOtherSpaceBans(Digit oldDigit, Digit newDigit) {
        rowGroup.updateSpacesBans(this, oldDigit, newDigit);
        colGroup.updateSpacesBans(this, oldDigit, newDigit);
        squareGroup.updateSpacesBans(this, oldDigit, newDigit);
    }

    private void updateOtherSpaceConflicts() {
        rowGroup.updateSpacesConflicts();
        colGroup.updateSpacesConflicts();
        squareGroup.updateSpacesConflicts();
    }
}
