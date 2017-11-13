using Game.Components.Level;
using System;
using UnityEngine;

namespace Game.Services.Interfaces
{
    public interface ILevelLoaderService
    {
        LevelController GetLevel(int episodeId, int levelId);
    }
}
