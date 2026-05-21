using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    // Declare the variables
    private SpriteRenderer theRenderer;
    // variable for custom color
    public Color spriteColor;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // load the spriteRenderer component from the same object this compont is on..
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        // Change the color from the color picker so that the alpha is 1
        spriteColor.a = 1.0f;
        // This makes the variable have a red value of 0% red
        spriteColor.r = 1.0f;
        // This makes the variable have a red value of 0% green
        spriteColor.g = 1.0f;
        // This makes the variable have a random green value, somewhere between 0 and 1
        spriteColor.b = Random.Range(0.0f, 1.0f);
        // As long as theRenderer has been set
        if (theRenderer != null)
        {
         // Change the "color" value of the SpriteRenderer component to the custom color
        theRenderer.color = spriteColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
