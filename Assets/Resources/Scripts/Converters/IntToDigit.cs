
public static class IntToDigit {
    public static Digit intToDigit(int i) {
        Digit digit = Digit.NONE;
        switch (i) {
            case 1:
                digit = Digit.ONE;
                break;
            case 2:
                digit = Digit.TWO;
                break;
            case 3:
                digit = Digit.THREE;
                break;
            case 4:
                digit = Digit.FOUR;
                break;
            case 5:
                digit = Digit.FIVE;
                break;
            case 6:
                digit = Digit.SIX;
                break;
            case 7:
                digit = Digit.SEVEN;
                break;
            case 8:
                digit = Digit.EIGHT;
                break;
            case 9:
                digit = Digit.NINE;
                break;
        }
        return digit;
    }
}
