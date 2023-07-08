using System.Collections;
using AKIRA.Data;
using AKIRA.Manager;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AKIRA.UIFramework {
    [Win(WinEnum.Dialog, "Prefabs/UI/Dialog", WinType.Normal)]
    public class DialogPanel : DialogPanelProp, IUpdate {
        private Dialog[] dialogs;
        private int index = 0;
        private bool isUpdateContent = false;

        public override void Awake(object obj) {
            base.Awake(obj);
            this.Hide();
        }

        /// <summary>
        /// 更新文本位置
        /// </summary>
        /// <param name="worldPosition"></param>
        public void UpdateTextPosition(Vector3 worldPosition) {
            this.Bg.rectTransform.anchoredPosition = worldPosition.WorldToUGUI();
        }

        /// <summary>
        /// 开始对话
        /// </summary>
        /// <param name="dialogs"></param>
        public void StartDialogs(Dialog[] dialogs) {
            Show();
            this.dialogs = dialogs;
            index = 0;
            NextDialog();
            this.Regist(GameData.Group.UI);
        }

        /// <summary>
        /// 
        /// </summary>
        private void NextDialog() {
            var dialog = dialogs[index++];
            var nameStrs = dialog.CharacterID.Split(",");
            string name = "";
            foreach (var str in nameStrs)
                name += $"{CharacterManager.Instance.GetCharacterName(str)} ";
            ShowText(name, dialog.Content);
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        private async void ShowText(string name, string text) {
            this.Name.text = name;
            this.Text.text = default;
            isUpdateContent = true;
            
            for (int i = 0; i < text.Length; i++) {
                await UniTask.Yield();
                this.Text.text += text[i];
            }
            isUpdateContent = false;
        }

        public void GameUpdate() {
            if (isUpdateContent)
                return;
            
            if (Mouse.current.leftButton.wasPressedThisFrame) {
                if (index < dialogs.Length) {
                    NextDialog();
                } else {
                    this.Remove(GameData.Group.UI);
                    EventManager.Instance.TriggerEvent(CGJGame.Event.OnDialogCompleted, dialogs[0].Scene);
                    Hide();
                }
            }
        }
    }
}