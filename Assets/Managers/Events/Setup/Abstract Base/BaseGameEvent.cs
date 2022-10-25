using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomAssetEvents
{ 

// An abstract blueprint for making new concrete script of base of events with
// different datatypes. ( You can make datatyped event scripts which can have asset instances)

    //ONE ARGUMENT, Abstract for any datatype
public abstract class BaseGameEvent<T> :ScriptableObject
{
    private readonly List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

        //Invokes event 

    public void Raise(T parameter)
    {
        for (int i = listeners.Count - 1 ; i >= 0; i--)
        {
            listeners[i].onEventRaised(parameter);
        }
    }

        //Function for adding a listener

    public void RegisterListener(IGameEventListener<T> listener)
    {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
    }
        //Function for removing passed in listener from this scriptable object event
    public void DeregisterListener(IGameEventListener<T> listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}