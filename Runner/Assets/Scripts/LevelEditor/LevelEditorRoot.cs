using Core;
using Core.ViewManager;
using Game.Commands;
using Game.Config;
using LevelEditor.Commands;
using LevelEditor.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    public class LevelEditorRoot : BaseMonoBehaviour
    {

        protected override void Start()
        {
            base.Start();

            LevelEditorConfig config = new LevelEditorConfig();
            config.AddBindings();

            LevelEditorStart start = new LevelEditorStart();
            start.Execute();
        }
    }
}
