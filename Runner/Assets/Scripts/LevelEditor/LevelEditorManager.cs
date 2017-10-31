using Game.Config.Levels;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor
{
    public class LevelEditorManager : MonoBehaviour
    {
        [SerializeField] private List<LevelConfig> _listLevels;

        private int _levelIndex;

        private string inputLevel = "Level Index";

        private void Start()
        {
            _listLevels = new List<LevelConfig>();
            
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Load Level"))
            {
                string[] guids = AssetDatabase.FindAssets("t:LevelConfig", null);

                foreach (string guid in guids)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guid);
                    var obj = AssetDatabase.LoadAssetAtPath<LevelConfig>(path);
                    _listLevels.Add(obj);
                }
            }

            inputLevel = GUI.TextField(new Rect(10, 130, 150, 50), inputLevel, 100);

            int index;
            if(int.TryParse(inputLevel, out index))
            {
                if (GUI.Button(new Rect(10, 200, 150, 100), "Load Level"))
                {
                    GameObject levelGo = GameObject.Instantiate(_listLevels[index].LevelPrefab);
                }
            }
        }
    }
}
