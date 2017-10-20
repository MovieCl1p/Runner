using Core.Commands;
using Core.ViewManager;
using Game.Data;

namespace Game.Commands
{
    public class StartCommand : ICommand
    {

        public void Execute()
        {
            ViewManager.Instance.Init();

            RegisterViews();
        }

        private void RegisterViews()
        {
            ViewManager.Instance.RegisterView(ViewNames.SplashScreen, LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.MainMenuScreen, LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.GameHudView, LayerNames.ScreenLayer);

            ViewManager.Instance.RegisterView(ViewNames.OptionsView, LayerNames.WindowLayer);
            ViewManager.Instance.RegisterView(ViewNames.EpisodeView, LayerNames.WindowLayer); 
            ViewManager.Instance.RegisterView(ViewNames.LevelView, LayerNames.WindowLayer);
            ViewManager.Instance.RegisterView(ViewNames.FinishItemView, LayerNames.WindowLayer);

            ViewManager.Instance.RegisterView(ViewNames.GameView, LayerNames.ThreeDLayer);
        }
    }
}
