using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CustomAssetEvents 
{
    
    //Abstract class for one argument listeners - Concrete scripts will use type instead of T
    public abstract class MultiGameEventListener<T, E, UE> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UE : UnityEvent<T>
    {
     
       // [SerializeField]List<E> gameEvents;

        //public List<E> GameEvents =>  gameEvents;
        //public List<UE> responses;

        public List<EventAndResponse<T, E, UE>> eventsAndResponses;
        int[] ids;

        private void OnEnable()
        {
            
            foreach (EventAndResponse<T, E, UE> pair in eventsAndResponses)
            {
                pair.gameEvent?.RegisterListener(this); 
            }
        }
        public  void onEventRaised(T parameters)
        {
            foreach (EventAndResponse < T, E, UE > pair in eventsAndResponses)
            {

                pair.response?.Invoke(parameters); 
            }
        }

       

        private void OnDisable()
        {
            foreach (EventAndResponse < T, E, UE > pair in eventsAndResponses)
            {
                pair.gameEvent?.DeregisterListener(this);
            }
        }
    }
}