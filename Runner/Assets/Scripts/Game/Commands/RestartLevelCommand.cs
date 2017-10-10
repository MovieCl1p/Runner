using Core.Binder;
using Core.Commands;
using Game.Model;

namespace Game.Commands
{
    public class RestartLevelCommand : ICommand
    {
        public void Execute()
        {
            var levelModel = BindManager.GetInstance<LevelSessionModel>();
            levelModel.Player.Reset(levelModel.Level.StartPosition);

            levelModel.Player.Activate(true);
        }
    }
}
