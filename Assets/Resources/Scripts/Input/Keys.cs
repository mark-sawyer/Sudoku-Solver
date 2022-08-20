using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
    private List<KeyCode> validKeys;

    private void Start() {
        validKeys = new List<KeyCode>() {
            KeyCode.Alpha1,
            KeyCode.Keypad1,
            KeyCode.Alpha2,
            KeyCode.Keypad2,
            KeyCode.Alpha3,
            KeyCode.Keypad3,
            KeyCode.Alpha4,
            KeyCode.Keypad4,
            KeyCode.Alpha5,
            KeyCode.Keypad5,
            KeyCode.Alpha6,
            KeyCode.Keypad6,
            KeyCode.Alpha7,
            KeyCode.Keypad7,
            KeyCode.Alpha8,
            KeyCode.Keypad8,
            KeyCode.Alpha9,
            KeyCode.Keypad9,
            KeyCode.Backspace,
            KeyCode.Escape
        };
    }

    void Update() {
        foreach (KeyCode key in validKeys) {
            if (Input.GetKeyDown(key)) {
                KeyAnnouncer.announceKey(key);
                break;
            }
        }
    }
}
