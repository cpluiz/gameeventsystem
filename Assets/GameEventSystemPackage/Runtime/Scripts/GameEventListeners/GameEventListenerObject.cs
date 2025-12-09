using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerObject : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent<object> Response;

    private void OnEnable()
    {
        Event.RegisterListener<GameEventListenerObject>(this);
    }

    public void OnEventRaised(object parameter)
    {
        Response.Invoke(parameter);
    }
}
