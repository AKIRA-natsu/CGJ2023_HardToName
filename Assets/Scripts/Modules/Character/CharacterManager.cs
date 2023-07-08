using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 玩家类
/// </summary>
[System.Serializable]
public class Character {
    public int CharacterID;
    public string Name;
}

[Source("Source/Manager/[CharacterManager]", GameData.Source.Manager)]
public class CharacterManager : MonoSingleton<CharacterManager>, ISource {
    [SerializeField]
    private Character[] characters;

    [SerializeField]
    private CharacterBehaviour[] behaviours;

    public async UniTask Load() {
        await UniTask.Yield();
        characters = CGJGame.Path.DialogConfig.Load<DialogConfig>().GetCharacters().ToArray();
    }

    /// <summary>
    /// 替换文本
    /// </summary>
    /// <param name="content"></param>
    public string ReplaceContent(string content) {
        for (int i = 0; i < characters.Length; i++) {
            var character = characters[0];
            var target = $"{{{character.CharacterID}}}";
            content.Replace(target, character.Name);
        }
        return content;
    }

    /// <summary>
    /// 获得角色名称
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetCharacterName(string id) {
        return characters.SingleOrDefault(character => character.CharacterID.ToString().Equals(id))?.Name ?? default;
    }

    /// <summary>
    /// 获得表现
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CharacterBehaviour GetBehaviour(int id) => behaviours?.ElementAt(id) ?? default;
}