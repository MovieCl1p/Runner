using Core.Binder;
using Core.ViewManager;
using Game.Data;
using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.LevelWindow
{
    class PauseView : BaseView
    {
        [SerializeField] private LevelSessionModel _levelModel;

        [SerializeField] private Button _backButton;

        [SerializeField] private Text _levelTime;

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
            CloseView();

        }
    }
}
