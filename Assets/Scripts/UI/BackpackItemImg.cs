using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BackpackItemImg : MonoBehaviour
{
    [HideInInspector]public int ItemId;
    public void UseItem(int  itemId)
    {
        if (itemId!=ItemId) return; 
        this.gameObject.SetActive(false);
    }

    public void SetInfo(Sprite sprite,int id)
    {
        this.transform.GetComponent<Image>().sprite = sprite;
    }

    public void UpdatePos(float x)
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosX(x, 0.3f).SetEase(Ease.OutBounce);
    }
}
