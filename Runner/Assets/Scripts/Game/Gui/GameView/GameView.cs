using Core.Binder;
using Core.ResourceManager;
using Core.ViewManager;
using Game.Components;
using Game.Factory;
using Game.Model;
using Game.Player;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Gui.GameView
{
    public class GameView : BaseView
    {
        [SerializeField]
        private Transform _levelHolder;

        [SerializeField]
        private CameraSmoothFollow _camera;

        protected override void Start()
        {
            base.Start();

            var model = BindManager.GetInstance<LevelSessionModel>();
            var loaderService = BindManager.GetInstance<ILevelLoaderService>();
            var factory = BindManager.GetInstance<GameFactory>();

            loaderService.GetLevel(model.LevelId, null, OnLevelLoaded);
        }

        private void OnLevelLoaded()
        {
            var factory = BindManager.GetInstance<GameFactory>();
            var player = factory.GetPlayer();
            
            _camera.CachedTransform.position = player.CachedTransform.position;
            _camera.target = player.CachedTransform;
        }
    }
}
