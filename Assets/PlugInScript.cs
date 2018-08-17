using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugInScript : MonoBehaviour {

    public GameObject plug;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Plug In");
            plug.tag = "Socket";
            plug.transform.position = this.transform.position;
            plug.transform.parent = this.transform;
        }
    }
}
