using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PossibleSpaceDigitPairGetter {
    public static List<SpaceDigitPair> getPairs() {
        List<SpaceDigitPair> spaceDigitPairs = new List<SpaceDigitPair>();
        SpaceDigitPair possibleSpaceDigitPair;
        List<Digit> possibleDigits;
        foreach (Space space in SpaceArray.spaceArray) {
            if (space.digit == Digit.NONE) {
                possibleDigits = space.digitBans.getPossibleDigits();
                foreach (Digit possibleDigit in possibleDigits) {
                    possibleSpaceDigitPair = new SpaceDigitPair(space, possibleDigit);
                    spaceDigitPairs.Add(possibleSpaceDigitPair);
                }
            }
        }
        return spaceDigitPairs;
    }
}
