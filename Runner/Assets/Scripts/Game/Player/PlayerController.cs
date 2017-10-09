using UnityEngine;
using Core;
using Core.Binder;
using Game.Player.Control;

namespace Game.Player
{
    public class PlayerController : MonoScheduledBehaviour
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

        private float _maxSpeed = 10f;
        private float _jumpForce = 700f;
        private float _jumpUpForce = 2f;
        private float _jumpDownForce = 8f;

        private bool _jump;
        private bool _inAir;
        private bool _grounded;

        private bool _active = true;

        protected override void Start()
        {
            base.Start();

            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnJumpClick += OnJumpClick;

            ScheduleUpdate(1);
        }

        protected override void OnScheduledUpdate()
        {
            _active = true;
        }

        private void OnJumpClick()
        {
            _jump = true;
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
                float jf = (_control.IsJumpPressed ? _jumpUpForce : _jumpDownForce) * Time.deltaTime * Physics.gravity.y;
                Vector3 dv = Vector3.up * jf;
                _rb.velocity += dv;
            }
        }


        public void OnTriggerEnter(Collider other)
        {
            
        }
    }
}
