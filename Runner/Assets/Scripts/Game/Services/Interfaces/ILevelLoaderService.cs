using System;
using UnityEngine;

namespace Game.Services.Interfaces
{
    public interface ILevelLoaderService
    {
        GameObject GetLevel(int levelId, Transform parent = null, Action callback = null);
    }
}
