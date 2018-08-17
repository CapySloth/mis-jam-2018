using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    [Serializable]
    public struct BloodSplatter
    {
        public DeathType deathType;
        public GameObject bloodFxPrefab;
    }

    // INSPECTOR VARIABLES
    //public BloodSplatter[] bloodSplatters;
    public List<BloodSplatter> bloodSplatters;

    // COMPONENTS
    [HideInInspector]
    public PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void Spawn()
    {
        //TODO Find active spawn
        // Move to location
        // turn on PLayerMovement again
    }

    public void Gottem(DeathType deathtype)
    {
        switch (deathtype)
        {
            case DeathType.Flatten:
                Flatten();
                break;
            default:
                break;
        }
    }

    void Flatten()
    {
        //Do particle FX
        foreach (BloodSplatter splatter in bloodSplatters)
        {
            if(splatter.deathType == DeathType.Flatten)
            {
                DisableMovement();

                if (splatter.bloodFxPrefab != null)
                {
                    GameObject deathFx = Instantiate(splatter.bloodFxPrefab, new Vector3(this.transform.position.x, 5, this.transform.position.z), Quaternion.identity) as GameObject;
                    GameObject.Destroy(deathFx, 100000f);
                }
            }
        }

        //Make appear flattened
        gameObject.transform.localScale = new Vector3(1, 0.05f, 1);
    }

    private void DisableMovement()
    {
        movement.enabled = false;
    }

    private void EnableMovement()
    {
        movement.enabled = true;
    }
}
