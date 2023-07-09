using AKIRA.Manager;
using AKIRA.UIFramework;
using UnityEngine;

namespace Modules.Item
{
    public class OrganPropsItem : Item,IInteract,IPool
    {
        private ItemTipCtrl _itemTipCtrl;
        
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

        public void Pack(int characterId)
        {
            ("机关类道具不能被捡起").Log();
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

        public void Wake(object data = null)
        {
            
        }

        public void Recycle(object data = null)
        {
            
        }
    }
}
