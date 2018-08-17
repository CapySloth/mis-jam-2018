using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

    public DeathType deathType;
    public string touchType;
    public Collider collider;

    private void Start()
    {
        if(collider != null)
        {
            collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (touchType != "")
        {
            if (other.gameObject.GetComponent(touchType) != null)
            {
                other.gameObject.SendMessage("Gottem", deathType);
            }
        }
    }


}
