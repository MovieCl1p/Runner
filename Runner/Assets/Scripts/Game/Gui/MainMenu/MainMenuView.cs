using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Commands;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField]
        private Button _playBtn;

        protected override void Start()
        {
            base.Start();

            _playBtn.onClick.AddListener(OnPLayClick);
        }

        private void OnPLayClick()
        {
            StartLevelCommand startLevelCommand = new StartLevelCommand(1);
            startLevelCommand.Execute();

            CloseView();
        }
    }
}
