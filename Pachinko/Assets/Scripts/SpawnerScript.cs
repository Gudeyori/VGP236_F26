using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

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
            spriteRenderer.flipX = false;
            moveDirection.x = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            moveDirection.x = moveSpeed;
        }

        // replace this
        //transform.position += moveDirection * Time.deltaTime;

        // with this
        rigidBody.linearVelocity = moveDirection;
    }
}

// rigidbody2d has a property called linearvelocity, which is a vector2d
// you can also affect this value by using the properties linearvelocityx and linearvelocityY
// linear velocity represents the distance that this object will travel, if unimpeded, over the next 1 second