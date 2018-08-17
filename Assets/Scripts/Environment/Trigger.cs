using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TriggerSet
{
    public TriggerType triggerType;
    public string triggerName;
}

public class Trigger: MonoBehaviour{

    // INSPECTOR VARIABLES
    public TriggerSet[] triggers;

    private void OnTriggerEnter(Collider other)
    {
        foreach(TriggerSet trigger in triggers)
        {
            EventManager.TriggerEvent(trigger.triggerName);
        }
    }
}
