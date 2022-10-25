using Unity;
using UnityEngine;
using CustomAssetEvents;
using UnityEngine.Events;


namespace CustomAssetEvents
{

    [AddComponentMenu("Event Listeners/Single/New Void listener", 1)]
    public class VoidEventListener : BaseGameEventListener<Void, VoidEvent, UnityEvent<Void> > 
{

}

}