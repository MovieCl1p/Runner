using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Events;
using UnityEngine;

namespace Game.Components.Triggers
{
    public class RestartTrigger : BaseMonoBehaviour
    {
        private IDispatcher _dispatcher;

        protected override void Start()
        {
            base.Start();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("RestartLayer"))
            {
                _dispatcher.Dispatch(LevelEventsEnum.RestartTrigerEntered.ToString());
            }
        }
    }
}
