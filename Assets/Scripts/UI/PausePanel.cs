using UnityEngine;

namespace BurningSky.UI
{
    public class PausePanel : MonoBehaviour
    {
        public void UnPauseButtonClicked()
        {
            UiManager.Instance.StartGameplayClicked();
        }
    }
}
