using AKIRA.Manager;
using UnityEngine;

namespace Modules.Item
{
    public class TipItem : Item,IPool,ITip
    {
        private ItemTipCtrl _itemTipCtrl;
        public void Wake(object data = null)
        {
            
        }

        public void Recycle(object data = null)
        {
            
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
    }
}
