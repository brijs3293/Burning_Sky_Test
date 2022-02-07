using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using EA.BurningSky.ObjectPool;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
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
            if (collision.gameObject.CompareTag(Constants.BulletTag))
            {
                PoolManager.Despawn(collision.transform);
            }
            else if (collision.gameObject.CompareTag(Constants.EnemyTag))
            {
                PoolManager.Despawn(collision.transform);
            }
        }
    }
}
