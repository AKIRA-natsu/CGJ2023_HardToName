using System.Collections;
using System.Collections.Generic;
using AKIRA.Data;
using AKIRA.Manager;
using AKIRA.UIFramework;
using DG.Tweening;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SelectionPop(typeof(CGJGame.DialogID))]
    public string dialogID;
    public float delayTime = 1;

    public Transform cameraStartTrans;
    public Transform cameraEndTrans;
    private Transform _cameraTrans;
    void Start()
    {
        _cameraTrans = CameraExtend.GetCamera(GameData.Camera.Sub).transform;
        _cameraTrans.position = cameraStartTrans.position;
        _cameraTrans.rotation = cameraStartTrans.rotation;
        Invoke("Delay", delayTime);
        
    }
    
    private void Delay()
    {
        _cameraTrans.DOMove(cameraEndTrans.position, 1f).OnComplete((() =>
        {
            UIManager.Instance.Get<MainPanel>().Active = true;
        }));
        _cameraTrans.DORotate(cameraEndTrans.rotation.eulerAngles, 1f);
        DialogSystem.Instance.StartDialog(dialogID);
    }
}
