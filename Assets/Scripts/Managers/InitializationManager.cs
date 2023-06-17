using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers
{
    public class InitializationManager : MonoBehaviourSingleton<InitializationManager>
    {
        public UnityEvent OnGameStart;

        public void GameStarted()
        {
            OnGameStart.Invoke();
        }
    }

}