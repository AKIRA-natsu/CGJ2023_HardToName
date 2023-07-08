using UnityEngine;
using AKIRA.Manager;
using System.Linq;
using AKIRA.UIFramework;

/// <summary>
/// 对话类
/// </summary>
[System.Serializable]
public class Dialog {
    public int ID;
    public string Scene;
    public string CharacterID;
    public string Content;
}

/// <summary>
/// 文本管理器
/// </summary>
public class DialogSystem : Singleton<DialogSystem> {
    // 配置
    private Dialog[] dialogs;

    protected DialogSystem() {
        dialogs = CGJGame.Path.DialogConfig.Load<DialogConfig>().GetDialogs().ToArray();
        ReplaceNames();
    }

    /// <summary>
    /// 替换文本内容名字
    /// </summary>
    private void ReplaceNames() {
        foreach (var dialog in dialogs) {
            var content = dialog.Content;
            if (!content.Contains("{"))
                continue;
            dialog.Content = CharacterManager.Instance.ReplaceContent(content);
        }
    }

    /// <summary>
    /// 开始Dialog
    /// </summary>
    public void StartDialog(string id) {
        var curDialogs = dialogs.Where(dialog => dialog.Scene.Equals(id));
        UIManager.Instance.Get<DialogPanel>().StartDialogs(curDialogs.ToArray());
    }
}