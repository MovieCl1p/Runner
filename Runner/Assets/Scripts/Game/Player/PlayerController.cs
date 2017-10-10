using UnityEngine;
using Core;
using Core.Binder;
using Game.Player.Control;
using System;
using Game.Commands;
using Core.Dispatcher;
using Game.Events;

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

        private float _horizontalSpeed = 8;
        private float _verticalSpeed = 0;

        private float _gravity = 0.5f;

        private float _jumpForce = 20;
        private float _jumpUpSpeed = 0.1f;
        private float _jumpDownSpeed = 0.5f;
        
        private bool _jump;
        private bool _inAir;
        private bool _grounded;
        private bool _doubleJump;
        private bool _canDoubleJump;

        private bool _active = true;

        private int _currentColor = 16;
        private int _currentColorK = -1;

        private ColorChecker _colorChecker;
        private IDispatcher _dispatcher;
        private IPlayerControl _control;

        protected override void Start()
        {
            base.Start();

            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnJumpClick += OnJumpClick;
            _control.OnChangeColorClick += OnChangeColor;

            _dispatcher = BindManager.GetInstance<IDispatcher>();

            _colorChecker = new ColorChecker();
        }
        
        public void Reset(Vector3 startPosition)
        {
            CachedTransform.position = startPosition;
            _verticalSpeed = 0;
            _jump = false;
            _inAir = false;
            _grounded = false;
            _doubleJump = false;
            _canDoubleJump = false;

            _currentColor = 16;
            _currentColorK = -1;

            _view.ChangeColor(_currentColorK);

            _active = false;
        }
        
        protected void FixedUpdate()
        {
            if(!_active)
            {
                return;
            }

            _grounded = false;
            
            Ray ray = new Ray(_bot.transform.position, -_bot.transform.up);
            RaycastHit hit;

            Debug.DrawRay(_bot.transform.position, -_bot.transform.up, Color.red);

            if(Physics.Raycast(ray, out hit, _groundMask))
            {
                float maxDist = Mathf.Max(0.3f, Mathf.Abs(0.028f * _verticalSpeed));
                
                if (hit.distance < maxDist)
                {
                    _grounded = true;
                    _inAir = false;
                    _canDoubleJump = true;
                    CheckColor(hit.transform.gameObject.layer);
                }
                else
                {
                    _inAir = true;
                }
            }

            Move(1, _jump);
            _jump = false;
            _doubleJump = false;
        }
        
        public void Activate(bool v)
        {
            _active = v;
        }

        private void Move(float move, bool jump)
        {
            if(_grounded)
            {
                _verticalSpeed = 0;
            }
            else
            {
                _verticalSpeed -= _gravity;
            }

            if (_grounded && jump)
            {
                _verticalSpeed = _jumpForce ;
                _inAir = true;
            }
            
            if(_inAir && _doubleJump)
            {
                _verticalSpeed = _jumpForce;
            }

            if (_inAir)
            {
                float jf = (_control.IsJumpPressed ? _jumpUpSpeed : _jumpDownSpeed);
                _verticalSpeed -= jf;
            }

            CachedTransform.Translate(_horizontalSpeed * Time.deltaTime, _verticalSpeed * Time.deltaTime, 0);

            _verticalSpeed -= _gravity;
            if(_verticalSpeed < -35)
            {
                _verticalSpeed = -35;
            }
        }

        private void OnJumpClick()
        {
            _jump = true;
            if(_inAir && _canDoubleJump)
            {
                _doubleJump = true;
                _canDoubleJump = false;
            }
        }

        private void OnChangeColor()
        {
            _currentColorK *= -1;
            _currentColor += _currentColorK;

            _view.ChangeColor(_currentColorK);
        }

        private void CheckColor(int layer)
        {
            var result = _colorChecker.CheckColor(_currentColor, layer);
            if(!result)
            {
                _dispatcher.Dispatch(LevelEventsEnum.RestartTrigerEntered.ToString());
                return;
            }


        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _control.OnJumpClick -= OnJumpClick;
            _control.OnChangeColorClick -= OnChangeColor;
        }
    }
}
