using System.Diagnostics.Contracts;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Renderer meshRenderer = null;
    [SerializeField]
    private int index = -1;

    public int Index { get { return index; } }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Assert(index >= 0, "Index must be set");

        CheckpointManager.Instance.SetCheckpoint(this);
        GetComponent<Collider>().enabled = false;

        if (meshRenderer != null)
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
