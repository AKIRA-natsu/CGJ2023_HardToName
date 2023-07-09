using System.Collections.Generic;
using System.Linq;
using AKIRA.Data;
using AKIRA.Manager;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using Modules.Item;
using UnityEngine;
using UnityEngine.InputSystem;
using Image = UnityEngine.UIElements.Image;

namespace AKIRA.UIFramework {
    [Win(WinEnum.Backpack, "Prefabs/UI/Backpack", WinType.Normal)]
    public class BackpackPanel : BackpackPanelProp,IPool,IUpdate
    {
        private RectTransform _backContainerTr;

        private float _timer;
        private float timerCountStart;
        
        public override void Awake(object obj) {
            base.Awake(obj);
            _backContainerTr = BackContainer.transform.GetComponent<RectTransform>();
            GameManager.Instance.RegistOnStateChangeAction(ActivePanel);
            ControllerTips(1);
            SwitchCameraBtn.onClick.AddListener(OnSwitchSubCamera);
            EventManager.Instance.AddEventListener( CGJGame.Event.OnSwitchCameraMain, OnSwitchMainCamera);
            SwitchCameraBtn.interactable = false;
            this.Regist(GameData.Group.UI);
        }

        private void ActivePanel(GameState state)
        {
            this.Active = state == GameState.Playing;
        }

        private void OnSwitchSubCamera()
        {
           EventManager.Instance.TriggerEvent( CGJGame.Event.OnSwitchCameraSub);
           SwitchCameraBtn.interactable = false;
        }
        
        private void OnSwitchMainCamera(object ob=null)
        {
            SwitchCameraBtn.interactable = true;
        }

        private void ControllerTips(int endScale=0)
        {
            if ((int)(TipsText.localScale.x)==endScale) return;
                TipsText.DOScale(Vector3.one * endScale, 0.3f).SetEase(Ease.OutBack);
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
            for (int i = 0; i < _backContainerTr.childCount; i++)
            {
                if (_backContainerTr.GetChild(i).TryGetComponent<BackpackItemImg>(out var backpackItemImg))
                {
                    backpackItemImg.UpdatePos(-(n * 150 + 20));
                    n++;
                }
            }
        }

        public void ChangeCharacter(int characterId)
        {
            for (var i = 0; i < _backContainerTr.childCount; i++)
            {
                ObjectPool.Instance.Destory(_backContainerTr.gameObject);
            }

            foreach (var item in ItemManager.Instance.GetPlayerItem().
                         Where(item => item.OwnerId == characterId).Where(item => item.IsUse==0))
            {
                GetItem(item.ItemId);
            }
        }
        public void GetItem(int id)
        {
            GetItemOb().transform.GetComponent<BackpackItemImg>().SetInfo(GetSprite(id),id); 
           UpdateBackPack();
        }

        private Sprite GetSprite(int id)
        {
            return $"{CGJGame.Path.ItemSprite}{id}".Load<Sprite>();
        }

        private GameObject GetItemOb()
        {
             return ObjectPool.Instance.Instantiate
                (CGJGame.Path.BackpackItemImg, Vector3.zero, Quaternion.identity, this._backContainerTr);
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

        public void GameUpdate()
        {
            //if (GameMap.Instance.Level!=1) return;
            timerCountStart += Time.deltaTime;
            if(timerCountStart<10) return;
            _timer+=Time.deltaTime;
            if (_timer > 60)
            {
                ControllerTips(1);
                _timer = 0;
            }

            if (Keyboard.current.anyKey.wasPressedThisFrame||(Input.GetMouseButton(0)))
            {
                _timer = 0;
                ControllerTips();
            }
        }
    }
}