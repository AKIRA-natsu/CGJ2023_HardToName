using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AKIRA.UIFramework {
    public class DialogPanelProp : UIComponent {
        [UIControl("Bg/Text")]
        protected TextMeshProUGUI Text;
        [UIControl("Bg/Name")]
        protected TextMeshProUGUI Name;
        [UIControl("Bg")]
        protected Image Bg;
    }
}