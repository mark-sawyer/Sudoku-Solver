
public static class EmptySpaceExists {
    public static bool emptySpaceExists() {
        Digit digit;
        for (int row = 1; row <= 9; row++) {
            for (int col = 1; col <= 9; col++) {
                digit = SpaceGetter.getSpace(row, col).digit;
                if (digit == Digit.NONE) return true;                
            }
        }

        return false;
    }
}
