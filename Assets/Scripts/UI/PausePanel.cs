using AKIRA.Data;
using AKIRA.Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

namespace AKIRA.UIFramework {
    [Win(WinEnum.Pause, "Prefabs/UI/Pause", WinType.Interlude)]
    public class PausePanel : PausePanelProp, IUpdate {
        public override void Awake(object obj) {
            base.Awake(obj);
            this.ResumeBtn.onClick.AddListener(Hide);
            this.ExitBtn.onClick.AddListener(
                #if UNITY_EDITOR
                () => UnityEditor.EditorApplication.isPlaying = false
                #else
                UnityEngine.Application.Quit
                #endif
            );
            Hide();
            this.Regist(GameData.Group.UI);
        }

        public override void Show() {
            base.Show();
            UpdateManager.Instance.EnableGroupUpdate(false);
            GameManager.Instance.Switch(GameState.Pause);
            CharacterManager.Instance.UpdateCursor(true);
        }

        public override void Hide() {
            base.Hide();
            UpdateManager.Instance.EnableGroupUpdate(true);
            GameManager.Instance.Switch(GameState.Playing);
            CharacterManager.Instance?.UpdateCursor(false);
        }

        public void GameUpdate() {
            if (!Active && GameManager.IsStateEqual(GameState.Playing) && Keyboard.current.escapeKey.wasPressedThisFrame)
                this.Active = true;
        }
    }
}