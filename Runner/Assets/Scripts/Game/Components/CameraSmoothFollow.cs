using Core;
using UnityEngine;

namespace Game.Components
{
    public class CameraSmoothFollow : BaseMonoBehaviour
    {
        public Transform target;
        public float smoothDampTime = 0.2f;
        
        public Vector3 cameraOffset;
        
        private Vector3 _smoothDampVelocity;
        
        public void FixedUpdate()
        {
            UpdateCameraPosition();
        }
        
        public void UpdateCameraPosition()
        {
            if(target == null)
            {
                return;
            }

            CachedTransform.position = Vector3.SmoothDamp(CachedTransform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);


            //if (_playerController == null)
            //{
            //    transform.position = Vector3.SmoothDamp(transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);
            //    return;
            //}

            //if (_playerController.velocity.x > 0)
            //{
            //    transform.position = Vector3.SmoothDamp(transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);
            //}
            //else
            //{
            //    var leftOffset = cameraOffset;
            //    leftOffset.x *= -1;
            //    transform.position = Vector3.SmoothDamp(transform.position, target.position - leftOffset, ref _smoothDampVelocity, smoothDampTime);
            //}
        }
    }
}
