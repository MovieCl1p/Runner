using UnityEngine;

namespace Game.Player
{
    public class MovementComponent
    {
        private const int MaxFallSpeed = -40;

        private const float HorizontalMinSpeed = 20;
        private const float HorizontalAccelForce = 20;
        private const float HorizontalSlowSpeed = 1;

        private const float JumpPressedSlowDownSpeed = 1f;
        private const float JumpSlowDownSpeed = 1.0f;
        private const float JumpForce = 24;

        private const float MaxJumpAccelTime = 0.1f;

        private const float Gravity = -1.2f;

        private int _color1;
        private int _color2;
        private int _colorRestart;

        private PlayerController _player;
        private Transform _raycastTransform;
        private LayerMask _groundMask;
        
        private float _horizontalSpeed = 50;
        private float _verticalSpeed = 0;
        
        private float _jumpAccelTime = 0;
        
        private float _currentVerticalAccell = 0;
        private float _currentHorizontalAccell = 0;
        
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

            _color1 = LayerMask.NameToLayer("LevelColor1");
            _color2 = LayerMask.NameToLayer("LevelColor2");
            _colorRestart = LayerMask.NameToLayer("LevelColorRestart");
        }

        public void Accelerate()
        {
            _horizontalSpeed += HorizontalAccelForce;
        }
        
        public void Update(float deltaTime, bool isJumpPressed)
        {
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

            if (_grounded && jump)
            {
                _inAir = true;
                _wasJumping = true;
                AddAccells();
            }

            if (_inAir && _doubleJump)
            {
                AddAccells();
            }
            
            if (_inAir)
            {
                _jumpAccelTime += Time.deltaTime;
                _currentVerticalAccell -= JumpPressedSlowDownSpeed;

                if (isJumpPressed)
                {   
                    if (_jumpAccelTime < MaxJumpAccelTime)
                    {
                        _verticalSpeed = Mathf.Lerp(_verticalSpeed, _currentVerticalAccell, _jumpAccelTime / MaxJumpAccelTime);
                        _horizontalSpeed = Mathf.Lerp(_horizontalSpeed, _currentHorizontalAccell, _jumpAccelTime / MaxJumpAccelTime);
                    }
                }
                
                _player.EmitTrailInAir(isJumpPressed);
            }

            _player.CachedTransform.Translate(_horizontalSpeed * deltaTime, _verticalSpeed * deltaTime, 0);

            _verticalSpeed += Gravity;
            if (_verticalSpeed < MaxFallSpeed)
            {
                _verticalSpeed = MaxFallSpeed;
            }

            _horizontalSpeed -= HorizontalSlowSpeed;
            if(_horizontalSpeed < HorizontalMinSpeed)
            {
                _horizontalSpeed = HorizontalMinSpeed;
            }
        }

        public void CollisionStay(Collider other)
        {
            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1 || collisionLayer == _color2 || collisionLayer == _colorRestart)
            {
                _player.CheckColor(other.transform);
            }
        }

        public void CollisionExit(Collider other)
        {
            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1 || collisionLayer == _color2)
            {
                _inAir = true;
                _grounded = false;
            }
        }

        public void CollisionEnter(Collider other)
        {   
            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1 || collisionLayer == _color2 || collisionLayer == _colorRestart)
            {
                _grounded = true;
                _inAir = false;
                _canDoubleJump = true;
                
                if (_wasJumping)
                {
                    _player.EmitTrail(true);
                    _wasJumping = false;
                }

                Vector3 pos = other.ClosestPoint(_raycastTransform.position);
                if (pos.y < other.bounds.max.y)
                {
                    pos.y = other.bounds.max.y;
                }
                
                _player.CachedTransform.position = pos - _raycastTransform.localPosition;

                _player.CheckColor(other.transform);
            }
        }

        public void Reset()
        {
            _horizontalSpeed = 0;
            _verticalSpeed = 0;

            _jump = false;
            _inAir = false;
            _grounded = false;
            _doubleJump = false;
            _canDoubleJump = true;

            _jumpAccelTime = 0;
            _currentVerticalAccell = 0;
            _currentHorizontalAccell = 0;
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

        private void AddAccells()
        {
            _jumpAccelTime = 0;
            _currentVerticalAccell = JumpForce;
            _currentHorizontalAccell = HorizontalAccelForce;
        }
    }
}
