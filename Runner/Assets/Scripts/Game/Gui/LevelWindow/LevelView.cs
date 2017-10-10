using System;
using Core.ViewManager;
using Game.Commands;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Gui.ChapterWindow;
using System.Collections.Generic;
using Game.Config.Episodes;
using Game.Config.Levels;

namespace Game.Gui.LevelWindow
{
    public class LevelView : BaseView
    {
        [SerializeField] private LevelItemView _item;

        [SerializeField] private Transform _list;

        [SerializeField] private Button BackBtn;

        private List<LevelItemView> _items = new List<LevelItemView>();

        protected override void Start()
        {
            base.Start();

            EpisodeConfig config = (EpisodeConfig) Options;
            
            UpdateView(config.Levels);
        }

        public void UpdateView(List<LevelConfig> levels)
        {
            ClearList();

            for (int i = 0; i < levels.Count; i++)
            {
                LevelItemView item = Instantiate<LevelItemView>(_item, _list);

                item.UpdateView(levels[i]);

                item.OnClick += OnLevelClick;

                _items.Add(item);
            }
        }

        private void OnLevelClick(LevelConfig config)
        {
            CloseView();

            StartLevelCommand command = new StartLevelCommand(config.LevelId);
            command.Execute();
        }

        protected override void OnDestroy()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].OnClick -= OnLevelClick;
            }

            base.OnDestroy();
        }

        private void ClearList()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                _items[i].OnClick -= OnLevelClick;
                Destroy(_items[i].gameObject);
            }
        }
    }
}
