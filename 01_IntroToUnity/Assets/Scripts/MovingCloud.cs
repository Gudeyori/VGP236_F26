using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float maxDistanceFromStart = 500.0f;

    private float startPosX = 0.0f;
    private float direction = 1.0f;

    private void Awake()
    {
        startPosX = transform.position.x;
        direction = Random.value < 0.5f ? 1.0f : -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += direction * moveSpeed * Time.deltaTime;
        if (direction > 0.0f)
        {
            if (position.x - startPosX >= maxDistanceFromStart)
            {
                direction = -1.0f;
            }
        }
        else
        {
            if (startPosX - position.x >= maxDistanceFromStart)
            {
                direction = 1.0f;
            }
        }
        transform.position = position;
    }
}
