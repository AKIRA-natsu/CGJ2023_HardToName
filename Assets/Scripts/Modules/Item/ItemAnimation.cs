using DG.Tweening;
using UnityEngine;

public class ItemAnimation : MonoBehaviour {
    [SerializeField]
    private Transform target;

    public enum Axis {
        X,
        Y,
        Z,
    }    

    [SerializeField]
    private Axis axis;
    [SerializeField]
    private float angle;

    private Quaternion rotation;

    private void Awake() {
        if (target == null)
            target = this.transform;
        rotation = target.rotation;
    }

    #if UNITY_EDITOR
    [ContextMenu("Play")]
    #endif
    public void Play() {
        var curRotationVec = target.eulerAngles;
        switch (axis) {
            case Axis.X:
            curRotationVec.x = angle;
            break;
            case Axis.Y:
            curRotationVec.y = angle;
            break;
            case Axis.Z:
            curRotationVec.z = angle;
            break;
        }
        target.DOLocalRotate(curRotationVec, 1f);
    }
}