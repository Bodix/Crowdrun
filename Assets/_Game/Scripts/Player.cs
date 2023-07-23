using System.Collections.Generic;
using _Game.Scripts;
using Evolutex.Evolunity.Components;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputReader _inputReader;
    [SerializeField]
    private int _charactersCount = 5;
    [SerializeField]
    private float _distanceBetweenCharacters = 0.4f;
    [SerializeField]
    private float _forwardSpeed = 3;
    [SerializeField]
    private float _directionalSpeed = 1;

    [SerializeField]
    private Character _characterPrefab;
    [SerializeField]
    private Transform _crowdContainer;

    private readonly List<Character> _characters = new(512);

    private void Awake()
    {
        _inputReader.Drag += input => Move(input.x);

        for (int i = 0; i < _charactersCount; i++)
        {
            Vector2 position = GetPhyllotaxisPosition(i, _distanceBetweenCharacters);
            _characters.Add(Instantiate(
                    _characterPrefab,
                    new Vector3(position.x, transform.position.y, position.y),
                    Quaternion.identity,
                    _crowdContainer)
                .Initialize(_forwardSpeed, _directionalSpeed));
        }
    }

    private void Move(float input)
    {
        transform.Translate(new Vector3(input * _directionalSpeed * 0.01f, 0, 0));
    }

    /// <summary>
    /// https://www.youtube.com/watch?v=YCFt0L5KNWE
    /// </summary>
    public Vector2 GetPhyllotaxisPosition(int count, float scale = 0.5f, float degree = 137.5f)
    {
        float angle = count * (degree * Mathf.Deg2Rad);
        float radius = scale * Mathf.Sqrt(count);

        return GetCirclePosition(radius, angle);
    }

    /// <summary>
    /// Parametric equation of the circle.
    /// </summary>
    public Vector2 GetCirclePosition(float radius, float angle)
    {
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    /// <summary>
    /// Parametric equation of the spiral.
    /// </summary>
    private Vector2 GetSpiralPosition(int count, float ratio)
    {
        float radius = count * ratio;
        float x = radius * Mathf.Cos(radius);
        float y = radius * Mathf.Sin(radius);

        return new Vector2(x, y);
    }
}