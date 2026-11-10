using UnityEngine;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    private bool hasStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasStarted)
        {// only trigger once during play!
            return;
        }
        hasStarted = true;
        GameManager.Instance.StartGame();
    }
}
