using UnityEngine;

enum EventType
{
    Invalid,
    TargetUpdated
}

public class GameEvent
{
    GameEvent(EventType eType)
    {
        eventType = eType;
    }

    private EventType GetEventType() { return eventType; }
    private EventType = EventType.Invalid;
}

public class TargetUpdatedEvent : GameEvent
{
    TargetUpdatedEvent()
    {
        GameEvent(EventType.TargetUpdated);
    }
}
