using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject != null)
        {
            Debug.Log("I GOT A GEAR!");
            // collect points
            GameManagerScript.Instance.AddPoints(points);
            // destroy pickup
            Destroy(gameObject);
        }
    }
}
