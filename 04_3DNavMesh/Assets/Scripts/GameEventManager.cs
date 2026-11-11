using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    private static GameEventManager instance = null;
    public GameEventManager Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
