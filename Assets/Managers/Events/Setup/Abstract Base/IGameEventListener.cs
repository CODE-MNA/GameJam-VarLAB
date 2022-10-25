using UnityEngine;
namespace CustomAssetEvents
{
    public interface IGameEventListener<T>
    {
        public void onEventRaised(T parameters);
    }

    public struct Void { }
    
    [System.Serializable]
    public struct EventAndResponse<T,E,UR> where E:BaseGameEvent<T> where UR:UnityEngine.Events.UnityEvent<T>
    {
        public E gameEvent;
        public UR response;

    }
}
