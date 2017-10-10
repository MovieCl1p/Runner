
using UnityEngine;

namespace Game.Player
{
    public class ColorChecker
    {
        private int _levelColor1;
        private int _levelColor2;
        private int _levelColorRestart;

        public ColorChecker()
        {
            _levelColor1 = LayerMask.NameToLayer("LevelColor1");
            _levelColor1 = LayerMask.NameToLayer("LevelColor2");
            _levelColor1 = LayerMask.NameToLayer("LevelColorRestart");
        }

        public bool CheckColor(int playerColor, int colliderLayer)
        {
            if(colliderLayer == _levelColorRestart)
            {
                return false;
            }

            if (playerColor != colliderLayer)
            {
                return false;
            }

            return true;
        }
    }
}
