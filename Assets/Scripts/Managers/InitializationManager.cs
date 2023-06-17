using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class InitializationManager : MonoBehaviour
    {
        public UnityEvent OnGameStart;

        public void GameStarted()
        {
            OnGameStart.Invoke();
        }
    }

}