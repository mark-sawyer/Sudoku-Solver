using UnityEngine;

public static class SpaceGetter {
    public static Space getSpace(int row, int col) {
        string s = "space_" + row + col;
        return GameObject.Find(s).GetComponent<Space>();        
    }
}
