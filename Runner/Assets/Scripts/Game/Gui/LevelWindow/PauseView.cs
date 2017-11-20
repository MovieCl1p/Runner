using System;
using Core.Binder;
using Core.Dispatcher;
using Core.ViewManager;
using Game.Data;
using Game.Events;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    class PauseView : BaseView
    {
        [SerializeField] private LevelSessionModel _levelModel;

        [SerializeField] private Button _backButton;

        [SerializeField] private Button _MenuButton;

        [SerializeField] private Text _levelTime;

        protected override void Start()
        {
            base.Start();

            _backButton.onClick.AddListener(OnBackClick);

            _MenuButton.onClick.AddListener(OnLevelMenuClick);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();
            
            _levelTime.text = _levelModel.LevelTime.ToString();
        }

        private void OnLevelMenuClick()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
            ViewManager.Instance.SetView(ViewNames.EpisodeView);
            
            IDispatcher dispatcher = BindManager.GetInstance<IDispatcher>();
            dispatcher.Dispatch(LevelEventsEnum.Quit);

            Time.timeScale = 1;
        }

        private void OnBackClick()
        {
            Time.timeScale = 1;
            CloseView();

        }
    }
}
