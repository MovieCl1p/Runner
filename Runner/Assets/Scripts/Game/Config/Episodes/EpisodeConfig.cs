using Game.Config.Levels;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Config.Episodes
{
    public class EpisodeConfig : ScriptableObject
    {
        public int EpisodeId;

        public string EpisodeName;

        public List<LevelConfig> Levels;

        public LevelConfig GetLevel(int levelId)
        {
            for (int i = 0; i < Levels.Count; i++)
            {
                if (Levels[i].LevelId == levelId)
                {
                    return Levels[i];
                }
            }

            return null;
        }
    }
}
