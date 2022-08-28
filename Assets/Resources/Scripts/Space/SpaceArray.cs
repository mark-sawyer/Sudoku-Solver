using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpaceArray {
    public static Space[] spaceArray { get; private set; }

    static SpaceArray() {
        spaceArray = new Space[81];
        int index = 0;
        for (int row = 1; row <= 9; row++) {
            for (int col = 1; col <= 9; col++) {
                spaceArray[index] = SpaceGetter.getSpace(row, col);
                index++;
            }
        }
    }
}
