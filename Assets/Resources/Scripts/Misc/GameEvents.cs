using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents {
    public static readonly UnityEvent nothingClicked = new UnityEvent();
    public static readonly UnityEvent<Digit> digitPressed = new UnityEvent<Digit>();
    public static readonly UnityEvent backSpacePressed = new UnityEvent();
    public static readonly UnityEvent escapePressed = new UnityEvent();
}
