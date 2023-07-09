using UnityEngine;

public class Level : MonoBehaviour {
    // 全局的世界摄像机
    public Transform worldCamera;

    [SerializeField]
    private int numCount = 3;
    /// <summary>
    /// 随机的密码
    /// </summary>
    public int[] nums;

    /// <summary>
    /// 关卡开始
    /// </summary>
    public void ActiveLevel(bool active) {
        this.gameObject.SetActive(active);
        if (active) {
            nums = new int[numCount];
            for (int i = 0; i < numCount; i++)
                nums[i] = CGJGame.Number.GetRandomNum();
        }
    }
}