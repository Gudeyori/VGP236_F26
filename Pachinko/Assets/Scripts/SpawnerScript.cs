using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dropItem = null;

    [SerializeField]
    private float moveSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawner Space Is Pressed");
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        Vector3 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = moveSpeed;
        }

        transform.position += moveDirection * Time.deltaTime;
    }
}
