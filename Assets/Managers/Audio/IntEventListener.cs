using Unity;
using UnityEngine;
using CustomAssetEvents;
using UnityEngine.Events;

// Replace T with The type of event

namespace CustomAssetEvents
{
    [AddComponentMenu("Event Listeners/Multi/Multiple Int Listeners",2)]
    public class IntEventListener : MultiGameEventListener<int, BaseGameEvent<int> , UnityEvent<int>> 
{

 

        
}

}