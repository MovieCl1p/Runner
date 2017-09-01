using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Services
{
    public class LevelLoaderService : ILevelLoaderService
    {
        public GameObject GetLevel(int levelId, Transform parent = null)
        {
            string levelName = "Level" + (levelId - 1); 
            GameObject go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Levels/" + levelName), parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            return go;
        }
    }
}
