using Evolutex.Evolunity.Utilities;
using UnityEngine;

namespace Bodix.Crowdrun
{
    public class SpecialFx : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem[] _particleSystems;
        [SerializeField]
        private AudioSource _audioSource;

        public float AudioClipDuration => _audioSource.clip.length;

        public SpecialFx RemoveParentAndPlay()
        {
            transform.SetParent(null);

            Play();

            return this;
        }

        public SpecialFx Play()
        {
            foreach (ParticleSystem particleSystem in _particleSystems)
                particleSystem.Play();

            if (_audioSource && _audioSource.clip)
                _audioSource.Play();

            return this;
        }

        public SpecialFx Stop()
        {
            foreach (ParticleSystem particleSystem in _particleSystems)
                particleSystem.Stop();

            if (_audioSource && _audioSource.clip)
                _audioSource.Stop();

            return this;
        }

        public SpecialFx DestroyAfter(float seconds)
        {
            Delay.ForSeconds(seconds, () => Destroy(gameObject));

            return this;
        }

        public SpecialFx StopAfter(float seconds)
        {
            Delay.ForSeconds(seconds, () => Stop());

            return this;
        }
    }
}