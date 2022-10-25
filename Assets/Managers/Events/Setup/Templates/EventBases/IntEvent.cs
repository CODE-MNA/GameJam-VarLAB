using Unity;
using UnityEngine;
using CustomAssetEvents;

// Replace T with The type of event

namespace CustomAssetEvents
{
    [CreateAssetMenu(fileName = "New Int Event", menuName = "Custom Events/Int Event")]
    public class IntEvent : BaseGameEvent<int>
    {
        public int Value { get; set; }
        public void Raise() => Raise(Value);
    }
}