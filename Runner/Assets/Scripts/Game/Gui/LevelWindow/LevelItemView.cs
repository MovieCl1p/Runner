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
        
        [SerializeField] private Button _playBtn;

        private LevelConfig _config;

        protected override void Start()
        {
            base.Start();

            _playBtn.onClick.AddListener(OnPlayClick);
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
        
        protected override void OnDestroy()
        {
            _playBtn.onClick.RemoveListener(OnPlayClick);

            base.OnDestroy();
        }
    }
}
