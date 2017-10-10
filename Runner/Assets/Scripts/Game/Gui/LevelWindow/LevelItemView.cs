using Core;
using Game.Config.Levels;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    public class LevelItemView : BaseMonoBehaviour
    {
        public event Action<LevelConfig> OnClick;

        [SerializeField]
        private Text _levelName;

        [SerializeField]
        private Button _btn;

        private LevelConfig _config;

        protected override void Start()
        {
            base.Start();
            _btn.onClick.AddListener(OnBtnClick);
        }

        public void UpdateView(LevelConfig config)
        {
            _config = config;
            _levelName.text = config.LevelName;
        }

        private void OnBtnClick()
        {
            if (OnClick != null)
            {
                OnClick(_config);
            }
        }

        protected override void OnDestroy()
        {
            _btn.onClick.RemoveListener(OnBtnClick);
            base.OnDestroy();
        }
    }
}
