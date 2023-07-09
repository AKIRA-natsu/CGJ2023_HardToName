using System;
using System.Collections;
using System.Collections.Generic;
using AKIRA.Manager;
using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BackpackItemImg : MonoBehaviour,IPool
{
    [HideInInspector]public int ItemId;
    public void UseItem(int  itemId)
    {
        if (itemId!=ItemId) return;
        ObjectPool.Instance.Destory(this.gameObject);
    }

    public void SetInfo(Sprite sprite,int id)
    {
        this.transform.GetComponent<Image>().sprite = sprite;
    }

    public void UpdatePos(float x)
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosX(x, 0.3f).SetEase(Ease.OutBounce);
    }

    public void Wake(object data = null)
    {
        throw new NotImplementedException();
    }

    public void Recycle(object data = null)
    {
        throw new NotImplementedException();
    }
}
