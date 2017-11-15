using System;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Game.Config.Levels;
using Game.Config.Episodes;

namespace Game.Gui.ChapterWindow
{
    public class EpisodeItemView : BaseMonoBehaviour
    {
        public event Action<EpisodeConfig> OnClick;

        [SerializeField]
        private Text _levelName;

        [SerializeField]
        private Button _btn;

        private EpisodeConfig _config;

        protected override void Start()
        {
            base.Start();
            _btn.onClick.AddListener(OnBtnClick);
        }
        
        public void UpdateView(EpisodeConfig config)
        {
            _config = config;
            _levelName.text = config.EpisodeName;
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
