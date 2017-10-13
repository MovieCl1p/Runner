
using UnityEngine;

namespace Game.Player
{
    public class ColorChecker
    {
        private int _levelColorRestart;

        private Transform _player;
        private Transform _lastPlatform;

        public ColorChecker(Transform player)
        {
            _player = player;
            _levelColorRestart = LayerMask.NameToLayer("LevelColorRestart");
        }

        public bool CheckColor(int playerColor, Transform platform)
        {
            int colliderLayer = platform.gameObject.layer;
            //ChangePlatformColor(platform);

            if (colliderLayer == _levelColorRestart)
            {
                return false;
            }

            if (playerColor != colliderLayer)
            {
                return false;
            }

            return true;
        }

        private void ChangePlatformColor(Transform platform)
        {
            if (_lastPlatform != platform)
            {
                _lastPlatform = platform;
            }

            if (_lastPlatform != null)
            {
                Renderer platformRenderer = _lastPlatform.GetComponent<Renderer>();
                Vector3 playerLocalPosition = platform.InverseTransformPoint(_player.position);
                platformRenderer.material.SetFloat("_Fade", 2.5f);
            }
        }
    }
}
