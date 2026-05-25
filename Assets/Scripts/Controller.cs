using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn possessedShip;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (possessedShip == null) return;

        //turbo when holding shift
        bool wantsToBoost = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        possessedShip.SetBoost(wantsToBoost);
        //"Vertical" axis gives 1 when holding W
        float thrust = 0f;
        float rotation = 0f;
        //Forward and Backwards   
        if (Input.GetKey(KeyCode.W)) thrust = 1f;
        if (Input.GetKey(KeyCode.S)) thrust = -1f;

        //Rotation
        if (Input.GetKey(KeyCode.A)) rotation = 1f;
        if (Input.GetKey(KeyCode.D)) rotation = -1f;


        float strafeX = 0f;
        float strafeY = 0f;
         
        //strafe movement
        if (Input.GetKey(KeyCode.UpArrow)) strafeY = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) strafeY = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) strafeX = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) strafeX = -1f;

        //send the intent to the pawn
        possessedShip.SetLocalThrust(thrust);
        possessedShip.SetRotation(rotation);

        Vector2 strafeDirection = new Vector2(strafeX, strafeY);
        possessedShip.SetStrafe(strafeDirection);
     

       
        // Teleport to random range on (x,y)
        if (Input.GetKeyDown(KeyCode.T))
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            transform.position = new Vector3(randomX, randomY, 0);
        }
    }
    
}