using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    //reminder delegate defines a void function
    public delegate void GameEventListener(GameEvent gameEvent);
    public GameEventListener GameEventListeners { get; set; }

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

    public void Broadcast(GameEvent gameEvent)
    {
        GameEventListeners?.Invoke(gameEvent);
    }
}
