using UnityEngine;

public static class KeyCodeToDigit {
    public static Digit convertKeyCodeToDigit(KeyCode key) {
        Digit digit = Digit.ONE;

        switch (key) {
            case KeyCode.Alpha1:
                digit = Digit.ONE;
                break;
            case KeyCode.Keypad1:
                digit = Digit.ONE;
                break;
            case KeyCode.Alpha2:
                digit = Digit.TWO;
                break;
            case KeyCode.Keypad2:
                digit = Digit.TWO;
                break;
            case KeyCode.Alpha3:
                digit = Digit.THREE;
                break;
            case KeyCode.Keypad3:
                digit = Digit.THREE;
                break;
            case KeyCode.Alpha4:
                digit = Digit.FOUR;
                break;
            case KeyCode.Keypad4:
                digit = Digit.FOUR;
                break;
            case KeyCode.Alpha5:
                digit = Digit.FIVE;
                break;
            case KeyCode.Keypad5:
                digit = Digit.FIVE;
                break;
            case KeyCode.Alpha6:
                digit = Digit.SIX;
                break;
            case KeyCode.Keypad6:
                digit = Digit.SIX;
                break;
            case KeyCode.Alpha7:
                digit = Digit.SEVEN;
                break;
            case KeyCode.Keypad7:
                digit = Digit.SEVEN;
                break;
            case KeyCode.Alpha8:
                digit = Digit.EIGHT;
                break;
            case KeyCode.Keypad8:
                digit = Digit.EIGHT;
                break;
            case KeyCode.Alpha9:
                digit = Digit.NINE;
                break;
            case KeyCode.Keypad9:
                digit = Digit.NINE;
                break;
        }

        return digit;
    }
}
