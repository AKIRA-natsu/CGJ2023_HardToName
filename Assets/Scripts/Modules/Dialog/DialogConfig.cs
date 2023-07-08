using System.Collections.Generic;
using System;
using Modules.Item;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogConfig", menuName = "CGJ/DialogConfig", order = 0)]
public class DialogConfig : ScriptableObject {
    /// <summary>
    /// Excel 路径
    /// </summary>
    public string excelPath;

    /// <summary>
    /// 文本数组
    /// </summary>
    [SerializeField]
    private Dialog[] dialogs;

    /// <summary>
    /// 获得玩家
    /// </summary>
    [SerializeField]
    private Character[] characters;

    /// <summary>
    /// 获得物品
    /// </summary>
    [SerializeField]
    private ItemInfo[] _itemInfos;
    
    /// <summary>
    /// 获得所有对话文本
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Dialog> GetDialogs() => dialogs;

    /// <summary>
    /// 设置文本，Editor用
    /// </summary>
    /// <param name="dialogs"></param>
    public void SetDialogs(Dialog[] dialogs) => this.dialogs = dialogs;

    /// <summary>
    /// 获得全部角色
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Character> GetCharacters() => characters;


    
    /// <summary>
    /// 设置角色，Editor用
    /// </summary>
    /// <param name="characters"></param>
    public void SetCharacters(Character[] characters) => this.characters = characters;
    
    /// <summary>
    /// 获得物体
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<ItemInfo> GetItemInfo() => _itemInfos;
    

    public void SetItems(ItemInfo[] itemInfo) => this._itemInfos = itemInfo;
}