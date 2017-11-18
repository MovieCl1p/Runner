using Core;
using UnityEngine;

namespace Game.Components
{
    public class CameraSmoothFollow : BaseMonoBehaviour
    {
        public Transform target;
        public float smoothDampTime = 0.2f;
        public float verticalSmoothDampTime = 0.3f;
        
        public Vector3 cameraOffset;
        
        private Vector3 _smoothDampVelocity;
        private Vector3 _verticalSmoothDampVelocity;

        
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
            
            Vector3 horizontal = Vector3.SmoothDamp(CachedTransform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);
            Vector3 vertical = Vector3.SmoothDamp(CachedTransform.position, target.position - cameraOffset, ref _verticalSmoothDampVelocity, verticalSmoothDampTime);

            
            CachedTransform.position = new Vector3(horizontal.x, vertical.y, horizontal.z);
//            CachedTransform.position = Vector3.SmoothDamp(CachedTransform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);

        }
    }
}
