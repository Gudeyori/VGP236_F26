using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Pascal Case is where all the first letters of each word is capitalized
    // used for class names and functions
    // MyClass
    // MyFunction
    // Camel Case is where the first word is all lowercase, but every other word is capital first letter
    // used for member variables, function variables, and local variables
    // myVariable
    // myLocalVariable
    // one exception, can include _ for member variables
    // _myPrivateVariable
    // mMyMemberVariable // camel case, iMyInt, fMyFloat, dMyDouble, lMyLong, bMyBool, gMyGlobal, sMyStatic

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
