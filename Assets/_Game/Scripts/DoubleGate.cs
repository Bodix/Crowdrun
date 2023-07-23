using System;
using _Game.Scripts;
using TMPro;
using UnityEngine;

public class DoubleGate : MonoBehaviour
{
    public PowerUp LeftGatePowerUp;
    public PowerUp RightGatePowerUp;
    public TextMeshPro LeftGateText;
    public TextMeshPro RightGateText;

    public void OnValidate()
    {
        SetText(LeftGateText, LeftGatePowerUp);
        SetText(RightGateText, RightGatePowerUp);
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
