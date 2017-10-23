using System;
using Core;
using Core.Binder;
using Core.ViewManager;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.LevelWindow
{
    public class FinishView : BaseView
    {
        [SerializeField] private Text _levelTime;

        [SerializeField] private Button _backButton;

        private LevelSessionModel _levelModel;

        private GameView.GameView _gameView;

        protected override void Start()
        {
            base.Start();

            _backButton.onClick.AddListener(OnBackClick);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _levelTime.text = _levelModel.LevelTime.ToString();
        }

        private void OnBackClick()
        {
            Time.timeScale = 1;

            ViewManager.Instance.SetView(ViewNames.LevelView, _levelModel.EpisodeId);

            ViewManager.Instance.GetLayerById(LayerNames.ThreeDLayer).RemoveCurrentView();
            
        }
    }
}
