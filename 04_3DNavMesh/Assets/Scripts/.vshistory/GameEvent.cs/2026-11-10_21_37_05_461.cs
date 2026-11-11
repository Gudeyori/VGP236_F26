using UnityEngine;

public enum EventType
{
    Invalid,
    TargetUpdated
}

public class GameEvent
{
    public GameEvent(EventType eType)
    {
        eventType = eType;
    }

    public EventType GetEventType() { return eventType; }
    protected EventType eventType = EventType.Invalid;
}

public class TargetUpdatedEvent : GameEvent
{
    TargetUpdatedEvent() : base(EventType.TargetUpdated)
    {   
    }

    public Vector3 position = Vector3.zero;
}
