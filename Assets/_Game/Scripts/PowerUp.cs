using System;
using NaughtyAttributes;

namespace Bodix.Crowdrun
{
    [Serializable]
    public class PowerUp
    {
        public PowerUpType Type;
        [AllowNesting, ShowIf(nameof(IsAdd))]
        public int AdditionalAmount = 10;
        [AllowNesting, ShowIf(nameof(IsMultiply))]
        public int Multiplier = 2;

        private bool IsAdd => Type == PowerUpType.AddCharacters;
        private bool IsMultiply => Type == PowerUpType.MultiplyCharacters;

        public void Apply(Crowd crowd)
        {
            switch (Type)
            {
                case PowerUpType.AddCharacters:
                    crowd.AddCharacters(AdditionalAmount);
                    break;
                case PowerUpType.MultiplyCharacters:
                    crowd.AddCharacters(crowd.Count * (Multiplier - 1));
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