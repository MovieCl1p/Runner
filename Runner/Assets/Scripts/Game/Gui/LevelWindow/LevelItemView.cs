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

        [SerializeField] private Text _levelName;

        [SerializeField] private Button _btn;

        [SerializeField] private Button _playBtn;

        [SerializeField] private Button _restartBtn;

        private LevelConfig _config;

        protected override void Start()
        {
            base.Start();
            _btn.onClick.AddListener(OnBtnClick);

            _playBtn.onClick.AddListener(OnPlayClick);

            _restartBtn.onClick.AddListener(OnRestartClick);
        }

        private void OnRestartClick()
        {
            if (OnClick != null)
            {
                OnClick(_config);
            }
        }

        private void OnPlayClick()
        {
            if (OnClick != null)
            {
                OnClick(_config);
            }
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

            _playBtn.onClick.RemoveListener(OnPlayClick);

            base.OnDestroy();
        }
    }
}
