using TMPro;
using UnityEngine;

public class CrowdCounterUi : MonoBehaviour
{
    [SerializeField]
    private Crowd _crowd;
    [SerializeField]
    private TextMeshProUGUI _text;

    private int _prevCount;

    private void Update()
    {
        if (_crowd.Count != _prevCount)
        {
            _text.text = _crowd.Count.ToString();

            _prevCount = _crowd.Count;
        }
    }
}