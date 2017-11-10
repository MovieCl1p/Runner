using Core.Binder;
using Game.Components.Level;
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

        public levelcontroller GetLevel(int episodeId, int levelId)
        {
            var service = BindManager.GetInstance<ILevelService>();
            var episode = service.GetEpisode(episodeId);
            if(episode == null)
            {
                Debug.LogError("There is no episode with id: " + episodeId);
                return null;
            }

            var level = episode.GetLevel(levelId);

            if(level.LevelPrefab == null)
            {
                Debug.LogError("There is no level with id: " + levelId);
                return null;
            }

            GameObject levelGo = GameObject.Instantiate(level.LevelPrefab);
            levelcontroller result = levelGo.GetComponent<levelcontroller>();

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
