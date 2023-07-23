using UnityEngine;

namespace BattleJourney.Gameplay
{
    public class SpecialFx : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private AudioSource _audioSource;

        public void Play()
        {
            _particleSystem.Play();
            if (_audioSource && _audioSource.clip)
                _audioSource.Play();
        }
    }
}