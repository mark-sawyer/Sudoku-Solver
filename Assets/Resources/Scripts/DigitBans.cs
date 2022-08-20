using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitBans {
    private List<List<Space>> digitBanList;

    public DigitBans() {
        int totalDigits = 9;
        digitBanList = new List<List<Space>>(totalDigits);
        for (int i = 0; i < totalDigits; i++) {
            digitBanList.Add(new List<Space>());
        }
    }

    public bool digitIsBanned(Digit digit) {
        int digitInt = DigitToInt.digitToInt(digit);
        int index = digitInt - 1;
        int length = digitBanList[index].Count;
        return length != 0;
    }

    public void removeOldBan(Digit oldDigit, Space spaceThatChanged) {
        if (oldDigit == Digit.NONE) return;
        int digitInt = DigitToInt.digitToInt(oldDigit);
        int index = digitInt - 1;
        digitBanList[index].Remove(spaceThatChanged);
    }

    public void addNewBan(Digit newDigit, Space spaceThatChanged) {
        if (newDigit == Digit.NONE) return;
        int digitInt = DigitToInt.digitToInt(newDigit);
        int index = digitInt - 1;
        if (!digitBanList[index].Contains(spaceThatChanged)) {
            digitBanList[index].Add(spaceThatChanged);
        }        
    }
}
