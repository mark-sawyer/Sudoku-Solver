using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DigitToInt {
    public static int digitToInt(Digit digit) {
        int i = 0;
        switch (digit) {
            case Digit.ONE:
                i = 1;
                break;
            case Digit.TWO:
                i = 2;
                break;
            case Digit.THREE:
                i = 3;
                break;
            case Digit.FOUR:
                i = 4;
                break;
            case Digit.FIVE:
                i = 5;
                break;
            case Digit.SIX:
                i = 6;
                break;
            case Digit.SEVEN:
                i = 7;
                break;
            case Digit.EIGHT:
                i = 8;
                break;
            case Digit.NINE:
                i = 9;
                break;
        }
        return i;
    }
}
