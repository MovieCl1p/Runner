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
            _dispatcher.AddListener(LevelEventsEnum.RestartTrigerEntered.ToString(), OnPlayerRestart);
            
            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _camera.CachedTransform.position = _levelModel.Player.CachedTransform.position;
            _camera.target = _levelModel.Player.CachedTransform;

            ScheduleUpdate(1, false);
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();
        }
        
        private void OnPlayerRestart()
        {
            _restartLevelCommand = new RestartLevelCommand();
            _restartLevelCommand.Execute();
        }
    }
}
