using UnityEngine;

public class BatBar : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float maxDistanceFromStart = 200.0f;

    private float startPosY = 0.0f;
    private float direction = 1.0f;

    private void Awake()
    {
        startPosY = transform.position.y;
        direction = Random.value < 0.5f ? 1.0f : -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.y += direction * moveSpeed * Time.deltaTime;
        if (direction > 0.0f)
        {
            if (position.y - startPosY >= maxDistanceFromStart)
            {
                direction = -1.0f;
            }
        }
        else
        {
            if (startPosY - position.y >= maxDistanceFromStart)
            {
                direction = 1.0f;
            }
        }
        transform.position = position;
    }
}
