using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

namespace Game.Gui.MainMenu
{
    public class MainMenuView : BaseView
    {
        [SerializeField]
        private Button _playBtn;

        protected override void Start()
        {
            base.Start();

            _playBtn.onClick.AddListener(OnPLayClick);
        }

        private void OnPLayClick()
        {
            ViewManager.Instance.SetView(ViewNames.GameHudView);

            ViewManager.Instance.SetViewToLayer(ViewNames.GameView, LayerNames.ThreeDLayer);
        }
    }
}
