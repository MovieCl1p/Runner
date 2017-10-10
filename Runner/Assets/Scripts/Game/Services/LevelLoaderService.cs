using Game.Level;
using Game.Services.Interfaces;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Services
{
    public class LevelLoaderService : ILevelLoaderService
    {
        private string _sceneName;
        private Action _callback;

        public LevelController GetLevel(int levelId, Transform parent = null, Action callback = null)
        {
            LevelController levelPrefab = Resources.Load<LevelController>("Levels/" + "Level" + levelId);
            if(levelPrefab == null)
            {
                Debug.LogError("There is no level with id: " + levelId);
                return null;
            }

            LevelController result = GameObject.Instantiate<LevelController>(levelPrefab);

            return result;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if(arg0.name == _sceneName)
            {
                if(_callback != null)
                {
                    _callback();
                }
            }
        }
    }
}
