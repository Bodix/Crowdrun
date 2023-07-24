using UnityEngine;
using UnityEngine.UI;

namespace Bodix.Crowdrun.UI
{
    public class FinishScreenUi : MonoBehaviour
    {
        [SerializeField]
        private Game _game;
        [SerializeField]
        private Button _nextLevelButton;

        private void Awake()
        {
            _nextLevelButton.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                _game.ResetLevel();
            });
        }
    }
}