using UnityEngine;
using Core;
using Core.Binder;
using Game.Player.Control;
using System;

namespace Game.Player
{
    public class PlayerController : MonoScheduledBehaviour
    {
        [SerializeField]
        private Transform _bot;
        
        private IPlayerControl _control;

        [SerializeField]
        private LayerMask _groundMask;

        private float _horizontalSpeed = 8;
        private float _verticalSpeed = 0;

        private float _gravity = 0.5f;

        private float _jumpForce = 20;
        private float _jumpUpSpeed = 0.1f;
        private float _jumpDownSpeed = 4f;
        
        private bool _jump;
        private bool _inAir;
        private bool _grounded;

        private bool _active = true;

        protected override void Start()
        {
            base.Start();

            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnJumpClick += OnJumpClick;
        }

        public void Reset(Vector3 startPosition)
        {
            CachedTransform.position = startPosition;
            _verticalSpeed = 0;
            _jump = false;
            _inAir = false;
            _grounded = false;

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
                if (hit.distance < 0.5f)
                {
                    _grounded = true;
                }

                if(_verticalSpeed < 0)
                {
                    _inAir = false;
                }
                
            }

            Move(1, _jump);
            _jump = false;
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
            
            if (_inAir)
            {
                float jf = (_control.IsJumpPressed ? _jumpUpSpeed : _jumpDownSpeed);
                _verticalSpeed -= jf;
            }

            CachedTransform.Translate(_horizontalSpeed * Time.deltaTime, _verticalSpeed * Time.deltaTime, 0);

            _verticalSpeed -= _gravity;
        }

        private void OnJumpClick()
        {
            _jump = true;
        }
    }
}
