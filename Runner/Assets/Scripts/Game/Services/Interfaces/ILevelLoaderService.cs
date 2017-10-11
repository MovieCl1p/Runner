using Game.Components.Level;
using System;
using UnityEngine;

namespace Game.Services.Interfaces
{
    public interface ILevelLoaderService
    {
        LevelController GetLevel(int levelId, Transform parent = null, Action callback = null);
    }
}
