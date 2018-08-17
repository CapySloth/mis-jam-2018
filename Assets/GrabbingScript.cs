using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : MonoBehaviour {

    public GameObject handSlot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabable")
        {
            Debug.Log("HA! GOTEM!");
            collision.transform.position = handSlot.transform.position;
            collision.transform.parent = handSlot.transform;
        }
    }
}
