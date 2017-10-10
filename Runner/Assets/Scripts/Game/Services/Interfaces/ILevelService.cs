using Game.Config.Episodes;
using Game.Config.Levels;
using System.Collections.Generic;

namespace Game.Services.Interfaces
{
    public interface ILevelService
    {
        List<LevelConfig> GetLevels();

        List<EpisodeConfig> GetEpisodes();
    }
}
