using System.Collections.Generic;
using UnityEngine;

public class DigitBans {
    private List<List<Space>> digitBanList;
    private List<NoSpaceBanLevel> noSpaceBanLevels;
    private Space space;

    public DigitBans(Space space) {
        this.space = space;
        int totalDigits = 9;
        digitBanList = new List<List<Space>>(totalDigits);
        for (int i = 0; i < totalDigits; i++) {
            digitBanList.Add(new List<Space>());
        }
        noSpaceBanLevels = new List<NoSpaceBanLevel>();
    }

    public void removeOldBan(Digit oldDigit, Space spaceThatChanged) {
        if (oldDigit == Digit.NONE || spaceThatChanged == space) return;
        int digitInt = DigitToInt.digitToInt(oldDigit);
        int index = digitInt - 1;
        digitBanList[index].Remove(spaceThatChanged);
    }

    public void addNewBan(Digit newDigit, Space spaceThatChanged) {
        if (newDigit == Digit.NONE || spaceThatChanged == space) return;
        int digitInt = DigitToInt.digitToInt(newDigit);
        int index = digitInt - 1;
        if (!digitBanList[index].Contains(spaceThatChanged)) {
            digitBanList[index].Add(spaceThatChanged);
        }
    }

    public void addNoSpaceBan(Digit newDigit) {
        int digitInt = DigitToInt.digitToInt(newDigit);
        int index = digitInt - 1;
        Space banSpace = GameObject.Find(Constants.banSpaceGameObjectName).GetComponent<Space>();
        digitBanList[index].Add(banSpace);
        int level = SolveButton.level;
        noSpaceBanLevels.Add(new NoSpaceBanLevel(newDigit, level));
    }

    public bool inConflict() {
        Digit digit = space.digit;
        if (digit == Digit.NONE) return false;
        else {
            int digitInt = DigitToInt.digitToInt(digit);
            int index = digitInt - 1;
            int length = digitBanList[index].Count;
            return length != 0;
        }
    }

    public bool digitIsBanned(Digit digit) {
        int i = DigitToInt.digitToInt(digit);
        int index = i - 1;
        return digitBanList[index].Count != 0;
    }

    public Digit onlyPossibleDigit() {
        int possibleDigits = 0;
        Digit digit = Digit.NONE;
        for (int i = 0; i < 9; i++) {
            if (digitBanList[i].Count == 0) {
                possibleDigits++;
                if (possibleDigits == 1) digit = IntToDigit.intToDigit(i + 1);
                else {
                    digit = Digit.NONE;
                    break;
                }
            }
        }
        return digit;
    }

    public bool everythingIsBanned() {
        bool everythingBanned = true;
        foreach (List<Space> spaceList in digitBanList) {
            if (spaceList.Count == 0) {
                everythingBanned = false;
                break;
            }
        }
        return everythingBanned;
    }

    public List<Digit> getPossibleDigits() {
        List<Digit> possibleDigits = new List<Digit>();
        for (int i = 0; i < 9; i++) {
            if (digitBanList[i].Count == 0) {
                possibleDigits.Add(IntToDigit.intToDigit(i + 1));
            }
        }
        return possibleDigits;
    }

    public void removeNoSpaceBansOfLowerLevel() {
        int level = SolveButton.level;
        List<NoSpaceBanLevel> noSpaceBanLevelsToRemove = new List<NoSpaceBanLevel>();
        foreach (NoSpaceBanLevel noSpaceBanLevel in noSpaceBanLevels) {
            if (noSpaceBanLevel.level > level) {
                Digit digit = noSpaceBanLevel.bannedDigit;
                int digitInt = DigitToInt.digitToInt(digit);
                int index = digitInt - 1;
                Space banSpace = GameObject.Find(Constants.banSpaceGameObjectName).GetComponent<Space>();
                digitBanList[index].Remove(banSpace);
                noSpaceBanLevelsToRemove.Add(noSpaceBanLevel);
            }
        }
        foreach (NoSpaceBanLevel noSpaceBanLevelToRemove in noSpaceBanLevelsToRemove) {
            noSpaceBanLevels.Remove(noSpaceBanLevelToRemove);
        }
    }

    public void clearNoSpaceBans() {
        Space banSpace = GameObject.Find(Constants.banSpaceGameObjectName).GetComponent<Space>();
        foreach (List<Space> spaceList in digitBanList) {
            spaceList.Remove(banSpace);
        }
        noSpaceBanLevels.Clear();
    }
}
