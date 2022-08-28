using UnityEngine;

public class Test : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Digit[] boardDigits = new Digit[81] {
                Digit.ONE,Digit.TWO,Digit.THREE,  Digit.FOUR,Digit.FIVE,Digit.SIX,   Digit.SEVEN,Digit.EIGHT,Digit.NINE,
                Digit.FOUR,Digit.FIVE,Digit.SIX,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,
                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,

                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,
                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,
                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,

                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,
                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE,
                Digit.NONE,Digit.NONE,Digit.NONE,  Digit.NONE,Digit.NONE,Digit.NONE,   Digit.NONE,Digit.NONE,Digit.NONE
            };
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
}
