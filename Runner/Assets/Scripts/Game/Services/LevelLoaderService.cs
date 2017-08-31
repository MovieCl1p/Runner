using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Services
{
    public class LevelLoaderService : ILevelLoaderService
    {
        public GameObject GetLevel(int levelId)
        {
            string levelName = "Level" + (levelId - 1); 
            GameObject go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Levels/" + levelName));
            return go;
        }
    }
}
