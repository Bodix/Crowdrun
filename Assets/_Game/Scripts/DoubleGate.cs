using System;
using _Game.Scripts;
using TMPro;
using UnityEngine;

public class DoubleGate : MonoBehaviour
{
    public GatePowerUp LeftGatePowerUp;
    public GatePowerUp RightGatePowerUp;
    public TextMeshPro LeftGateText;
    public TextMeshPro RightGateText;

    public void OnValidate()
    {
        SetText(LeftGateText, LeftGatePowerUp);
        SetText(RightGateText, RightGatePowerUp);
    }

    private void SetText(TextMeshPro text, GatePowerUp powerUp)
    {
        text.text = powerUp.Type switch
        {
            GatePowerUpType.AddCharacters => "+" + powerUp.AdditionalAmount,
            GatePowerUpType.MultiplyCharacters => "x" + powerUp.Multiplier,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
