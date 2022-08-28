using UnityEngine.Events;

public static class GameEvents {
    public static readonly UnityEvent nothingClicked = new UnityEvent();
    public static readonly UnityEvent<Digit> digitPressed = new UnityEvent<Digit>();
    public static readonly UnityEvent backSpacePressed = new UnityEvent();
    public static readonly UnityEvent escapePressed = new UnityEvent();
    public static readonly UnityEvent solveClicked = new UnityEvent();
    public static readonly UnityEvent appearStop = new UnityEvent();
    public static readonly UnityEvent solveOver = new UnityEvent();
    public static readonly UnityEvent stopClicked = new UnityEvent();
}
