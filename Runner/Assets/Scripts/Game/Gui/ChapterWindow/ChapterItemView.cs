using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gui.ChapterWindow
{
    public class ChapterItemView : BaseMonoBehaviour
    {
        public event Action<int> OnClick;

        [SerializeField]
        private Text _levelName;

        [SerializeField]
        private Button _btn;

        private int _chapterId;

        protected override void Start()
        {
            base.Start();
            _btn.onClick.AddListener(OnBtnClick);
        }
        
        public void UpdateView(int chapterId)
        {
            _chapterId = chapterId;
            _levelName.text = "Level " + chapterId;
        }

        private void OnBtnClick()
        {
            if (OnClick != null)
            {
                OnClick(_chapterId);
            }
        }

        protected override void OnDestroy()
        {
            _btn.onClick.RemoveListener(OnBtnClick);
            base.OnDestroy();
        }
    }
}
