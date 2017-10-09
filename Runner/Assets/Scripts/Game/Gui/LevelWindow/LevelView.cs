﻿using System;
using Core.ViewManager;
using Game.Commands;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using Game.Gui.ChapterWindow;
using System.Collections.Generic;

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

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            UpdateView(list);
        }

        public void UpdateView(List<int> levels)
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

        private void OnLevelClick(int id)
        {
            //ViewManager.Instance.SetView(ViewNames.EpisodeOneView, id);
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
