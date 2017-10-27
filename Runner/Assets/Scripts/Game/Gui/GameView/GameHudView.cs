using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Core.Binder;
using Game.Model;
using Game.Data;

namespace Game.Gui.GameView
{
    public class GameHudView : BaseView
    {
        [SerializeField] private Text _levelTime;

        [SerializeField] private Button _pauseBtn;
        
        private bool _paused;

        private LevelSessionModel _levelModel;

        protected override void Start()
        {
            base.Start();

            _pauseBtn.onClick.AddListener(OnPauseClick);

            _levelModel = BindManager.GetInstance<LevelSessionModel>();

            _levelTime.text = _levelModel.LevelTime.ToString();
        }

        private void OnPauseClick()
        {
            Time.timeScale = 0;
            
            ViewManager.Instance.SetView(ViewNames.PauseView);
        }

        protected override void Update()
        {
            base.Update();
            
            _levelTime.text = _levelModel.LevelTime.ToString();

        }
    }
}
