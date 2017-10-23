using UnityEngine;

namespace Game.Config.Levels
{
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        public string LevelName;
        public int LevelId;
        public GameObject LevelPrefab;
    }
}
