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
        [SerializeField] private Button BackBtn;

        protected override void Start()
        {
            base.Start();

            BackBtn.onClick.AddListener(OnMainMenuClick);
        }

        private void OnMainMenuClick()
        {
            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }
    }
}