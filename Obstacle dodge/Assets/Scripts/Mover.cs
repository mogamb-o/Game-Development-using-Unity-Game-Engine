using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions(); 
    }

    // Update is called once per frame
   //In udate function we depend on frame per seconds
    void Update()
    {
        PlayerMovement();
    }

    //Method used to Print some basic guidelines on the console
    void PrintInstructions()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or Arrow keys");
        Debug.Log("You have to dodge the obstacles");
    }

    //Method includes Horizontal & Vertical Movement of the player
    //Time.deltaTime is used to make frame rate independant 
    void PlayerMovement() 
    {

        float xValue =  Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0.0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue,yValue,zValue);
    
    }
}
