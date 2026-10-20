using UnityEngine;

public class BatPaddle : MonoBehaviour
{
    // Controls how fast the paddle swings back and forth
    [SerializeField]
    private float rotationSpeed = 1.0f;
   
    // Controls how far the paddle swings from its center angle
    [SerializeField]
    private float amplitude = 1.0f;
   
    // Sets the center angle of the paddle's rotation, in degrees
    [SerializeField]
    private float rotationAngle = 1.0f;

    // Stores the calculated rotation angle
    private float rotation = 0.0f;

    void Update()
    {
        // Calculate the paddle's rotation using a sine wave
        // Time.time tracks elapsed time, and rotationSpeed controls the swing speed
        // Mathf.Sin produces a smooth value between -1 and 1
        // Multiplying by amplitude controls the swing range
        // Adding rotationAngle sets the center of the swing
        rotation = rotationAngle + Mathf.Sin(Time.time * rotationSpeed) * amplitude;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
