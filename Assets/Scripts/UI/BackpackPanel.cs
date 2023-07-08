using System.Collections.Generic;
using AKIRA.Manager;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using Modules.Item;
using UnityEngine;
using Image = UnityEngine.UIElements.Image;

namespace AKIRA.UIFramework {
    [Win(WinEnum.Backpack, "Prefabs/UI/Backpack", WinType.Normal)]
    public class BackpackPanel : BackpackPanelProp,IPool
    {
        private RectTransform _backContainerTr;
        public override void Awake(object obj) {
            base.Awake(obj);
            _backContainerTr = BackContainer.transform.GetComponent<RectTransform>();
            GameManager.Instance.RegistOnStateChangeAction(ActivePanel);
        }

        private void ActivePanel(GameState state)
        {
            this.Active = state == GameState.Playing;
        }
        /// <summary>
        /// 显示背包
        /// </summary>
        public void ShowBackpack()
        {
            MoveBackpack(0);
            ShowIcon(false);
        }

        public void HideBackpack()
        {
            MoveBackpack(-250f);
            ShowIcon(true);

        }

        private void MoveBackpack(float x)
        {
            _backContainerTr.DOAnchorPosX(x, 0.3f).SetEase(Ease.OutBounce);
        }

        private void ShowIcon(bool hide)
        {
            BackShowImg.gameObject.SetActive(hide);
        }

        private void UpdateBackPack()
        {
            int n = 0;
            foreach (var item in ItemManager.Instance.GetPlayerItem())
            {
                
            }
            for (int i = 0; i < _backContainerTr.childCount; i++)
            {
                if (_backContainerTr.GetChild(i).TryGetComponent<BackpackItemImg>(out var backpackItemImg))
                {
                    if (_backContainerTr.GetChild(i).gameObject.activeSelf)
                    {
                        backpackItemImg.UpdatePos(-(n * 150 + 20));
                        n++;
                    }
                }
            }
        }

        public void GetItem(Sprite sprite,int id)
        {
           var ob= ObjectPool.Instance.Instantiate(CGJGame.Path.ItemTip, Vector3.zero, Quaternion.identity, this._backContainerTr);
           ob.transform.GetComponent<BackpackItemImg>().SetInfo(sprite,id); 
           UpdateBackPack();
        }

        public void UseItem(int id)
        {
            for (int i = 0; i < _backContainerTr.childCount; i++)
            {
                if (_backContainerTr.GetChild(i).TryGetComponent<BackpackItemImg>(out var backpackItemImg))
                {
                    backpackItemImg.UseItem(id);
                }
            }
            UpdateBackPack();
        }

        public void Wake(object data = null)
        {
            
        }

        public void Recycle(object data = null)
        {
            
        }
    }
}