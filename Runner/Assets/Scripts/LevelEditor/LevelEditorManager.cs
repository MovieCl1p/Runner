using Game.Components.Level;
using Game.Config.Levels;
using LevelEditor.Commands;
using LevelEditor.Data;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LevelEditor
{
    public class LevelEditorManager : MonoBehaviour
    {
        [SerializeField] private Material _materialColor1;
        [SerializeField] private Material _materialColor2;
        [SerializeField] private Material _materialColor3;
        [SerializeField] private Material _materialColor4;

        private int _layerColor1;
        private int _layerColor2;
        private int _layerColor3;
        private int _layerColor4;

        [SerializeField] private List<LevelConfig> _listLevels;

        private int _levelIndex;

        private string inputLevel = "8";
        private levelcontroller _currentLevel;

        private void Start()
        {
            _listLevels = new List<LevelConfig>();
            _layerColor1 = LayerMask.NameToLayer("LevelColor1");
            _layerColor2 = LayerMask.NameToLayer("LevelColor2");
            _layerColor3 = LayerMask.NameToLayer("LevelColorRestart");
            _layerColor4 = LayerMask.NameToLayer("EnvLayer");
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 100, 100), "Load Level"))
            {
                string[] guids = AssetDatabase.FindAssets("t:LevelConfig", null);

                foreach (string guid in guids)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guid);
                    var obj = AssetDatabase.LoadAssetAtPath<LevelConfig>(path);
                    _listLevels.Add(obj);
                }
            }

            inputLevel = GUI.TextField(new Rect(130, 10, 50, 50), inputLevel, 100);

            int index;

            if (int.TryParse(inputLevel, out index))
            {
                if (GUI.Button(new Rect(10, 120, 200, 100), "level loading to scene"))
                {
                    GameObject levelGo = GameObject.Instantiate(_listLevels[index].LevelPrefab);
                    _currentLevel = levelGo.GetComponent<levelcontroller>();
                }

                if (GUI.Button(new Rect(200, 10, 200, 100), "Load level from json \n on scene"))
                {

                    string jsonString = File.ReadAllText(Application.dataPath + "/Content/Levels/Level.json");

                    LoadLevel(jsonString);

                }

                if (GUI.Button(new Rect(500, 10, 200, 100), "Save Level in json"))
                {

                    Level = new Level();
                    Level.Objects = new List<LevelObject>();

                    SaveLevel(_currentLevel.transform);

                    string jsonString = JsonUtility.ToJson(Level);

                    WriteDataToFile(jsonString);

                }

                if (GUI.Button(new Rect(800, 10, 100, 100), "Start Game"))
                {
                    StartLevelEditorCommand command = new StartLevelEditorCommand(_currentLevel);
                    command.Execute();

                }

                if (GUI.Button(new Rect(10, 300, 150, 100), "Validate Platform"))
                {
                    //LoadLevel(jsonString);

                }
            }
        }

        public GameObject TestObject;
        public Level Level;

        private void SaveLevel(Transform parent)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                SaveLevel(parent.transform.GetChild(i));
            }

            Level.AddObject(parent);
        }

        public static void WriteDataToFile(string jsonString)
        {

            string path = Application.dataPath + "/Content/Levels/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(path + "Level.json", jsonString);
        }

        private void LoadLevel(string jsonString)
        {

            Level level = JsonUtility.FromJson<Level>(jsonString);

            GameObject root = new GameObject("LevelRoot");

            for (int i = 0; i < Level.Objects.Count; i++)
            {
                LevelObject levelObj = Level.Objects[i];

                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

                obj.transform.SetParent(root.transform, true);

                obj.transform.position = new Vector3(levelObj.PositionX, levelObj.PositionY, levelObj.PositionZ);
                obj.transform.localScale = new Vector3(levelObj.ScaleX, levelObj.ScaleY, levelObj.ScaleZ);
                obj.transform.rotation = Quaternion.Euler(new Vector3(levelObj.RotationX, levelObj.RotationY, levelObj.RotationZ));

                obj.layer = levelObj.LevelLayer;

                if (obj.layer == _layerColor1)
                {
                    obj.GetComponent<MeshRenderer>().material = _materialColor1;
                }

                if (obj.layer == _layerColor2)
                {
                    obj.GetComponent<MeshRenderer>().material = _materialColor2;
                }

                if (obj.layer == _layerColor3)
                {
                    obj.GetComponent<MeshRenderer>().material = _materialColor3;
                }

                if (obj.layer == _layerColor4)
                {
                    obj.GetComponent<MeshRenderer>().material = _materialColor4;
                }
            }
        }

        private void ValidatePlatform(Transform platform)
        {
            for (int i = 0; i < Level.Objects.Count; i++)
            {
                
                LevelObject levelObj = Level.Objects[i];
                
                
                SaveLevel(platform.transform.GetChild(i));

            }
        }
    }
}
