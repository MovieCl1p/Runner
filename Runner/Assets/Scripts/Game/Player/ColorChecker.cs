
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
            ChangePlatformColor(platform);

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
                //if (_lastPlatform != null)
                //{
                    
                //}

                _lastPlatform = platform;
                //Renderer platformRenderer = _lastPlatform.GetComponent<Renderer>();
                //platformRenderer.material.color = Color.blue;
            }

            if (_lastPlatform != null)
            {
                Renderer platformRenderer = _lastPlatform.GetComponent<Renderer>();

                Vector3 playerLocalPosition = platform.InverseTransformPoint(_player.position);
                Debug.Log(playerLocalPosition.z);

                platformRenderer.material.SetFloat("_Fade", playerLocalPosition.z);

                float dx = platformRenderer.bounds.size.x / 2;

            }
        }
    }
}
