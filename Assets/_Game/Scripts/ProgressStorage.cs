using UnityEngine;

namespace Bodix.Crowdrun
{
    [DefaultExecutionOrder(-1)]
    public class ProgressStorage : MonoBehaviour
    {
        [SerializeField]
        private Game _game;

        private const string PlayerProgressKey = "PlayerProgress";

        private void Awake()
        {
            LoadProgress();
        }

        public void SaveProgress()
        {
            PlayerProgressData progress = new()
            {
                Coins = _game.Coins
            };
            PlayerPrefs.SetString(PlayerProgressKey, JsonUtility.ToJson(progress));
            PlayerPrefs.Save();
        }

        private void LoadProgress()
        {
            PlayerProgressData progress;
            if (PlayerPrefs.HasKey(PlayerProgressKey))
            {
                string progressString = PlayerPrefs.GetString(PlayerProgressKey);
                progress = JsonUtility.FromJson<PlayerProgressData>(progressString);
            }
            else
            {
                progress = new PlayerProgressData();
            }

            _game.Coins = progress.Coins;
        }
    }
}