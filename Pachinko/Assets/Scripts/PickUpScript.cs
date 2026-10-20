using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    private int points = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            // collect points
            GameManager.Instance.AddPoints(points);
            // destroy pickup
           // Destroy(gameObject);
        }
    }
}