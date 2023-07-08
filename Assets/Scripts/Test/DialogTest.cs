using AKIRA.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogTest : MonoBehaviour {
    private void Update() {
        var board = Keyboard.current;
        if (board.digit1Key.wasPressedThisFrame) {
            DialogSystem.Instance.StartDialog(CGJGame.DialogID.Scene0_1);
        }
        if (board.digit2Key.wasPressedThisFrame) {
            DialogSystem.Instance.StartDialog(CGJGame.DialogID.Scene1_1);
        }
        if (board.digit3Key.wasPressedThisFrame) {
            DialogSystem.Instance.StartDialog(CGJGame.DialogID.Scene1_3);
        }
    }
}