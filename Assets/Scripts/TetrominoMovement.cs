﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TetrominoMovement : MonoBehaviour
    {
        #region private properties

        private bool _isActive = false;

        private bool _freeze => transform.position.y <= 1;


        #endregion

        #region public properties

        public float Delay = 0;
        public float StepTime = 1;
        #endregion


        #region init

        private void Awake()
        {
        }

        private IEnumerator Start()
        {
            while (isActiveAndEnabled && !_freeze)
            {
                _isActive = true;
                yield return new WaitForSeconds(.5f);
                MoveBlockDown();
            }
            _isActive = false;
        }

        private void OnEnable()
        {
            EventManager.StartListening(Constants.SwipeEvents.SwipeRight, SwipeRight);
            EventManager.StartListening(Constants.SwipeEvents.SwipeLeft, SwipeLeft);
            EventManager.StartListening(Constants.SwipeEvents.SwipeDown, SwipeUp);
            EventManager.StartListening(Constants.SwipeEvents.SwipeUp, SwipeDown);
        }
        
        private void OnDisable()
        {
            EventManager.StopListening(Constants.SwipeEvents.SwipeRight, SwipeRight);
            EventManager.StopListening(Constants.SwipeEvents.SwipeLeft, SwipeLeft);
            EventManager.StopListening(Constants.SwipeEvents.SwipeDown, SwipeUp);
            EventManager.StopListening(Constants.SwipeEvents.SwipeUp, SwipeDown);
        }

        #endregion


        #region update

        private void Update()
        {

        }

        #endregion


        #region events

        private void SwipeRight()
        {
            if(transform.position.x < 10 && !_freeze)
                transform.position += Vector3.right;
        }

        private void SwipeDown()
        {
            
        }

        private void SwipeUp()
        {
            
        }

        private void SwipeLeft()
        {
            if (transform.position.x > 1 && !_freeze)
                transform.position += Vector3.left;
        }

        #endregion

        
        #region helpers

        private void MoveBlockDown()
        {
            transform.position += Vector3.down;
        }

        #endregion






        
    }
}
