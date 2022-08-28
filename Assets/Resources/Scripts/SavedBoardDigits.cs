
public class SavedBoardDigits {
    public Digit[] boardDigits;

    public SavedBoardDigits() {
        boardDigits = new Digit[81];
        int index = 0;
        Digit digit;
        for (int row = 1; row <= 9; row++) {
            for (int col = 1; col <= 9; col++) {
                digit = SpaceGetter.getSpace(row, col).digit;
                boardDigits[index] = digit;
                index++;
            }
        }
    }

    public void changeBoard() {
        int index = 0;
        Digit digit;
        Space space;
        for (int row = 1; row <= 9; row++) {
            for (int col = 1; col <= 9; col++) {
                digit = boardDigits[index];
                space = SpaceGetter.getSpace(row, col);
                DigitChanger.changeDigit(space, digit);
                index++;
            }
        }
    }
}
