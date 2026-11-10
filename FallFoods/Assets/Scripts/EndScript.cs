using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EndScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.EndGame();
    }
}
