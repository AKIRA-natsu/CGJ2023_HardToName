using UnityEngine;

/// <summary>
/// 对话触发器
/// </summary>
public class DialogTrigger : MonoBehaviour {
    [SelectionPop(typeof(CGJGame.DialogID))]
    public string dialogID;

    private void OnTriggerEnter(Collider other) {
        DialogSystem.Instance.StartDialog(dialogID);
    }
}