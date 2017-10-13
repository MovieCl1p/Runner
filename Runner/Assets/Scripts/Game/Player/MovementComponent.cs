﻿
using System;
using UnityEngine;

namespace Game.Player
{
    public class MovementComponent
    {
        private PlayerController _player;
        private Transform _raycastTransform;
        private LayerMask _groundMask;

        private float _horizontalMinSpeed = 25;
        private float _horizontalSpeed = 25;
        private float _verticalSpeed = 0;

        private float _horizontalAccelSpeed = 20;
        private float _horizontalSlowSpeed = 1;

        private float _gravity = 0.5f;

        private float _jumpForce = 20;
        private float _jumpUpSpeed = 0.1f;
        private float _jumpDownSpeed = 1.0f;

        private bool _jump;
        private bool _inAir;
        private bool _grounded;
        private bool _doubleJump;
        private bool _canDoubleJump;

        private bool _wasJumping;

        public bool InAir
        {
            get
            {
                return _inAir;
            }
        }

        public bool Grounded
        {
            get
            {
                return _grounded;
            }
        }

        public MovementComponent(PlayerController player, Transform raycastTransform, LayerMask layerMask)
        {
            _player = player;
            _raycastTransform = raycastTransform;
            _groundMask = layerMask;
        }

        public void Accelerate()
        {
            _horizontalSpeed += _horizontalAccelSpeed;
        }

        public void Update(float deltaTime, bool isJumpPressed)
        {
            _grounded = false;

            Ray ray = new Ray(_raycastTransform.position, -_raycastTransform.up);
            RaycastHit hit;

            Debug.DrawRay(_raycastTransform.position, -_raycastTransform.up, Color.red);

            if (Physics.Raycast(ray, out hit, _groundMask))
            {
                float maxDist = Mathf.Max(0.3f, Mathf.Abs(0.028f * _verticalSpeed));

                if (hit.distance < maxDist)
                {
                    _grounded = true;
                    _inAir = false;
                    _canDoubleJump = true;
                    _player.CheckColor(hit.transform);

                    if (_wasJumping)
                    {
                        _player.EmitTrail(true);
                        //CreateParticles(maxDist);
                        _wasJumping = false;
                    }
                }
                else
                {
                    _inAir = true;
                }
            }

            Move(1, _jump, deltaTime, isJumpPressed);
            _jump = false;
            _doubleJump = false;
        }
        
        private void Move(float move, bool jump, float deltaTime, bool isJumpPressed)
        {
            if (_grounded && _verticalSpeed < 0)
            {
                _verticalSpeed = 0;
            }
            else
            {
                _verticalSpeed -= _gravity;
            }

            if (_grounded && jump)
            {
                _verticalSpeed = _jumpForce;
                _inAir = true;
                _wasJumping = true;
            }

            if (_inAir && _doubleJump)
            {
                _verticalSpeed = _jumpForce;
            }

            if (_inAir)
            {
                float jf = (isJumpPressed ? _jumpUpSpeed : _jumpDownSpeed);
                _verticalSpeed -= jf;

                _player.EmitTrailInAir(isJumpPressed);
            }

            _player.CachedTransform.Translate(_horizontalSpeed * deltaTime, _verticalSpeed * deltaTime, 0);

            _verticalSpeed -= _gravity;
            if (_verticalSpeed < -35)
            {
                _verticalSpeed = -35;
            }

            _horizontalSpeed -= _horizontalSlowSpeed;
            if(_horizontalSpeed < _horizontalMinSpeed)
            {
                _horizontalSpeed = _horizontalMinSpeed;
            }
        }

        public void Reset()
        {
            _verticalSpeed = 0;
            _jump = false;
            _inAir = false;
            _grounded = false;
            _doubleJump = false;
            _canDoubleJump = false;
        }

        public void OnJump()
        {
            _jump = true;
            if (_inAir && _canDoubleJump)
            {
                _doubleJump = true;
                _canDoubleJump = false;
            }
        }
    }
}
