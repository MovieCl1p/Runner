
using Core.UnityUtils;
using System;
using UnityEngine;

namespace Game.Player.Control
{
    public class PlayerControl : IPlayerControl, IUpdateHandler
    {
        public bool IsUpdating { get; set; }

        public bool IsRegistered { get; set; }

        public event Action OnJumpClick;

        public PlayerControl()
        {
            UpdateNotifier.Instance.Register(this);
        }

        public void OnUpdate()
        {
            if(Input.GetMouseButtonUp(0))
            {
                CallJumpClick();
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
