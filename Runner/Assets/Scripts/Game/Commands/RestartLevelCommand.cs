using System;
using System.Collections;
using Core.Binder;
using Core.Commands;
using Core.UnityUtils;
using Game.Model;
using UnityEngine;

namespace Game.Commands
{
    public class RestartLevelCommand : ICommand
    {
        private Transform _cameraTransform;

        public RestartLevelCommand(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform;
        }
        
        public void Execute()
        {
            var levelModel = BindManager.GetInstance<LevelSessionModel>();
            levelModel.Player.Reset(levelModel.Level.StartPosition);
            
            _cameraTransform.position = levelModel.Level.StartPosition;

            levelModel.Player.Activate(false);
            

            CoroutineHelper.Instance.StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(1);

            var levelModel = BindManager.GetInstance<LevelSessionModel>();
            levelModel.Player.Activate(true);
            levelModel.Player.Accelerate();
        }
    }
}
