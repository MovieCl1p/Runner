using UnityEngine;
using Core;
using Core.Binder;
using Game.Player.Control;
using System;
using Game.Commands;
using Core.Dispatcher;
using Game.Events;
using Game.Components.Level;

namespace Game.Player
{
    public class PlayerController : MonoScheduledBehaviour
    {
        [SerializeField]
        private Transform _bot;
        
        [SerializeField]
        private LayerMask _groundMask;

        [SerializeField]
        private PlayerView _view;
        
        public float HorizontalMinSpeed = 35;
        public float HorizontalAccelForce = 35;
        public float HorizontalSlowSpeed = 1;
        public float JumpPressedSlowDownSpeed = 1.3f;
        public float JumpForce = 32;
        public float MaxJumpAccelTime = 0.2f;
        public float Gravity = -1.5f;


        private bool _active = true;

        private int _currentColor = 16;
        private int _currentColorK = -1;

        
        private IDispatcher _dispatcher;
        private IPlayerControl _control;

        private MovementComponent _move;
        private ColorChecker _colorChecker;

        protected override void Awake()
        {
            base.Awake();

            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnJumpClick += OnJumpClick;
            _control.OnChangeColorClick += OnChangeColor;

            _dispatcher = BindManager.GetInstance<IDispatcher>();

            _colorChecker = new ColorChecker(CachedTransform);

            _move = new MovementComponent(this, _bot, _groundMask);
        }
        
        public void Accelerate()
        {
            _move.Accelerate();
        }

        protected void FixedUpdate()
        {
            if(!_active)
            {
                return;
            }

            _move.HorizontalMinSpeed = HorizontalMinSpeed;
            _move.HorizontalAccelForce = HorizontalAccelForce;
            _move.HorizontalSlowSpeed = HorizontalSlowSpeed;
            _move.JumpPressedSlowDownSpeed = JumpPressedSlowDownSpeed;
            _move.JumpForce = JumpForce;
            _move.MaxJumpAccelTime = MaxJumpAccelTime;
            _move.Gravity = Gravity;

            _move.Update(Time.deltaTime, _control.IsJumpPressed);
        }
        
        public void Activate(bool v)
        {
            _active = v;
        }
        
        private void OnJumpClick()
        {
            _move.OnJump();
        }

        private void OnChangeColor()
        {
            _currentColorK *= -1;
            _currentColor += _currentColorK;

            _view.ChangeColor(_currentColorK);
        }
        
        public void CheckColor(Transform platform)
        {
            var result = _colorChecker.CheckColor(_currentColor, platform);
            if(!result)
            {
                _dispatcher.Dispatch(LevelEventsEnum.Restart);
                return;
            }
        }

        public void EmitTrail(bool v)
        {
            _view.EmitTrail(v);
        }

        public void EmitTrailInAir(bool isJumpPressed)
        {
            _view.EmitTrailInAir(isJumpPressed);
        }

        private void CreateParticles(float maxDist)
        {
            _view.EmitParticles(maxDist);
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _control.OnJumpClick -= OnJumpClick;
            _control.OnChangeColorClick -= OnChangeColor;
        }

        public void Reset(Vector3 startPosition)
        {
            CachedTransform.position = startPosition;
            _move.Reset();

            _currentColor = 16;
            _currentColorK = -1;

            _view.ChangeColor(_currentColorK);

            _active = false;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            _move.CollisionEnter(other);
        }

        public void OnTriggerExit(Collider other)
        {
            _move.CollisionExit(other);
        }

        public void OnTriggerStay(Collider other)
        {
            _move.CollisionStay(other);
        }

        public void ChangeColor(PlayerColors color)
        {
            int newColor = color == PlayerColors.First ? -1 : 1;
            _view.ChangeColor(newColor);

            _currentColorK = newColor;
            _currentColor = color == PlayerColors.First ? 16 : 17;
        }
    }
}
