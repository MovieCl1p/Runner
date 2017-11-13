using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Gui.Components
{
    public class ExtendedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnClick;
        public event Action OnPointDown;
        public event Action OnPointUp;

        public Button Button;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if(OnPointDown != null)
            {
                OnPointDown();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (OnPointUp != null)
            {
                OnPointUp();
            }
        }
        
        protected void Awake()
        {
            Button.onClick.AddListener(OnBtnClick);
        }

        private void OnBtnClick()
        {
            if (OnClick != null)
            {
                OnClick();
            }
        }
    }
}
