using UnityEngine;

public class SpinningBat : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody = null;
    [SerializeField]
    private Vector3 spinSpeed = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        rigidbody.angularVelocity = (spinSpeed * Mathf.Deg2Rad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.StunPlayer(1.0f);
                pc.GetComponent<Rigidbody>().AddForce(Vector3.up * 100, ForceMode.Impulse);
            }
        }
    }
}
