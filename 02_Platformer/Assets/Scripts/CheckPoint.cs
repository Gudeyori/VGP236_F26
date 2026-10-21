using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject inactiveState = null;
    [SerializeField]
    private GameObject activatedState = null;

    private void Awake()
    {
        inactiveState.SetActive(true);
        activatedState.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            inactiveState.SetActive(false);
            activatedState.SetActive(true);
            CheckPointManager.Instance.SetHitCheckpoint(this);

            // disables the collider -> no more touchy
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
