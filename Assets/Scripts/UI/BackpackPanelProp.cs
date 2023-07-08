using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AKIRA.UIFramework {
    public class BackpackPanelProp : UIComponent {
        [UIControl("BackShowImg")]
        protected Image BackShowImg;
        
        [UIControl("BackContainer")]
        protected Image BackContainer;
        
        [UIControl("TipsText")]
        protected RectTransform TipsText;
        
        [UIControl("SwitchCameraBtn")]
        protected Button SwitchCameraBtn;   
        
    }
}