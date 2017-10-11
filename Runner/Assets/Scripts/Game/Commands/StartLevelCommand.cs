using Core.Binder;
using Core.Commands;
using Core.ViewManager;
using Game.Components.Level;
using Game.Data;
using Game.Factory;
using Game.Model;
using Game.Services.Interfaces;

namespace Game.Commands
{
    public class StartLevelCommand : ICommand
    {
        private LevelSessionModel _levelModel;

        public StartLevelCommand(int levelId)
        {
            _levelModel = BindManager.GetInstance<LevelSessionModel>();
            _levelModel.LevelId = levelId;
        }

        public void Execute()
        {
            var loaderService = BindManager.GetInstance<ILevelLoaderService>();
            LevelController level = loaderService.GetLevel(_levelModel.LevelId);

            var factory = BindManager.GetInstance<GameFactory>();
            var player = factory.GetPlayer();

            _levelModel.Player = player;
            _levelModel.Level = level;

            player.Reset(level.StartPosition);

            ViewManager.Instance.SetView(ViewNames.GameHudView);
            ViewManager.Instance.SetView(ViewNames.GameView);
        }
    }
}
