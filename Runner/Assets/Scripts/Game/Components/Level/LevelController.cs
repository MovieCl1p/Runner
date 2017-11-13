using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Level
{
    public class LevelController : BaseMonoBehaviour
    {
        [SerializeField] private Transform _startPosition;

        [SerializeField] private int _playerColor;

        [SerializeField] private List<Renderer> _renderers;

        private Transform _lastPlatform;

        public Vector3 StartPosition { get { return _startPosition.position; } }
        

        public void UpdatePlayerPosition(Transform platform, Vector3 playerPosition)
        {
            if(_lastPlatform != platform)
            {
                if(_lastPlatform != null)
                {
                    Renderer platformRenderer = _lastPlatform.GetComponent<Renderer>();
                    platformRenderer.material.color = Color.blue;
                }

                _lastPlatform = platform;
                Checked(playerPosition);
            }
        }

        private void Checked(Vector3 playerPosition)
        {
            //Renderer platformRenderer = _lastPlatform.GetComponent<Renderer>();
            //platformRenderer.material.color = Color.green;
        }

    }
}
