using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerView : BaseMonoBehaviour
    {
        [SerializeField]
        private List<Renderer> _renderers;

        [SerializeField]
        private ParticleSystem _firstParticle;

        [SerializeField]
        private ParticleSystem _secondParticle;

        [SerializeField]
        private Color _firstColor;

        [SerializeField]
        private Color _secondColor;
        
        
        private int _colorPropertyId;
        
        protected override void Start()
        {
            base.Start();

            _colorPropertyId = Shader.PropertyToID("_Color");
            
            ChangeColor(-1);
        }
        
        public void ChangeColor(int layer)
        {
            Color color = layer == -1 ? _firstColor : _secondColor;
            bool first = layer == -1;

            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].sharedMaterial.color = color;
            }
            
            if (first)
            {
                _firstParticle.Play();
                _secondParticle.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            else
            {
                _secondParticle.Play();
                _firstParticle.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}
