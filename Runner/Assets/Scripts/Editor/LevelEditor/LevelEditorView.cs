using Core.Binder;
using Core.Commands;
using Core.Dispatcher;
using Core.ViewManager;
using Game.Commands;
using Game.Components;
using Game.Data;
using Game.Events;
using Game.Factory;
using Game.Model;
using UnityEngine;

namespace LevelEditor
{
    public class LevelEditorView : BaseView
    {
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
            _dispatcher.AddListener(LevelEventsEnum.Restart, OnLevelRestart);
            _dispatcher.AddListener(LevelEventsEnum.Finish, OnLevelFinish);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _camera.target = _levelModel.Player.CachedTransform;

            _restartLevelCommand = new RestartLevelCommand(_camera.CachedTransform);
            _restartLevelCommand.Execute();
        }
        
        private void OnLevelFinish()
        {
            OnLevelRestart();
        }

        private void OnLevelRestart()
        {
            _restartLevelCommand.Execute();
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _dispatcher.RemoveListener(LevelEventsEnum.Restart, OnLevelRestart);
            _dispatcher.RemoveListener(LevelEventsEnum.Finish, OnLevelFinish);

            Destroy(_levelModel.Level.gameObject);
            Destroy(_levelModel.Player.gameObject);
        }
    }
}
