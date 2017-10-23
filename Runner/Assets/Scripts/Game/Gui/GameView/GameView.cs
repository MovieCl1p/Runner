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
using UnityEngine.SceneManagement;

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

            _camera.CachedTransform.position = _levelModel.Player.CachedTransform.position;
            _camera.target = _levelModel.Player.CachedTransform;

            ScheduleUpdate(1, false);
        }

        protected override void Update()
        {
            base.Update();

            _time += Time.deltaTime;
            
        }

        private void OnFinishLevel()
        {
            _levelModel.LevelTime = _time;
            //ViewManager.Instance.SetView(ViewNames.LevelView, _levelModel.EpisodeId);
            
            if (!_paused)
            {
                ViewManager.Instance.SetView(ViewNames.FinishView);

                Time.timeScale = 0;

                _paused = true;

            }

                //ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
                //ViewManager.Instance.SetView(ViewNames.LevelView, _levelModel.EpisodeId);
                //ViewManager.Instance.GetLayerById(LayerNames.ThreeDLayer).RemoveCurrentView();
                //_levelModel.LevelTime = _time;
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

            _time = 0;
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
