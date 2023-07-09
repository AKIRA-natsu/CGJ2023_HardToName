using System;
using System.Collections;
using System.Collections.Generic;
using AKIRA.Manager;
using DG.Tweening;
using Modules.Item;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class BackpackItemImg : MonoBehaviour,IPool
{
    [HideInInspector]public ItemInfo ItemInfo;
    private Button _button;

    private void Start()
    {
        _button = this.gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnUseSource);
    }
    

    public void UseItem(int  itemId)
    {
        if (itemId!=ItemInfo.ItemId) return;
        ObjectPool.Instance.Destory(this.gameObject);
        var mm = ItemManager.Instance.GetItemInfo(ItemInfo.ItemId).IsUse;
        if (mm != -1) mm = 1;
    }

    private void OnUseSource()
    {
        ObjectPool.Instance.Destory(this.gameObject);
        var mm = ItemManager.Instance.GetItemInfo(ItemInfo.ItemId).IsUse;
        if (mm != -1) mm = 1;
    }
    public void SetInfo(Sprite sprite,ItemInfo info)
    {
        this.transform.GetComponent<Image>().sprite = sprite;
        ItemInfo = info;
    }

    public void UpdatePos(float y)
    {
        this.transform.localScale=Vector3.one;
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(y, 0.3f);
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
