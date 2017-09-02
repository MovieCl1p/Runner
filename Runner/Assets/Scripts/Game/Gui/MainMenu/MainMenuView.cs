using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Commands;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField]private Button _playBtn;
        [SerializeField]private Button _optionsBtn;
        //[SerializeField]private Button _mapsView;

        protected override void Start()
        {
            base.Start();

            _playBtn.onClick.AddListener(OnPLayClick);
            _optionsBtn.onClick.AddListener(OnOptionsClick);
            //_mapsView.onClick.AddListener(OnMapsClick);
        }

        private void OnPLayClick()
        {
            StartLevelCommand startLevelCommand = new StartLevelCommand(1);
            startLevelCommand.Execute();

            CloseView();
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
            
        }

        //private void OnMapsClick()
        //{
        //    ViewManager.Instance.SetView("MapsView");
        //}
    }
}
