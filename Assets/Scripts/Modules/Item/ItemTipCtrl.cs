using UnityEngine;
using DG.Tweening;
using TMPro;

public class ItemTipCtrl : MonoBehaviour,IPool
{
    private TextMeshPro _text;

    private void Awake()
    {
        _text = this.transform.GetComponentInChildren<TextMeshPro>();
    }

    public void Show(string textStr)
    {
        _text.text = textStr;
    }
    public void Wake(object data = null)
    {
        this.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public void Recycle(object data = null)
    {
        this.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutBack);
    }
}
