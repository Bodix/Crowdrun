using DG.Tweening;
using Evolutex.Evolunity.Extensions;
using TMPro;
using UnityEngine;

namespace Bodix.Crowdrun.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class CoinsCounterUi : MonoBehaviour
    {
        [SerializeField]
        private Game _game;
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private float _punchScaleAmount = 0.1f;
        [SerializeField]
        private float _punchAnimationDuration = 0.1f;

        private void Awake()
        {
            _game.CoinsUpdated += SetTextAnimated;
        }

        private void SetTextAnimated(int coins)
        {
            _text.text = coins.ToString();

            transform.ToRectTransform().DOPunchScale(
                new Vector3(_punchScaleAmount, _punchScaleAmount, _punchScaleAmount), 
                _punchAnimationDuration);
        }
    }
}