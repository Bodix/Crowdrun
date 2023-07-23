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
    private float _forwardSpeed = 3;
    [SerializeField]
    private float _directionalSpeed = 1;

    [SerializeField]
    private Character _characterPrefab;
    [SerializeField]
    private Transform _crowdContainer;

    private readonly List<Character> _characters = new(512);
    private const float SpiralRatio = 0.5f;

    private void Awake()
    {
        _inputReader.Drag += input => Move(input.x);

        for (int i = 0; i < _charactersCount; i++)
        {
            _characters.Add(Instantiate(_characterPrefab, GetSpawnPosition(i), Quaternion.identity, _crowdContainer)
                .Initialize(_forwardSpeed, _directionalSpeed));
        }

        foreach (Character character in _characters)
        {
            character.Move(Random.value);
        }
    }

    private void Move(float input)
    {
        foreach (Character character in _characters)
        {
            character.Move(input);
        }
    }

    /// <summary>
    /// Parametric equation of the spiral.
    /// http://old.exponenta.ru/soft/others/stud1/main.asp#:~:text=%D0%9F%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%BE%D0%B5%20%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5%3A,%D1%81%D0%BE%D0%B2%D0%BF%D0%B0%D0%B4%D0%B0%D0%B5%D1%82%20%D1%81%20%D1%86%D0%B5%D0%BD%D1%82%D1%80%D0%BE%D0%BC%20%D0%B2%D1%80%D0%B0%D1%89%D0%B5%D0%BD%D0%B8%D1%8F%20%D0%BF%D1%80%D1%8F%D0%BC%D0%BE%D0%B9.
    /// </summary>
    private Vector3 GetSpawnPosition(int index)
    {
        float t = index * SpiralRatio;
        float x = t * Mathf.Cos(t);
        float y = t * Mathf.Sin(t);

        return new Vector3(x, 0, y);
    }
}