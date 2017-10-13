using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Commands;
using System;

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
            StartLevelCommand startLevelCommand = new StartLevelCommand(1);
            startLevelCommand.Execute();

            CloseView();
        }

        private void OnOptionsClick()
        {
            ViewManager.Instance.SetView(ViewNames.OptionsView);
            
        }

        private void OnChaptersViewsClick()
        {
            ViewManager.Instance.SetView(ViewNames.ChapterView);
        }
        
    }
}
