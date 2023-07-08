using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AKIRA.UIFramework {
    [Win(WinEnum.Dialog, "Prefabs/UI/Dialog", WinType.Normal)]
    public class DialogPanel : DialogPanelProp {
        public override void Awake(object obj) {
            base.Awake(obj);
        }

        public override void Show() {
            base.Show();
            UpdateTextPosition(Random.insideUnitSphere * 3);
            ShowText("this is a name", "this is a text show for example....");
        }

        /// <summary>
        /// 更新文本位置
        /// </summary>
        /// <param name="worldPosition"></param>
        public void UpdateTextPosition(Vector3 worldPosition) {
            this.Bg.rectTransform.anchoredPosition = worldPosition.WorldToUGUI();
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public async void ShowText(string name, string text) {
            this.Name.text = name;
            this.Text.text = default;
            
            for (int i = 0; i < text.Length; i++) {
                await UniTask.Yield();
                this.Text.text += text[i];
            }
        }
    }
}