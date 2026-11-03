using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null && collision.gameObject != null)
        {
            //Debug.Log("YOU DIED");
            
            GameObject collisionObject = collision.gameObject;
            //Debug.Log(collisionObject.name);
            PlayerController player = collisionObject.GetComponent<PlayerController>();
            
            player.RespawnPlayer();
        }
    }
}
