using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AKIRA.UIFramework {
    public class MainPanelProp : UIComponent {
        [UIControl("Title")]
        protected TextMeshProUGUI Title;
        [UIControl("Buttons/EnterBtn/EnterBtnText")]
        protected TextMeshProUGUI EnterBtnText;
        [UIControl("Buttons/EnterBtn")]
        protected Button EnterBtn;
        [UIControl("Buttons/ExitBtn/ExitBtnText")]
        protected TextMeshProUGUI ExitBtnText;
        [UIControl("Buttons/ExitBtn")]
        protected Button ExitBtn;
    }
}