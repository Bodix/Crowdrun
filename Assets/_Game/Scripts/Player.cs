using Evolutex.Evolunity.Components;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputReader _inputReader;
    [SerializeField]
    private Crowd _crowd;

    private void Awake()
    {
        _inputReader.Drag += input => _crowd.Move(input.x);

        _crowd.Refill(1);
    }
}