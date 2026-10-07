using UnityEngine;

public class KillTriggerScript : MonoBehaviour
{
    // requires at least one object to have a rigidbody
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Something hit me!");
    }
}
