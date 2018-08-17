using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct ListenerSet
{
    public string listenerName;
    public string methodCall;
}

public class Listener : MonoBehaviour {

    public ListenerSet[] listeners;
    string methodToCall;

    private void Start()
    {
        foreach(ListenerSet listener in listeners)
        {
            methodToCall = listener.methodCall;
            EventManager.StartListening(listener.listenerName, MethodCallback);
        }
    }

    private void MethodCallback()
    {
       SendMessage(methodToCall);
    }
}
