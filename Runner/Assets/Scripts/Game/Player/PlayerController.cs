using UnityEngine;
using Core;
using Core.Binder;
using Game.Player.Control;

namespace Game.Player
{
    public class PlayerController : BaseMonoBehaviour
    {
        [SerializeField]
        private Transform _bot;

        [SerializeField]
        private Rigidbody _rb;

        [SerializeField]
        private CharacterController __characterController;

        private IPlayerControl _control;

        [SerializeField]
        private LayerMask _groundMask;

        private float _maxSpeed = 1f;
        private float _jumpForce = 400f;

        private bool _jump;
        private bool _inAir;
        private bool _grounded;

        protected override void Start()
        {
            base.Start();

            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnJumpClick += OnJumpClick;
        }

        private void OnJumpClick()
        {
            _jump = true;
        }

        protected void Update()
        {
            //if (!_jump)
            //{
            //    _jump = Input.GetButtonDown("Jump");
            //}
        }
        
        protected void FixedUpdate()
        {
            _grounded = false;
            
            Collider[] colliders = Physics.OverlapSphere(_bot.position, 0.2f, _groundMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != _bot.gameObject)
                {
                    _grounded = true;
                    if(_rb.velocity.y < 0)
                    {
                        _inAir = false;
                    }
                    break;
                }
            }

            Move(1, _jump);
            _jump = false;
        }

        public void Move(float move, bool jump)
        {
            if (_grounded)
            {
                _rb.velocity = new Vector2(move * _maxSpeed, _rb.velocity.y);   
            }

            if (_grounded && jump)
            {
                _grounded = false;
                _rb.AddForce(new Vector2(0f, _jumpForce));
                _inAir = true;
            }

            if(_inAir)
            {
                if (_rb.velocity.y > 0)
                {
                    _rb.velocity += Vector3.up * Physics.gravity.y * (1.5f) * Time.deltaTime;
                }
                else
                {
                    _rb.velocity += Vector3.up * Physics.gravity.y * (1) * Time.deltaTime;
                }
            }
        }

    }
}
