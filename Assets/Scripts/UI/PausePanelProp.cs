using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AKIRA.UIFramework {
    public class PausePanelProp : UIComponent {
        [UIControl("BackGround/PauseTitle")]
        protected TextMeshProUGUI PauseTitle;
        [UIControl("ResumeBtn/ResumeTxt")]
        protected TextMeshProUGUI ResumeTxt;
        [UIControl("ResumeBtn")]
        protected Button ResumeBtn;
        [UIControl("ExitBtn/ExitTxt")]
        protected TextMeshProUGUI ExitTxt;
        [UIControl("ExitBtn")]
        protected Button ExitBtn;
    }
}