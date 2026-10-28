using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null && collision.gameObject != null)
        {
            //Debug.Log("YOU DIED");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.RespawnPlayer();
        }
    }
}
