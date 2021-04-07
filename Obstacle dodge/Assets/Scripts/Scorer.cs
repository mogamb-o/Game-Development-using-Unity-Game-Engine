using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    //This callback method is used to triger out the event and tells the status of the hits 
   private void OnCollisionEnter(Collision other)
   {    
        if(other.gameObject.tag != "Hit")
        {
            Debug.Log("Bumped into the obstacles this many times: " + hits); 
            hits++;
        }
   }
}
