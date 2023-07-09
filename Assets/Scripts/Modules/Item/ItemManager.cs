using System.Collections.Generic;
using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using AKIRA.UIFramework;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Item
{
    [Source("Source/ItemManager", GameData.Source.Manager, 0)]
    public class ItemManager : MonoSingleton<ItemManager>
    {
        /// <summary>
        /// 玩家收集到的物品
        /// </summary>
        private List<ItemInfo> _playerItemContainer = new List<ItemInfo>();

        /// <summary>
        /// 物品信息列表
        /// </summary>
        private ItemInfo[] _itemInfosContainer;


        protected override void Awake()
        {
            base.Awake();
            _itemInfosContainer = CGJGame.Path.DialogConfig.Load<DialogConfig>().GetItemInfo().ToArray();
        }

        // public async UniTask Load()
        // {
        //     await UniTask.Yield();
        //     await UniTask.Delay(2000);
        // }

        /// <summary>
        /// 通过物品的id获取物品的信息
        /// </summary>
        /// <param name="itemID">物品id</param>
        public ItemInfo GetItemInfo(int itemID)
        {
            return _itemInfosContainer.FirstOrDefault(item => item.ItemId == itemID);
        }

        public void PackItem(ItemInfo itemInfo)
        {
            if (!_playerItemContainer.Contains(itemInfo))
            {
                _playerItemContainer.Add(itemInfo);
                UIManager.Instance.Get<BackpackPanel>().GetItem(itemInfo.ItemId);
            }
        }

        public void UseItem(ItemInfo itemInfo)
        {
            if (_playerItemContainer.Contains(itemInfo))

                _playerItemContainer.Remove(itemInfo);
        }

        public List<ItemInfo> GetPlayerItem()
        {
            return _playerItemContainer;
        }

        /// <summary>
        /// 加载游戏内所有物品的信息Json
        /// </summary>
        public void LoadItemInfo()
        {
        }

        /// <summary>
        /// 存储游戏内所有物品的信息Json
        /// </summary>
        public void SaveItemInfo()
        {
        }
    }
}