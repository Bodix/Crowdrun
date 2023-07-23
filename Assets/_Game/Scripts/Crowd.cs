using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts;
using Evolutex.Evolunity.Extensions;
using Evolutex.Evolunity.Utilities;
using Evolutex.Evolunity.Utilities.Gizmos;
using Unity.VisualScripting;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    [SerializeField]
    private int _charactersCount = 5;
    [SerializeField]
    private float _distanceBetweenCharacters = 0.4f;
    [SerializeField]
    private float _forwardSpeed = 3;
    [SerializeField]
    private float _directionalSpeed = 1;
    [SerializeField]
    private float _maxMoveDistance = 10f;

    [SerializeField]
    private Character _characterPrefab;

    private readonly List<Character> _characters = new();
    private Character _mainCharacter;
    private float _width;

    public void Fill()
    {
        _characters.Clear();
        for (int i = 0; i < _charactersCount; i++)
        {
            // TODO: Improve spawn position logic.
            Vector2 position = _charactersCount switch
            {
                1 => transform.position,
                < 4 => GetCirclePosition(i, 0.5f),
                < 8 => GetCirclePosition(i, 0.8f),
                _ => MathUtilities.GetPhyllotaxisPosition(i, _distanceBetweenCharacters)
            };

            _characters.Add(Instantiate(
                    _characterPrefab,
                    new Vector3(position.x, transform.position.y, position.y),
                    Quaternion.identity,
                    transform)
                .Initialize(_forwardSpeed));
        }

        UpdateMainCharacter();
        UpdateWidth();
    }

    public void Move(float input)
    {
        transform.Translate(new Vector3(input * _directionalSpeed * 0.005f, 0));
        transform.position = transform.position.WithX(Mathf.Clamp(transform.position.x,
            -_maxMoveDistance + _width,
            _maxMoveDistance - _width));
    }

    private void UpdateMainCharacter()
    {
        if (_mainCharacter)
            Destroy(_mainCharacter.GetComponent<RedirectRootMotionToCrowd>());

        _mainCharacter = _characters[0];
        _mainCharacter.AddComponent<RedirectRootMotionToCrowd>().Initialize(this);
    }

    private void UpdateWidth()
    {
        _width = Mathf.Abs(_characters.Max(x => x.transform.position.x));
    }

    private Vector2 GetCirclePosition(int count, float radius)
    {
        float angle = 360 / _charactersCount * count * Mathf.Deg2Rad;

        return MathUtilities.GetCirclePosition(radius, angle);
    }

    private void OnDrawGizmosSelected()
    {
        GizmosExtend.DrawLine(
            transform.position.AddY(2),
            transform.position.AddY(2) + new Vector3(_width, 0, 0), Color.blue);
    }
}