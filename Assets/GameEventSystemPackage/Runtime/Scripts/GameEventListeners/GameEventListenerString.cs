using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerString : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent<string> Response;

    private void OnEnable()
    {
        Event.RegisterListener<GameEventListenerString>(this);
    }

    public void OnEventRaised(string parameter)
    {
        Response.Invoke(parameter);
    }
}
