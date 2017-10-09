using Core.Binder;
using Core.Commands;
using Game.Model;
using UnityEngine;

namespace Game.Commands
{
    public class RestartLevelCommand : ICommand
    {
        public void Execute()
        {
            var levelModel = BindManager.GetInstance<LevelSessionModel>();

            levelModel.Player.transform.position = Vector3.zero;
        }
    }
}
