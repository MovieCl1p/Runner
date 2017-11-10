using Core.Binder;
using Core.Commands;
using Core.ViewManager;
using Game.Components.Level;
using Game.Data;
using Game.Factory;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class StartLevelEditorCommand : ICommand
    {
        private levelcontroller _currentLevel;
        private LevelSessionModel _levelModel;

        public StartLevelEditorCommand(levelcontroller level)
        {
            _currentLevel = level;
            _levelModel = BindManager.GetInstance<LevelSessionModel>();
        }

        public void Execute()
        {
            var factory = BindManager.GetInstance<GameFactory>();
            var player = factory.GetPlayer();

            _levelModel.Player = player;
            _levelModel.Level = _currentLevel;

            ViewManager.Instance.SetView(ViewNames.LevelEditorView);
        }
    }
}
