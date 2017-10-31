using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animation animation;

        private void Awake()
        {
            animation = GetComponent<Animation>();
        }

        public void DidJump()
        {
            animation.Play(Tags.ANIMATION_JUMP);
            animation.PlayQueued(Tags.ANIMATION_JUMP_FALL);
        }

        public void DidLand()
        {
            animation.Stop(Tags.ANIMATION_JUMP_FALL);
            animation.Stop(Tags.ANIMATION_JUMP_LAND);
            animation.Blend(Tags.ANIMATION_JUMP_LAND, 0);
            animation.CrossFade(Tags.ANIMATION_RUN);
        }

        public void PlayerRun()
        {
            animation.Play(Tags.ANIMATION_RUN);
        }
    }
}