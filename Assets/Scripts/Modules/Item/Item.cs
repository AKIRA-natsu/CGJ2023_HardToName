using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Item
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int itemId;

        [FormerlySerializedAs("ItemInfo")] public ItemInfo itemInfo;

        protected virtual void Start()
        {
            InitData();
        }

        /// <summary>
        /// 初始化物品信息
        /// </summary>
        protected virtual void InitData()
        {
            itemInfo = ItemManager.Instance.GetItemInfo(itemId);
        }
    }

    public interface IInteract : ITip
    {
        /// <summary>
        /// 捡取物品
        /// </summary>
        void Pack(int characterId );

        /// <summary>
        /// 使用物品
        /// </summary>
        bool Use();
    }

    /// <summary>
    /// 玩家走进的时候展示提示信息
    /// </summary>
    public interface ITip
    {
        void ShowTip(Vector3 pos);
        void HideTip();
    }

    [Serializable]
    public class ItemInfo
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId;

        /// <summary>
        /// 提示内容
        /// </summary>
        public string TipContent;

        /// <summary>
        /// 物体名称
        /// </summary>
        public string ItemName;

        /// <summary>
        /// 拥有者的ID
        /// </summary>
        public int OwnerId;

        /// <summary>
        /// 是否使用,0未使用1已经使用
        /// </summary>
        public int IsUse;
    }
}