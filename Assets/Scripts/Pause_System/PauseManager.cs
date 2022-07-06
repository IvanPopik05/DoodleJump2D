using System.Collections.Generic;
using UnityEngine;

namespace Pause_System
{
    public class PauseManager : MonoBehaviour
    {
        private bool _isPaused;
        private static PauseManager _instance;
        public static PauseManager Instance => _instance;
        public bool IsPaused => _isPaused;
        private void Awake()
        {
            if (_instance == null) 
                _instance = this;
            else
                Destroy(gameObject);
        }
        public void OnPause()
        {
            if(_isPaused)
                return;

            _isPaused = true;
        }

        public void OnUnpause()
        {
            if(!_isPaused)
                return;

            _isPaused = false;
        }
    }
}