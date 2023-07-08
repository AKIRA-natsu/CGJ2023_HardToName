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

        private Sprite _sprite;

        protected override void Start()
        {
            base.Start();
            _sprite = this.transform.GetComponent<SpriteRenderer>().sprite;
        }
        public void Pack(int characterId)
        {
            itemInfo.OwnerId = characterId;
            ItemManager.Instance.PackItem(this.itemInfo,_sprite);
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
            _itemTipCtrl.Show(itemInfo.TipContent);
        }

        public void HideTip()
        {
            ObjectPool.Instance.Destory(_itemTipCtrl);
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
