using Core.ViewManager;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;
using System.Collections.Generic;
using System;

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
                ChapterItemView item = Instantiate<ChapterItemView>(_item, _list);
                item.UpdateView(levels[i]);

                item.OnClick += OnEpisodeClick;

                _items.Add(item);
            }
        }
        
        private void OnEpisodeClick(int id)
        {
            //ViewManager.Instance.SetView(ViewNames.EpisodeOneView, id);
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