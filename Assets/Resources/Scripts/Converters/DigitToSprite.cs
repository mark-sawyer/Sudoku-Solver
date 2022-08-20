using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DigitToSprite {
    private static Sprite digitOne = Resources.Load<Sprite>(Constants.spriteOnePath);
    private static Sprite digitTwo = Resources.Load<Sprite>(Constants.spriteTwoPath);
    private static Sprite digitThree = Resources.Load<Sprite>(Constants.spriteThreePath);
    private static Sprite digitFour = Resources.Load<Sprite>(Constants.spriteFourPath);
    private static Sprite digitFive = Resources.Load<Sprite>(Constants.spriteFivePath);
    private static Sprite digitSix = Resources.Load<Sprite>(Constants.spriteSixPath);
    private static Sprite digitSeven = Resources.Load<Sprite>(Constants.spriteSevenPath);
    private static Sprite digitEight = Resources.Load<Sprite>(Constants.spriteEightPath);
    private static Sprite digitNine = Resources.Load<Sprite>(Constants.spriteNinePath);

    public static Sprite digitToSprite(Digit digit) {
        Sprite spriteDigit = digitOne;

        switch (digit) {
            case Digit.ONE:
                spriteDigit = digitOne;
                break;
            case Digit.TWO:
                spriteDigit = digitTwo;
                break;
            case Digit.THREE:
                spriteDigit = digitThree;
                break;
            case Digit.FOUR:
                spriteDigit = digitFour;
                break;
            case Digit.FIVE:
                spriteDigit = digitFive;
                break;
            case Digit.SIX:
                spriteDigit = digitSix;
                break;
            case Digit.SEVEN:
                spriteDigit = digitSeven;
                break;
            case Digit.EIGHT:
                spriteDigit = digitEight;
                break;
            case Digit.NINE:
                spriteDigit = digitNine;
                break;
        }

        return spriteDigit;
    }
}
