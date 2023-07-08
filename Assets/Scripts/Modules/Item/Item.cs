using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Item
{
    public class Item : MonoBehaviour
    {
       [SerializeField]private string itemId;

       public ItemInfo ItemInfo;

       protected void Start()
       {
           InitData();
       }

       /// <summary>
       /// 初始化物品信息
       /// </summary>
       protected virtual void InitData()
        {
            ItemInfo=ItemManager.Instance.GetItemInfo(itemId);
        }
        
    }

    public interface IInteract
    {
        /// <summary>
        /// 捡取物品
        /// </summary>
        void Pack();
        /// <summary>
        /// 使用物品
        /// </summary>
        void Use();
    }

    /// <summary>
    /// 玩家走进的时候展示提示信息
    /// </summary>
    public interface ITip
    {
        void ShowTip();
    }

    public class ItemInfo
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public string ItemId;
        /// <summary>
        /// 提示内容
        /// </summary>
        public string TipContent ;
        
        /// <summary>
        /// 物体名称
        /// </summary>
        public string ItemName;

        /// <summary>
        /// 拥有者的ID
        /// </summary>
        public string OwnerId;
        
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsUse;
    }
}