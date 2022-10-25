using Unity;
using UnityEngine;
using CustomAssetEvents;

// Replace T with The type of event

namespace CustomAssetEvents
{
[CreateAssetMenu(fileName = "New Void Event", menuName = "Custom Events/Void Event")]
public class VoidEvent : BaseGameEvent<Void> 
{
        public void Raise() => Raise(new Void());
}
}