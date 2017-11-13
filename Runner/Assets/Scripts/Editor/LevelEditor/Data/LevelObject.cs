using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Data
{
    [Serializable]
    public class LevelObject
    {
        public int LevelLayer;
        public string ObjectName;

        public float PositionX;
        public float PositionY;
        public float PositionZ;

        public float RotationX;
        public float RotationY;
        public float RotationZ;

        public float ScaleX;
        public float ScaleY;
        public float ScaleZ;
    }
}
