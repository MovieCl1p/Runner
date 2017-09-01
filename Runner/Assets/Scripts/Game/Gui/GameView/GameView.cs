using Core.Binder;
using Core.ResourceManager;
using Core.ViewManager;
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
        private Transform _cameraTransform;

        protected override void Start()
        {
            base.Start();

            var model = BindManager.GetInstance<LevelSessionModel>();
            var loaderService = BindManager.GetInstance<ILevelLoaderService>();
            var factory = BindManager.GetInstance<GameFactory>();

            var levelGo = loaderService.GetLevel(model.LevelId);

            var player = factory.GetPlayer();

            Vector3 localPosition = _cameraTransform.localPosition;
            _cameraTransform.SetParent(player.transform);

            _cameraTransform.localPosition = localPosition;

            Debug.Break();
        }
    }
}
