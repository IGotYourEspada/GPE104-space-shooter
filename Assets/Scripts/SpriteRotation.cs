using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    // Variable for our transform
    private Transform tf;
    // Varibale for the defrees we rotate in one frame draw
    public float turnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Loads our transform component into our variable
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate "turnSpeed" degrees on the Y axis
        tf.Rotate(0, 0, turnSpeed);
    }
}
