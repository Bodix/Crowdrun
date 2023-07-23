using Evolutex.Evolunity.Components;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputReader _inputReader;
    [SerializeField]
    private Crowd _crowd;

    private bool _isStarted;

    private void Awake()
    {
        _inputReader.Drag += input =>
        {
            TryStartGame();

            _crowd.Move(input.x);
        };

        _crowd.Refill(1);
    }

    private void TryStartGame()
    {
        if (!_isStarted)
        {
            _crowd.StartMoving();

            _isStarted = true;
        }
    }
}