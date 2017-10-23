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
        private float _time = 0;
        
        [SerializeField] private Transform _levelHolder;

        [SerializeField] private CameraSmoothFollow _camera;

        private IDispatcher _dispatcher;

        private LevelSessionModel _levelModel;

        private ICommand _restartLevelCommand;

        private bool _paused;

        protected override void Start()
        {
            base.Start();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _dispatcher.AddListener(LevelEventsEnum.Restart, OnPlayerRestart);
            _dispatcher.AddListener(LevelEventsEnum.Finish, OnFinishLevel);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();
            
            _camera.target = _levelModel.Player.CachedTransform;

            _restartLevelCommand = new RestartLevelCommand(_camera.CachedTransform);
            _restartLevelCommand.Execute();
        }

        protected override void Update()
        {
            base.Update();

            _time += Time.deltaTime;
        }

        private void OnFinishLevel()
        {
            _levelModel.LevelTime = _time;
            
            ViewManager.Instance.SetView(ViewNames.FinishView);
        }
        
        private void OnPlayerRestart()
        {
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
