using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    // A variable to hold our Transform component
    private Transform tf;
    // A speed variable
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the transform componentl
        tf = GetComponent<Transform>();
        // Function myVector

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVector = new Vector3(2, 4, 12);
        myVector = myVector.normalized;
        tf.position = tf.position + (myVector * speed * Time.deltaTime);
        // Move up every fame draw by adding 1 to the y of our postion
        tf.position = tf.position + (Vector3.up * 0.5f);
        // Vector3.up is a preset Vector of (0,1,0)
        // There is also a Vector3.right (1,0,0) and Vector3.forward(0,0,1)
    }

}