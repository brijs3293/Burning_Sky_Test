using System;
using System.Collections;
using System.Collections.Generic;
using EA.BurningSky.Data;
using EA.BurningSky.Event;
using UnityEngine;
using EventType = EA.BurningSky.Event.EventType;


namespace EA.BurningSky.Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        #region Public_Variables

        public PlayerConfig playerConfig;
        public Rigidbody body;
        public Collider myCollider;
        public Camera myCamera;
        public Health health;
        [NonSerialized] public bool isPlayerSelected;
        #endregion

        #region Private_Variables
        private Vector2 _input;
        private Vector3 _inputPos;
        private float _xMin, _xMax, _zMin, _zMax;
        private bool _inputAvailable;
        #endregion

        #region Unity_Callbacks
        // Start is called before the first frame update
        void Start()
        {
            EventManager.RegisterMethod(EventType.MouseDown, ReceiveInput);
            _xMin = -BoundaryDetector.screenBoundary.x;
            _xMax = BoundaryDetector.screenBoundary.x;
            _zMin = -BoundaryDetector.screenBoundary.y / 4;
            _zMax = BoundaryDetector.screenBoundary.y - (BoundaryDetector.screenBoundary.y / 4);
            health.killPlayer += KillPlayer;
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputAvailable)
            {
                Ray ray = Camera.main.ScreenPointToRay(_input);
                RaycastHit hit;
                if (myCollider.Raycast(ray, out hit, 100.0f))
                {
                    _inputPos.x = myCamera.ScreenToWorldPoint(_input).x;
                    _inputPos.z = myCamera.ScreenToWorldPoint(_input).z;

                    _inputPos.x = Mathf.Clamp(_inputPos.x, _xMin, _xMax);
                    _inputPos.z = Mathf.Clamp(_inputPos.z, _zMin, _zMax);
                    isPlayerSelected = true;
                }
                return;
            }
            _inputAvailable = false;
        }

        void FixedUpdate()
        {
            if (isPlayerSelected)
            {
                body.MovePosition(_inputPos);
                isPlayerSelected = false;
            }
            else
            {
                body.velocity = Vector3.zero;
            }
        }

        void OnDestroy()
        {
            EventManager.UnRegisterMethod(EventType.MouseDown, ReceiveInput);
            health.killPlayer -= KillPlayer;
        }

        #endregion

        #region Private_Methods

        void ReceiveInput(object input)
        {
            _inputAvailable = true;
            Vector3 temp = (Vector3)input;
            _input.x = temp.x;
            _input.y = temp.y;
        }

        void KillPlayer()
        {
            gameObject.SetActive(false);
            //Create particle here
        }

        #endregion
    }
}
