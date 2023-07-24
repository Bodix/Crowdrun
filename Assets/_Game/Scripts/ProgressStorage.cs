using UnityEngine;

namespace Bodix.Crowdrun
{
    [DefaultExecutionOrder(-1)]
    public class ProgressStorage : MonoBehaviour
    {
        private const string PlayerProgressKey = "PlayerProgress";

        public PlayerProgressData LoadProgress()
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

            return progress;
        }

        public void SaveProgress(PlayerProgressData progress)
        {
            PlayerPrefs.SetString(PlayerProgressKey, JsonUtility.ToJson(progress));
            PlayerPrefs.Save();
        }
    }
}