using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("The T key is down");
        }
        else
        {
            Debug.Log("The T key is NOT down!");
        }       
    }
}
