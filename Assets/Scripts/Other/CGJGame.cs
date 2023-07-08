/// <summary>
/// 数据管理类
/// </summary>
public class CGJGame {
    /// <summary>
    /// 资产路径
    /// </summary>
    public class Path {
        public const string DialogConfig = "Config/DialogConfig";
        public const string ItemTip = "Prefabs/Item/ItemTipCtrl";
        public const string BackpackItemImg = "Prefabs/Item/BackpackItemImg";
    }

    public class Event {
        public const string OnDialogStart = "OnDialogStart";
        public const string OnDialogCompleted = "OnDialogCompleted";
    }

    public class DialogID {
        public const string Scene0_1 = "0-1";
        public const string Scene1_1 = "1-1";
        public const string Scene1_2 = "1-2";
        public const string Scene1_3 = "1-3";
        public const string Scene2_1 = "2-1";
    }
}