using Core.Binder;
using Core.Commands;
using Core.ViewManager;
using Game.Data;
using Game.Model;

namespace Game.Commands
{
    public class StartLevelCommand : ICommand
    {
        public StartLevelCommand(int levelId)
        {
            var model = BindManager.GetInstance<LevelSessionModel>();
            model.LevelId = levelId;
        }

        public void Execute()
        {
            ViewManager.Instance.SetView(ViewNames.GameHudView);
            ViewManager.Instance.SetViewToLayer(ViewNames.GameView, LayerNames.ThreeDLayer);
        }
    }
}
