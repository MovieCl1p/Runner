using System;
using Core.ViewManager;
using Game.Commands;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.LevelWindow
{
    public class LevelView : BaseView
    {
        [SerializeField] private Button PlayBtn;
        [SerializeField] private Button BackBtn;
        [SerializeField] private Button Map1Btn;

        protected override void Start()
        {
            base.Start();

            PlayBtn.onClick.AddListener(OnPLayClick);
            BackBtn.onClick.AddListener(OnBackClick);

            Map1Btn.onClick.AddListener(OnMap1Click);
        }

        private void OnMap1Click()
        {
            
        }

        private void OnBackClick()
        {
            //ViewManager.Instance.SetView(ViewNames.ChaptersViews);
        }

        private void OnPLayClick()
        {
            StartLevelCommand startLevelCommand = new StartLevelCommand(1);
            startLevelCommand.Execute();

            CloseView();
        }
    }
}
