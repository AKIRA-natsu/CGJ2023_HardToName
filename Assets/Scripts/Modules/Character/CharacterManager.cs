using System;
using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using AKIRA.UIFramework;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

/// <summary>
/// 玩家类
/// </summary>
[System.Serializable]
public class Character {
    public int CharacterID;
    public string Name;
}

[Source("Source/Manager/[CharacterManager]", GameData.Source.Manager)]
public class CharacterManager : MonoSingleton<CharacterManager>, ISource, IUpdate {
    [SerializeField]
    private Character[] characters;

    [SerializeField]
    private CharacterBehaviour[] behaviours;

    private int curCharacterID = -1;

    /// <summary>
    /// 控制类
    /// </summary>
    private PlayerInputAction inputAction;
    private PlayerInput input;

    private bool cursorEnabled = false;

    public async UniTask Load() {
        await UniTask.Yield();
        characters = CGJGame.Path.DialogConfig.Load<DialogConfig>().GetCharacters().ToArray();
        behaviours = this.GetComponentsInChildren<CharacterBehaviour>();
        input = this.GetComponent<PlayerInput>();
        inputAction = new PlayerInputAction();

        EventManager.Instance.AddEventListener(CGJGame.Event.OnSwitchCameraMain, SwtichPlayer);
        EventManager.Instance.AddEventListener(CGJGame.Event.OnSwitchCameraSub, DisablePlayer);
        EventManager.Instance.AddEventListener(CGJGame.Event.OnDialogStart, _ => UpdateCursor(true));
        EventManager.Instance.AddEventListener(CGJGame.Event.OnDialogCompleted, _ => UpdateCursor(false));
    }

    /// <summary>
    /// 替换文本
    /// </summary>
    /// <param name="content"></param>
    public string ReplaceContent(string content) {
        for (int i = 0; i < characters.Length; i++) {
            var character = characters[0];
            var target = $"{{{character.CharacterID}}}";
            content.Replace(target, character.Name);
        }
        return content;
    }

    /// <summary>
    /// 获得角色名称
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetCharacterName(string id) {
        return characters.SingleOrDefault(character => character.CharacterID.ToString().Equals(id))?.Name ?? default;
    }

    /// <summary>
    /// 获得表现
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CharacterBehaviour GetBehaviour(int id) => behaviours?.ElementAt(id - 1) ?? default;

    /// <summary>
    /// 获得当前控制角色表现
    /// </summary>
    /// <returns></returns>
    public CharacterBehaviour GetBehaviour() => behaviours[curCharacterID - 1];

    /// <summary>
    /// 切换玩家
    /// </summary>
    /// <param name="id"></param>
    private void SwtichPlayer(object data) {
        int id = Convert.ToInt32(data);
        curCharacterID = id;
        CameraExtend.GetCamera(GameData.Camera.Sub).gameObject.SetActive(false);
        var camera = CameraExtend.GetCamera(GameData.Camera.Main);
        var freeLook = camera.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = behaviours[id - 1].transform;
        freeLook.LookAt = behaviours[id - 1].center;
        UpdateCursor(false);

        inputAction.Enable();
        this.Regist(GameData.Group.AI, UpdateMode.FixedUpdate);
        UIManager.Instance.Get<BackpackPanel>().ChangeCharacter(curCharacterID);
    }

    /// <summary>
    /// 关闭玩家输入
    /// </summary>
    /// <param name="data"></param>
    private void DisablePlayer(object data) {
        this.Remove(GameData.Group.AI, UpdateMode.FixedUpdate);
        inputAction.Disable();
        UpdateCursor(true);
    }

    public void GameUpdate() {
        if (GameManager.IsStateEqual(GameState.Pause)) {
            return;
        }

        if (!cursorEnabled)
            GetBehaviour().Move(inputAction.Player.Move.ReadValue<Vector2>());
        
        if (Keyboard.current.leftAltKey.wasPressedThisFrame) {
            UpdateCursor(!cursorEnabled);
        }
    }

    /// <summary>
    /// 更新鼠标
    /// </summary>
    /// <param name="enabled"></param>
    public void UpdateCursor(bool enabled) {
        cursorEnabled = enabled;
        Cursor.visible = enabled;
        CameraExtend.GetCamera(GameData.Camera.Main).GetComponent<CinemachineFreeLook>().enabled = !enabled;
    }
}