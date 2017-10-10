using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    public class LevelController : BaseMonoBehaviour
    {
        [SerializeField]
        private Transform _startPosition;

        public Vector3 StartPosition { get { return _startPosition.position; } }
    }
}
