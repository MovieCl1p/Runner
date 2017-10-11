using Core;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Player
{
    public class PlayerView : BaseMonoBehaviour
    {
        [SerializeField]
        private List<Renderer> _renderers;

        [SerializeField]
        private ParticleSystem _groundParticles;

        [SerializeField]
        private ParticleSystem _firstParticle;

        [SerializeField]
        private ParticleSystem _secondParticle;

        [SerializeField]
        private Color _firstColor;

        [SerializeField]
        private Color _secondColor;

        private ParticleSystem _activeTrail;

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

            SwitchTrail(first);

            
        }

        public void EmitParticles(float maxDist)
        {
            _groundParticles.Emit(4);
        }

        public void EmitTrail(bool active)
        {
            Debug.Log(active);

            if(_activeTrail != null)
            {
                if(active)
                {
                    _activeTrail.Play();
                }
                else
                {
                    _activeTrail.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                }
            }
        }

        private bool _lastAirActive = false;

        public void EmitTrailInAir(bool active)
        {
            if(_lastAirActive != active)
            {
                EmitTrail(active);
                _lastAirActive = active;
            }
        }


        private void SwitchTrail(bool first)
        {
            if (_activeTrail != null)
            {
                _activeTrail.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }

            _activeTrail = first ? _firstParticle : _secondParticle;
        }
    }
}
