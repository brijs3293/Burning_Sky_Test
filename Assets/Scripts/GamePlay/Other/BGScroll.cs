using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// Class that handles background image scrolling
    /// </summary>
    public class BGScroll : MonoBehaviour
    {
        public float scrollSpeed;

        private Vector3 _startPosition;
        private float _length;

        void Start()
        {
            _startPosition = transform.position;
            _length = this.transform.localScale.y;
        }

        void Update()
        {
            transform.position = _startPosition + Vector3.forward * Mathf.Repeat(Time.time * scrollSpeed, _length);
        }
    }
}
