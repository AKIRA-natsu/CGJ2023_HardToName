using AKIRA.Data;
using AKIRA.Manager;
using Cysharp.Threading.Tasks;
using UnityEngine;

[Source("Source/Base/[GameMap]", GameData.Source.Scene, 1)]
public class GameMap : MonoSingleton<GameMap>, ISource {
    private Level[] levels;
    public int Level { get; private set; }

    public async UniTask Load() {
        await UniTask.Yield();
        levels = this.transform.GetComponentsInChildren<Level>();
        Level = 0;
        EventManager.Instance.AddEventListener(GameData.Event.OnAppSourceEnd, FirstShowWorldCamera);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    private void FirstShowWorldCamera(object data) {
        EventManager.Instance.RemoveEventListener(GameData.Event.OnAppSourceEnd, FirstShowWorldCamera);
        ShowLevel();
        SwitchToWorldCamera();
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
            levels[i].gameObject.SetActive(i == Level);
    }

    /// <summary>
    /// 切换到世界摄像机
    /// </summary>
    public void SwitchToWorldCamera() {
        CameraExtend.GetCamera(GameData.Camera.Main).SetActive(true);
        var camera = CameraExtend.GetCamera(GameData.Camera.Sub);
        var worldCameraTrans = levels[Level].worldCamera;
        camera.transform.position = worldCameraTrans.position;
        camera.transform.rotation = worldCameraTrans.rotation;
        camera.gameObject.SetActive(true);
    }
}