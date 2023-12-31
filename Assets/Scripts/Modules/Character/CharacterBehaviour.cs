using System;
using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using Modules.Item;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 玩家表现
/// </summary>
public class CharacterBehaviour : MonoBehaviour, IClick, IUpdate {
    // 摄像机看向视角
    public Transform center;
    // id
    public int characterID;
    // 移动方向
    private Vector3 moveDir;
    // 移动速度
    public float speed;
    // 检测半径
    [SerializeField]
    private float radius;
    
    private void Start() {
        EventManager.Instance.AddEventListener(CGJGame.Event.OnSwitchCameraMain, data => {
            if (Convert.ToInt32(data) == characterID)
                this.Regist(GameData.Group.AI);
        });
        EventManager.Instance.AddEventListener(CGJGame.Event.OnSwitchCameraSub, _ => {
            if (CharacterManager.Instance.GetBehaviour().Equals(this))
                this.Remove(GameData.Group.AI);
        });
    }

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="inputPosition"></param>
    public void Move(Vector2 inputPosition) {
        // 相对摄像机的前后左右
        Vector3 dir = Quaternion.Euler(0, CameraExtend.Transform.localEulerAngles.y, 0) * new Vector3(inputPosition.x, 0, inputPosition.y);
        if (dir.sqrMagnitude == 0f)
            moveDir = Vector3.zero;
        else
            moveDir = Vector3.Lerp(moveDir, dir, Time.deltaTime * 10f);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(moveDir.Equals(Vector3.zero) ? this.transform.forward : moveDir), Time.deltaTime * 10f);
        // 如果转向小于50才移动
        if (Vector3.Angle(this.transform.forward, moveDir.normalized) <= 50f) {
            this.transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
            // Animation.SwitchAnima(AIState.Move, moveDir.Equals(Vector3.zero) ? 0 : run ? 1f : 0.5f);
        } else {
            // Animation.SwitchAnima(AIState.Move, 0);
        }
    }

    public void OnClick() {
        EventManager.Instance.TriggerEvent(CGJGame.Event.OnSwitchCameraMain, characterID);
    }

    public void GameUpdate() {
        // 物体检测
        if (Keyboard.current.fKey.wasPressedThisFrame) {
            "触发事件".Log();
            EventManager.Instance.TriggerEvent(CGJGame.Event.OnPackItem);
        }
    }
}