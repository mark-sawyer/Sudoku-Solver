
public class ClearButton : DisableableButton, IClickable {
    public void clicked() {
        foreach (Space space in SpaceArray.spaceArray) {
            DigitChanger.changeDigit(space, Digit.NONE);
        }
    }
}
