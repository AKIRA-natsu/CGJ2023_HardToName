using System;
using AKIRA.Manager;
using AKIRA.UIFramework;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Item
{
    /// <summary>
    /// 可以多次使用的物品
    /// </summary>
    public class NonConsumeItem : Item,IInteract,ITip,IPool
    {
        private ItemTipCtrl _itemTipCtrl;

        public void Pack(int characterId)
        {
            itemInfo.OwnerId = characterId;
            ItemManager.Instance.PackItem(this.itemInfo);
            this.gameObject.SetActive(false);
        }

        public bool Use()
        {
            UIManager.Instance.Get<BackpackPanel>().UseItem(itemInfo.ItemId);
            return true;
        }

        public void ShowTip(Vector3 pos)
        {
            _itemTipCtrl= ObjectPool.Instance.Instantiate<ItemTipCtrl>(CGJGame.Path.ItemTip,pos, Quaternion.identity,this.transform
            ,Space.Self,Vector3.zero);
            _itemTipCtrl.transform.localPosition = Vector3.up * 1.2f;
            _itemTipCtrl.Show(itemInfo.TipContent);
        }

        public void HideTip()
        {
            ObjectPool.Instance.Destory(_itemTipCtrl);
        }
        private void OnTriggerEnter(Collider other)
        {
            ShowTip(this.transform.position);
            EventManager.Instance.AddEventListener(CGJGame.Event.OnPackItem, _ => Use());
        }

        private void OnTriggerExit(Collider other)
        {
            HideTip();
            EventManager.Instance.RemoveEventListener(CGJGame.Event.OnPackItem, _ => Use());

        }

        public void Wake(object data = null)
        {
            //_itemTipCtrl.transform.localScale = (Vector3) data;
        }

        public void Recycle(object data = null)
        {
           // Vector3 positon = (Vector3) data;

        }
        
        
    }
}
