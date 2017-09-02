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

        public GameObject GetLevel(int levelId, Transform parent = null, Action callback = null)
        {
            _sceneName = "Level" + levelId;
            _callback = callback;
            SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoaded;
            //string levelName = "Level" + (levelId - 1); 
            //GameObject go = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Levels/" + levelName), parent);
            //go.transform.localScale = Vector3.one;
            //go.transform.localPosition = Vector3.zero;
            //return go;
            return null;
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
