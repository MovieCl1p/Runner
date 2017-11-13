
using Core.UnityUtils;
using System;
using UnityEngine;

namespace Game.Player.Control
{
    public class PlayerControl : IPlayerControl, IUpdateHandler
    {
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
        
        public PlayerControl()
        {
            UpdateNotifier.Instance.Register(this);
        }

        public void OnUpdate()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _jumpPress = true;
                CallJumpClick();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _jumpPress = false;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                CallChangeColorClick();
            }
        }

        private void CallJumpClick()
        {
            if(OnJumpClick != null)
            {
                OnJumpClick();
            }
        }

        private void CallChangeColorClick()
        {
            if (OnChangeColorClick != null)
            {
                OnChangeColorClick();
            }
        }

        public void SetView(PlayerControlView playerControlView)
        {
            
        }
    }
}
