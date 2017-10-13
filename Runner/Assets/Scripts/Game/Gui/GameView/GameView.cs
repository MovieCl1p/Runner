using System;
using Core.Binder;
using Core.Dispatcher;
using Core.ResourceManager;
using Core.ViewManager;
using Game.Components;
using Game.Factory;
using UnityEngine;
using Game.Events;
using Game.Model;
using Core.Commands;
using Game.Commands;
using Game.Data;

namespace Game.Gui.GameView
{
    public class GameView : BaseView
    {
        [SerializeField]
        private Transform _levelHolder;

        [SerializeField]
        private CameraSmoothFollow _camera;

        private IDispatcher _dispatcher;

        private LevelSessionModel _levelModel;

        private ICommand _restartLevelCommand;

        protected override void Start()
        {
            base.Start();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _dispatcher.AddListener(LevelEventsEnum.Restart, OnPlayerRestart);
            _dispatcher.AddListener(LevelEventsEnum.Finish, OnFinishLevel);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _camera.CachedTransform.position = _levelModel.Player.CachedTransform.position;
            _camera.target = _levelModel.Player.CachedTransform;

            ScheduleUpdate(1, false);
        }

        private void OnFinishLevel()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
            ViewManager.Instance.SetView(ViewNames.LevelView, _levelModel.EpisodeId);
            
            ViewManager.Instance.GetLayerById(LayerNames.ThreeDLayer).RemoveCurrentView();
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();

            _levelModel.Player.Activate(true);
            _levelModel.Player.Accelerate();
        }
        
        private void OnPlayerRestart()
        {
            _restartLevelCommand = new RestartLevelCommand();
            _restartLevelCommand.Execute();
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _dispatcher.RemoveListener(LevelEventsEnum.Restart, OnPlayerRestart);
            _dispatcher.RemoveListener(LevelEventsEnum.Finish, OnFinishLevel);

            Destroy(_levelModel.Level.gameObject);
            Destroy(_levelModel.Player.gameObject);
        }
    }
}
