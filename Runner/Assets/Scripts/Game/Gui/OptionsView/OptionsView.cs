using Core.ViewManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Game.Data;

namespace Game.Gui.OptionsView
{
    public class OptionsView : BaseView
    {
        [SerializeField] private Button _backBtn;

        [SerializeField] private Slider _soundVolume;

        [SerializeField] private AudioSource _audioSource;

        protected override void Start()
        {
            base.Start();

            _backBtn.onClick.AddListener(OnMainMenuClick);
        }

        private void OnMainMenuClick()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }

        protected override void Update()
        { 
            base.Update();

            _audioSource.volume = _soundVolume.value;
        }
    }
}