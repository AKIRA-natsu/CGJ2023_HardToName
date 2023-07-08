using UnityEngine;
using UnityEngine.InputSystem;

namespace AKIRA.Behaviour.Camera {
    /// <summary>
    /// 摄像机拖拽表现
    /// </summary>
    public class CameraDragBehaviour : CameraBehaviour {
        private IDrag dragObject;
        /// <summary>
        /// 当前拖拽物体
        /// </summary>
        public IDrag CurrentDrag => dragObject;

        public override void GameUpdate() {
            if (Mouse.current.leftButton.wasReleasedThisFrame && dragObject != null)
            {
                dragObject.OnDragUp();
                dragObject = null;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame && dragObject == null)
            {
                Ray ray = CameraExtend.MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                var hits = Physics.RaycastAll(ray, System.Single.MaxValue);
                foreach (var hit in hits) {
                    // 拿到第一个IDrag
                    if (hit.transform.TryGetComponent<IDrag>(out dragObject)) {
                        dragObject.OnDragDown();
                        break;
                    }
                }
            }

            if (dragObject != null)
                dragObject.OnDrag();
        }
    }
}