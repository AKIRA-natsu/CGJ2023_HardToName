using AKIRA.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AKIRA.Behaviour.Camera {
    /// <summary>
    /// 摄像机点击表现
    /// </summary>
    public class CameraClickBehaviour : CameraBehaviour {
        public override void GameUpdate() {
            if (!GameManager.IsStateEqual(GameState.Playing))
                return;

            var mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame) {
                Ray ray = CameraExtend.MainCamera.ScreenPointToRay(mouse.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hit, System.Single.MaxValue)) {
                    if (hit.transform.TryGetComponent<IClick>(out IClick click)) {
                        click.OnClick();
                    }
                }
            }
        }
    }
}