using UnityEngine;

public class PlatformConnect : MonoBehaviour
{


    // from not colliding to colliding - 1 frame
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            other.transform.parent = transform.parent;
        }
    }


    // from colliding to not colliding - 1 frame
    private void OnTriggerExit(Collider other)
    {

        if (other != null && other.gameObject != null)
        {
            other.transform.parent = null;
        }
    }
}
