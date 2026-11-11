using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    [SerializeField]
    private AgentTarget target = null;

    private NavMeshAgent agent = null;

    private Vector3 prevTarget = Vector3.zero;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
