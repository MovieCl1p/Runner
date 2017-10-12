using Game.Config.Levels;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Config.Episodes
{
    public class EpisodeConfig : ScriptableObject
    {
        public int EpisodeId;

        public string EpisodeName;

        public List<LevelConfig> Levels;
    }
}
