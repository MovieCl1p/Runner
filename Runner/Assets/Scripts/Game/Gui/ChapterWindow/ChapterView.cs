using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using System.Collections.Generic;
using System;
using Game.Services.Interfaces;
using Core.Binder;
using Game.Config.Levels;
using Game.Config.Episodes;

namespace Game.Gui.ChapterWindow
{
    public class ChapterView : BaseView
    {
        [SerializeField] private ChapterItemView _item;
        [SerializeField] private Transform _list;

        [SerializeField] private Button _backBtn;

        private List<ChapterItemView> _items = new List<ChapterItemView>();

        protected override void Start()
        {
            base.Start();

            var service = BindManager.GetInstance<ILevelService>();
            var episodes = service.GetEpisodes();
            
            UpdateView(episodes);
        }

        public void UpdateView(List<EpisodeConfig> episodes)
        {
            ClearList();

            for (int i = 0; i < episodes.Count; i++)
            {
                ChapterItemView item = Instantiate<ChapterItemView>(_item, _list);
                item.UpdateView(episodes[i]);

                item.OnClick += OnEpisodeClick;

                _items.Add(item);
            }
        }
        
        private void OnEpisodeClick(EpisodeConfig config)
        {
            ViewManager.Instance.SetView(ViewNames.LevelView, config);
        }

        protected override void OnDestroy()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick -= OnEpisodeClick;
            }

            base.OnDestroy();
        }

        private void ClearList()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                _items[i].OnClick -= OnEpisodeClick;
                Destroy(_items[i].gameObject);
            }
        }
    }
}