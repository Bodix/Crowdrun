using System;
using TMPro;
using UnityEngine;

namespace Bodix.Crowdrun
{
    [RequireComponent(typeof(MeshCollider))]
    public class Gate : MonoBehaviour, ICrowdTrigger
    {
        public PowerUp PowerUp;

        [SerializeField]
        private TextMeshPro _text;
        [SerializeField]
        private Gate _adjacentGate;

        private MeshCollider _collider;

        private void OnValidate()
        {
            SetText(_text, PowerUp);
        }

        private void Awake()
        {
            _collider = GetComponent<MeshCollider>();
        }

        public void Enter(Crowd crowd)
        {
            PowerUp.Apply(crowd);

            _adjacentGate.DisableCollider();
        }

        private void DisableCollider()
        {
            // May not be initialized if gate was disabled by game designer.
            if (_collider)
                _collider.enabled = false;
        }

        private void SetText(TextMeshPro text, PowerUp powerUp)
        {
            text.text = powerUp.Type switch
            {
                PowerUpType.AddCharacters => "+" + powerUp.AdditionalAmount,
                PowerUpType.MultiplyCharacters => "x" + powerUp.Multiplier,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}