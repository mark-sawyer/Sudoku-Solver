using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfNine {
    Space[] spaces = new Space[9];

    public GroupOfNine(GroupType groupType, int num) {
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

    public void updateSpacesBans(Space changedSpace, Digit oldDigit, Digit newDigit) {
        foreach (Space space in spaces) {
            space.updateBans(changedSpace, oldDigit, newDigit);
        }
    }

    public void updateSpacesConflicts() {
        foreach (Space space in spaces) {
            space.checkForConflict();
        }
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
