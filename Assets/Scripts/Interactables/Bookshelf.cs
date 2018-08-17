using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour {

    // INSPECTOR PROPERTIES
    public float fallingForce;
    Rigidbody rb;
    DeathBox deathBox;

    private void Start()
    {
        rb = GetComponent<Rigidbody> ();
        deathBox = GetComponent<DeathBox>();
    }

    public void Bookshelf_Fall()
    {
        if(rb != null)
        {
            if (deathBox != null)
            {
                rb.AddTorque(fallingForce, 0, 0);
                deathBox.enabled = true;
            }
        }
    } 

	public void TestMethod()
    {
        Debug.Log("HOLYSHIT IT WORKS");
    }
}
