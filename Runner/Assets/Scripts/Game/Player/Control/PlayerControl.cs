
using Core.UnityUtils;
using System;
using UnityEngine;

namespace Game.Player.Control
{
    public class PlayerControl : IPlayerControl, IUpdateHandler
    {
        public bool IsUpdating { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsJumpPressed
        {
            get
            {
                return _jumpPress;
            }
        }

        public event Action OnJumpClick;

        private bool _jumpPress = false;

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
        }

        private void CallJumpClick()
        {
            if(OnJumpClick != null)
            {
                OnJumpClick();
            }
        }
    }
}
