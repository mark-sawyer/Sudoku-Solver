using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyAnnouncer {
    public static void announceKey(KeyCode key) {
        if (key == KeyCode.Backspace) GameEvents.backSpacePressed.Invoke();        
        else if (key == KeyCode.Escape) GameEvents.escapePressed.Invoke();
        else {
            Digit digit = KeyCodeToDigit.convertKeyCodeToDigit(key);
            GameEvents.digitPressed.Invoke(digit);
        }
    }
}
