using Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    public class LevelItemView : BaseMonoBehaviour
    {
        public event Action<int> OnClick;

        [SerializeField]
        private Text _levelName;

        [SerializeField]
        private Button _btn;

        private int _LevelId;

        protected override void Start()
        {
            base.Start();
            _btn.onClick.AddListener(OnBtnClick);
        }

        public void UpdateView(int levelId)
        {
            _LevelId = levelId;
            _levelName.text = "Level " + levelId;
        }

        private void OnBtnClick()
        {
            if (OnClick != null)
            {
                OnClick(_LevelId);
            }
        }

        protected override void OnDestroy()
        {
            _btn.onClick.RemoveListener(OnBtnClick);
            base.OnDestroy();
        }
    }
}
