﻿
using Core.ViewManager;
using Game.Data;

namespace Game.Commands
{
    public class StartCommand
    {

        public void Execute()
        {
            ViewManager.Instance.Init();

            RegisterViews();
        }

        private void RegisterViews()
        {
            ViewManager.Instance.RegisterView(ViewNames.SplashScreen, LayerNames.ScreenLayer, "Screens");
            ViewManager.Instance.RegisterView(ViewNames.MainMenuScreen, LayerNames.ScreenLayer, "Screens");
            ViewManager.Instance.RegisterView(ViewNames.GameHudView, LayerNames.ScreenLayer, "Screens");


            ViewManager.Instance.RegisterView(ViewNames.GameView, LayerNames.ThreeDLayer, "GameView");


            //ViewManager.Instance.RegisterView(ViewNames.LoaderWindow, LayerNames.WindowLayer, "Windows");
        }
    }
}
