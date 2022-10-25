using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CustomAssetEvents 
{
    [AddComponentMenu("Event Listeners/Single",1)]
    //Abstract class for one argument listeners - Concrete scripts will use type instead of T
    public abstract class BaseGameEventListener<T, E, UE> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UE : UnityEvent<T>
    {
         E gameEvent;

        public E GameEvent => gameEvent;
        public UE response;

        private void OnEnable()
        {
            gameEvent?.RegisterListener(this);
        }
        public  void onEventRaised(T parameters)
        {
            response?.Invoke(parameters);
        }

        private void OnDisable()
        {
            gameEvent?.DeregisterListener(this);
        }
    }
}