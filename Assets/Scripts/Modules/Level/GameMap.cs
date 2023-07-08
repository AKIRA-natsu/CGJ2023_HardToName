using AKIRA.Data;
using AKIRA.Manager;
using Cysharp.Threading.Tasks;
using UnityEngine;

[Source("Source/Base/[GameMap]", GameData.Source.Scene, 1)]
public class GameMap : MonoSingleton<GameMap>, ISource {
    private GameObject[] levels;
    public int Level { get; private set; }

    public async UniTask Load() {
        var count = this.transform.childCount;
        levels = new GameObject[count];
        for (int i = 0; i < count; i++) {
            await UniTask.Yield();
            levels[i] = this.transform.GetChild(i).gameObject;
        }

        Level = 0;
        ShowLevel();
    }

    /// <summary>
    /// 下一关
    /// </summary>
    public void NextLevel() {
        Level++;
        ShowLevel();
    }

    /// <summary>
    /// 显示关卡
    /// </summary>
    private void ShowLevel() {
        for (int i = 0; i < levels.Length; i++)
            levels[i].SetActive(i == Level);
    }
}