using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImpossibleBoardChecker {
    public static bool boardImpossible() {
        Space space;
        for (int row = 1; row <= 9; row++) {
            for (int col = 1; col <= 9; col++) {
                space = SpaceGetter.getSpace(row, col);
                if (space.digit == Digit.NONE && space.digitBans.everythingIsBanned()) {
                    return true;
                }                
            }
        }

        return false;
    }
}
