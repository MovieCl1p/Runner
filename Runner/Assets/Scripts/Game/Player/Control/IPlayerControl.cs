using System;

namespace Game.Player.Control
{
    public interface IPlayerControl
    {
        bool IsJumpPressed { get; }

        event Action OnJumpClick;

        event Action OnChangeColorClick;
    }
}
