using Game.Services.Interfaces;
using System.Collections.Generic;
using Game.Config.Levels;
using System;
using UnityEngine;
using Game.Config.Episodes;

namespace Game.Services
{
    public class LevelService : ILevelService
    {
        private List<LevelConfig> _levels;
        private List<EpisodeConfig> _episodes;

        public List<LevelConfig> GetLevels()
        {
            if (_levels == null)
            {
                LoadLevels();
            }

            return _levels;
        }

        public List<EpisodeConfig> GetEpisodes()
        {
            if (_episodes == null)
            {
                LoadEpisodes();
            }

            return _episodes;
        }

        private void LoadEpisodes()
        {
            var episodes = Resources.LoadAll<EpisodeConfig>("Configs/Episodes/");
            if (episodes == null || episodes.Length == 0)
            {
                Debug.LogError("There is no configs for levels");
                return;
            }

            _episodes = new List<EpisodeConfig>(episodes);
        }

        private void LoadLevels()
        {
            var levels = Resources.LoadAll<LevelConfig>("Configs/Levels/");
            if (levels == null || levels.Length == 0)
            {
                Debug.LogError("There is no configs for levels");
                return;
            }

            _levels = new List<LevelConfig>(levels);
        }
    }
}
