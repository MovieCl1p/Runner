using Core;
using Core.Binder;
using Core.ViewManager;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    public class FinishItemView : BaseView
    {
        [SerializeField] private Text text;

        private LevelSessionModel _levelModel;

        private GameView.GameView _gameView;

        protected void Start()
        {
            base.Start();

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            text.text = _levelModel.LevelTime.ToString();
        }
    }
}
