using System;
using NaughtyAttributes;

namespace _Game.Scripts
{
    [Serializable]
    public class GatePowerUp
    {
        public GatePowerUpType Type;
        [AllowNesting, ShowIf(nameof(IsAdd))]
        public int AdditionalAmount = 10;
        [AllowNesting, ShowIf(nameof(IsMultiply))]
        public int Multiplier = 2;

#if UNITY_EDITOR
        private bool IsAdd => Type == GatePowerUpType.AddCharacters;
        private bool IsMultiply => Type == GatePowerUpType.MultiplyCharacters;
#endif

        public void Apply(Crowd crowd)
        {
            switch (Type)
            {
                case GatePowerUpType.AddCharacters:
                    crowd.Refill(crowd.Count + AdditionalAmount);
                    break;
                case GatePowerUpType.MultiplyCharacters:
                    crowd.Refill(crowd.Count * Multiplier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum GatePowerUpType
    {
        AddCharacters,
        MultiplyCharacters
    }
}