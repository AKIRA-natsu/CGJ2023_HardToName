using UnityEngine;
/// <summary>
/// 数据管理类
/// </summary>
public class CGJGame {
    /// <summary>
    /// 资产路径
    /// </summary>
    public class Path {
        public const string Xlsx = "Assets/Assets/游戏设计表.xlsx";
        public const string DialogConfig = "Config/DialogConfig";
        public const string ItemTip = "Prefabs/Item/ItemTipCtrl";
        public const string BackpackItemImg = "Prefabs/Item/BackpackItemImg";
        public const string ItemSprite = "Sprite/Item";
    }

    public class Event {
        public const string OnDialogStart = "OnDialogStart";
        public const string OnDialogCompleted = "OnDialogCompleted";

        public const string OnSwitchCameraSub = "OnSwitchCameraSub";
        public const string OnSwitchCameraMain = "OnSwitchCameraMain";

        public const string OnPackItem = "OnPackItem";
    }

    /// <summary>
    /// Dialog Id 对应表里的Scene ID
    /// </summary>
    public class DialogID {
        public const string Scene0_1 = "0-1";
        public const string Scene1_1 = "1-1";
        public const string Scene1_2 = "1-2";
        public const string Scene1_3 = "1-3";
        public const string Scene2_1 = "2-1";
        public const string Scene2_2 = "2-2";
        public const string Scene3_1 = "3-1";
        public const string Scene3_2 = "3-2";
        public const string Scene3_3 = "3-3";
        public const string Scene3_4 = "3-4";
        
    }

    public class Number {
        /// <summary>
        /// 获得随机数字
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNum() {
            return Random.Range(0, 9);
        }
    }
}