using BurningSky.ObjectPool;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// Class which creates a boundry and detects objects at boundry and despawn
    /// </summary>
    public class BoundaryDetector : MonoBehaviour
    {
        [SerializeField]
        private Camera _myCamera;

        public static Vector2 screenBoundary;
        void Awake()
        {
            screenBoundary = _myCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _myCamera.transform.position.z));
            this.transform.localScale = new Vector3(screenBoundary.x * 2, 0.1f, screenBoundary.y * 2);
        }

        private void OnTriggerExit(Collider collision)
        {
            PoolManager.Despawn(collision.transform);
        }
    }
}
