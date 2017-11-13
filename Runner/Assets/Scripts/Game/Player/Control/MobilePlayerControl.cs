using Core.UnityUtils;
using Game.Gui.Components;
using Game.Player.Control;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

namespace Game.Player.Control
{
    public class MobilePlayerControl : IPlayerControl, IUpdateHandler
    {
        private PlayerControlView _playerView;
        
        public event Action OnJumpClick;

        public event Action OnChangeColorClick;

        private bool _jumpPress = false;

        public bool IsUpdating { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsJumpPressed
        {
            get
            {
                return _jumpPress;
            }
        }

        public MobilePlayerControl()
        {
            UpdateNotifier.Instance.Register(this);
        }
        
        public void OnUpdate()
        {
           
        }
        
        public void SetView(PlayerControlView playerControlView)
        {
            _playerView = playerControlView;

            _playerView.LeftButton.OnClick += OnChangeColor;
            _playerView.RightButton.OnClick += OnJump;
            _playerView.RightButton.OnPointDown += _jumpBtn_OnPointDown;
            _playerView.RightButton.OnPointUp += _jumpBtn_OnPointUp;
        }

        private void _jumpBtn_OnPointUp()
        {
            _jumpPress = false;
        }

        private void _jumpBtn_OnPointDown()
        {
            _jumpPress = true;
            if (OnJumpClick != null)
            {
                OnJumpClick();
            }
        }

        private void OnJump()
        {
            

            _jumpPress = false;
        }

        private void OnChangeColor()
        {
            if (OnChangeColorClick != null)
            {
                OnChangeColorClick();
            }
        }
    }
}
