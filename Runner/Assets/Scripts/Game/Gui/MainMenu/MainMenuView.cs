using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField]private Button PlayBtn;
        [SerializeField]private Button OptionsBtn;

        protected override void Start()
        {
            base.Start();

            PlayBtn.onClick.AddListener(OnPLayClick);
            OptionsBtn.onClick.AddListener(OnOptionsClick);
        }
        
        private void OnPLayClick()
        {
            ViewManager.Instance.SetView(ViewNames.EpisodeView);
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
        }
    }
}
