using UnityEngine;

public class RotatingCloud : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private float rotation = 0.0f;

    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
