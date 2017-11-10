using Game.Components.Level;
using System;
using UnityEngine;

namespace Game.Services.Interfaces
{
    public interface ILevelLoaderService
    {
        levelcontroller GetLevel(int episodeId, int levelId);
    }
}
