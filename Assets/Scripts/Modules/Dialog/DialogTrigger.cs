using System;
using AKIRA.Manager;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// 对话触发器
/// </summary>
public class DialogTrigger : MonoBehaviour {
    // 对话id
    [SelectionPop(typeof(CGJGame.DialogID))]
    public string dialogID;
    // timeline
    public PlayableDirector director;

    private void OnTriggerEnter(Collider other) {
        EventManager.Instance.AddEventListener(CGJGame.Event.OnDialogCompleted, OnDialogCompleted);
        DialogSystem.Instance.StartDialog(dialogID);
        if (director != null)
            director.Play();
    }

    /// <summary>
    /// 文本结束
    /// </summary>
    /// <param name="data"></param>
    private void OnDialogCompleted(object data) {
        var id = Convert.ToString(data);
        if (id.Equals(dialogID)) {
            EventManager.Instance.RemoveEventListener(CGJGame.Event.OnDialogCompleted, OnDialogCompleted);
            this.gameObject.SetActive(false);
            if (director != null)
                director.Stop();
        }
    }
}