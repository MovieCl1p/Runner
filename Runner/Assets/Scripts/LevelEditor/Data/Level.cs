using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor.Data
{
    [Serializable]
    public class Level
    {
        [SerializeField]
        public List<LevelObject> Objects;

        public void AddObject(Transform parent)
        {
            
            LevelObject obj = new LevelObject();

            obj.LevelLayer = parent.gameObject.layer;

            obj.PositionX = parent.position.x;
            obj.PositionY = parent.position.y;
            obj.PositionZ = parent.position.z;

            obj.RotationX = parent.rotation.x;
            obj.RotationY = parent.rotation.y;
            obj.RotationZ = parent.rotation.z;

            obj.ScaleX = parent.localScale.x;
            obj.ScaleY = parent.localScale.y;
            obj.ScaleZ = parent.localScale.z;

            Objects.Add(obj);
        }
    }
}
