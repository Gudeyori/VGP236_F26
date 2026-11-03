using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject != null)
        {
            Debug.Log("I GOT A GEAR!");
            // collect points
            GameManagerScript.Instance.AddGears(1);
            // destroy pickup
            Destroy(gameObject);
        }
    }
}
