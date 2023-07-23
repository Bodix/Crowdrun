using System;
using NaughtyAttributes;

namespace _Game.Scripts
{
    [Serializable]
    public class PowerUp
    {
        public PowerUpType Type;
        [AllowNesting, ShowIf(nameof(IsAdd))]
        public int AdditionalAmount = 10;
        [AllowNesting, ShowIf(nameof(IsMultiply))]
        public int Multiplier = 2;

#if UNITY_EDITOR
        private bool IsAdd => Type == PowerUpType.AddCharacters;
        private bool IsMultiply => Type == PowerUpType.MultiplyCharacters;
#endif

        public void Apply(Crowd crowd)
        {
            switch (Type)
            {
                case PowerUpType.AddCharacters:
                    crowd.Refill(crowd.Count + AdditionalAmount);
                    break;
                case PowerUpType.MultiplyCharacters:
                    crowd.Refill(crowd.Count * Multiplier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum PowerUpType
    {
        AddCharacters,
        MultiplyCharacters
    }
}