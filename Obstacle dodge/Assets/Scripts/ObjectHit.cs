using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    //This callback method is used to triger out an event when player collides with the boundaries 
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player") //Color of obstacle will change when only interact by player
        {

            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit"; 
        
        }
    }
}
