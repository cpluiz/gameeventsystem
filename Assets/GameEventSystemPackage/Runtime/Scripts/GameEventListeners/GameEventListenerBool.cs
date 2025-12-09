using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerBool : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent<bool> Response;

    private void OnEnable()
    {
        Event.RegisterListener<GameEventListenerBool>(this);
    }

    public void OnEventRaised(bool parameter)
    {
        Response.Invoke(parameter);
    }
}
