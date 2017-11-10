using Core.UnityUtils;
using Game.Player.Control;
using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Game.Player.Control
{
    public class MobilePlayerControl : IPlayerControl, IUpdateHandler
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

        public MobilePlayerControl()
        {
            UpdateNotifier.Instance.Register(this);
        }
        
        public void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _jumpPress = true;
                CallJumpClick();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _jumpPress = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CallChangeColorClick();
            }
        }

        private void CallJumpClick()
        {
            if (OnJumpClick != null)
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
    }
}
