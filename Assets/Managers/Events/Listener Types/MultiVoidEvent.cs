using Unity;
using UnityEngine;
using CustomAssetEvents;
using UnityEngine.Events;



namespace CustomAssetEvents
{

[AddComponentMenu("Event Listeners/Multi/Multiple Listeners",1)]
public class MultiVoidEvent : MultiGameEventListener<Void, VoidEvent , UnityEvent<Void>> 
{

}

}