using Core.Binder;
using Core.ViewManager;
using Game.Model;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Gui.GameView
{
    public class GameView : BaseView
    {
        [SerializeField]
        private Transform _levelHolder;

        protected override void Start()
        {
            base.Start();

            var model = BindManager.GetInstance<LevelSessionModel>();
            var loaderService = BindManager.GetInstance<ILevelLoaderService>();

            var levelGo = loaderService.GetLevel(model.LevelId);
            levelGo.transform.parent = _levelHolder;
            levelGo.transform.localScale = Vector3.one;
            levelGo.transform.localPosition = Vector3.zero;

        }
    }
}
