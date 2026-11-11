using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    [SerializeField]
    private AgentTarget target = null;

    private NavMeshAgent agent = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
