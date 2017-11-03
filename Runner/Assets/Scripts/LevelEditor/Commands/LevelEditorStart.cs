using Core.Commands;
using Core.ViewManager;
using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class LevelEditorStart : ICommand
    {
        public void Execute()
        {
            ViewManager.Instance.Init();
            ViewManager.Instance.RegisterView(ViewNames.LevelEditorView, LayerNames.ScreenLayer);
        }
    }
}
