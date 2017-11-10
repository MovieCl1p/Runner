using Core;
using LevelEditor.Commands;
using LevelEditor.Configs;

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
