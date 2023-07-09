using AKIRA.Manager;
using AKIRA.UIFramework;
using UnityEngine;
using UnityEngine.Pool;

namespace Modules.Item
{
    /// <summary>
    /// 一次性消耗物品、可以交互可以使用一次
    /// </summary>
    public class ConsumeItem : Item,IInteract,IPool
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
            if (itemInfo.IsUse != 0) return false;
            else
            {
                itemInfo.IsUse = 1;
                ItemManager.Instance.UseItem(itemInfo);
                UIManager.Instance.Get<BackpackPanel>().UseItem(itemInfo.ItemId);
                return true;
            }
        }
        
        public void ShowTip(Vector3 pos)
        {
            _itemTipCtrl= ObjectPool.Instance.Instantiate<ItemTipCtrl>(CGJGame.Path.ItemTip,pos, Quaternion.identity,this.transform
                ,Space.Self,Vector3.zero);
            _itemTipCtrl.transform.localPosition = Vector3.up * 1;
            _itemTipCtrl.Show(itemInfo.TipContent);
        }

        public void HideTip()
        {
            ObjectPool.Instance.Destory(_itemTipCtrl);
        }
        private void OnTriggerEnter(Collider other)
        {
            ShowTip(this.transform.position);
            EventManager.Instance.AddEventListener(CGJGame.Event.OnPackItem, _=>Pack(
                CharacterManager.Instance.GetBehaviour().characterID));
        }

        private void OnTriggerExit(Collider other)
        {
            HideTip();
            EventManager.Instance.RemoveEventListener(CGJGame.Event.OnPackItem, _=>Pack(
                CharacterManager.Instance.GetBehaviour().characterID));

        }

        public void Wake(object data = null)
        {
           // _itemTipCtrl.transform.localScale = (Vector3) data;
        }

        public void Recycle(object data = null)
        {
            //Vector3 positon = (Vector3) data;

        }
    }
}
