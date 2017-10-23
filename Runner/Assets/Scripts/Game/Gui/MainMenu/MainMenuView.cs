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
        [SerializeField]private Button MapsView;
        [SerializeField]private Button VideoBtn;
        [SerializeField]private Button LiderBtn;

        protected override void Start()
        {
            base.Start();

            PlayBtn.onClick.AddListener(OnPLayClick);
            OptionsBtn.onClick.AddListener(OnOptionsClick);
            MapsView.onClick.AddListener(OnChaptersViewsClick);
            VideoBtn.onClick.AddListener(OnVideoViewClick);
            LiderBtn.onClick.AddListener(OnLiderBoardsViewClick);
        }

        private void OnLiderBoardsViewClick()
        {
            
        }

        private void OnVideoViewClick()
        {
           
        }
        
        private void OnPLayClick()
        {
            ViewManager.Instance.SetView(ViewNames.EpisodeView);
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
            
        }

        private void OnChaptersViewsClick()
        {
            ViewManager.Instance.SetView(ViewNames.EpisodeView);
        }
        
    }
}
