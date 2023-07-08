using System.Collections.Generic;
using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using Cysharp.Threading.Tasks;

namespace Modules.Item
{
    [Source("Source/ItemManager", GameData.Source.Manager, 1)]
    public class ItemManager : MonoSingleton<ItemManager>,ISource
    {
        /// <summary>
        /// 游戏场景中所有物品信息列表
        /// </summary>
        private List<ItemInfo> _gameItemContainer = new List<ItemInfo>();
        
        /// <summary>
        /// 物品信息列表
        /// </summary>
        private List<ItemInfo> _itemInfosContainer = new List<ItemInfo>();
        public async UniTask Load()
        {
            await UniTask.Yield();
            await UniTask.Delay(2000);
            "awdawd".Log();
        }

        /// <summary>
        /// 通过物品的id获取物品的信息
        /// </summary>
        /// <param name="itemID">物品id</param>
        public ItemInfo GetItemInfo(string itemID)
        {
            return _itemInfosContainer.FirstOrDefault(item => item.ItemId == itemID);
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
