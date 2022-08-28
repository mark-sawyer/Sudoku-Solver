using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfNine {
    public Space[] spaces { get; private set; }

    public GroupOfNine(GroupType groupType, int num) {
        spaces = new Space[9];

        switch (groupType) {
            case GroupType.ROW:
                getRowSpaces(num);
                break;
            case GroupType.COL:
                getColSpaces(num);
                break;
            case GroupType.SQUARE:
                getSquareSpaces(num);
                break;
        }
    }

    public SpaceDigitPair spaceNeedingDigit() {
        List<Digit> possibleDigits = new List<Digit> {
            Digit.ONE, Digit.TWO, Digit.THREE,
            Digit.FOUR, Digit.FIVE, Digit.SIX,
            Digit.SEVEN, Digit.EIGHT, Digit.NINE
        };
        List<Space> emptySpaces = new List<Space>();

        getEmptySpacesAndPossibleDigits(possibleDigits, emptySpaces);
        SpaceDigitPair spaceNeedingDigit = findSpaceNeedingDigit(possibleDigits, emptySpaces);
        return spaceNeedingDigit;
    }

    private void getEmptySpacesAndPossibleDigits(List<Digit> possibleDigits, List<Space> emptySpaces) {
        foreach (Space space in spaces) {
            if (space.digit != Digit.NONE) possibleDigits.Remove(space.digit);
            else emptySpaces.Add(space);
        }
    }

    private SpaceDigitPair findSpaceNeedingDigit(List<Digit> possibleDigits, List<Space> emptySpaces) {
        Space targetSpace = null;
        SpaceDigitPair spaceDigitPair = new SpaceDigitPair(null, Digit.NONE);

        foreach (Digit possibleDigit in possibleDigits) {
            targetSpace = getOnlySpaceAcceptingDigit(emptySpaces, possibleDigit);
            if (targetSpace != null) {
                spaceDigitPair = new SpaceDigitPair(targetSpace, possibleDigit);
                break;
            }
        }

        return spaceDigitPair;
    }

    private Space getOnlySpaceAcceptingDigit(List<Space> emptySpaces, Digit possibleDigit) {
        Space spaceDigitShouldGo = null;
        int spacesForDigit = 0;

        foreach (Space emptySpace in emptySpaces) {
            if (!emptySpace.digitBans.digitIsBanned(possibleDigit)) {
                spacesForDigit++;
                spaceDigitShouldGo = emptySpace;
            }
        }

        if (spacesForDigit == 1) return spaceDigitShouldGo;
        else return null;
    }

    private void getRowSpaces(int rowNum) {
        Space space;
        for (int i = 0; i < 9; i++) {
            space = SpaceGetter.getSpace(rowNum, i + 1);
            space.assignGroupOfNine(this, GroupType.ROW);
            spaces[i] = space;
        }
    }

    private void getColSpaces(int colNum) {
        Space space;
        for (int i = 0; i < 9; i++) {
            space = SpaceGetter.getSpace(i + 1, colNum);
            space.assignGroupOfNine(this, GroupType.COL);
            spaces[i] = space;
        }
    }

    private void getSquareSpaces(int squareNum) {
        Space space;
        int firstRowNum = getFirstSquareRow(squareNum);
        int firstColNum = getFirstSquareCol(squareNum);
        int index = 0;
        for (int row = firstRowNum; row < firstRowNum + 3; row++) {
            for (int col = firstColNum; col < firstColNum + 3; col++) {
                space = SpaceGetter.getSpace(row, col);
                space.assignGroupOfNine(this, GroupType.SQUARE);
                spaces[index] = space;
                index++;
            }
        }
    }

    private int getFirstSquareRow(int squareNum) {
        return ((squareNum - 1) / 3 * 3) + 1;
    }

    private int getFirstSquareCol(int squareNum) {
        return ((squareNum - 1) % 3 * 3) + 1;
    }
}
