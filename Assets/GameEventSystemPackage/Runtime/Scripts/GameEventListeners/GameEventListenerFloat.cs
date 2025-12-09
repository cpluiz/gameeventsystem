using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerFloat : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent<float> Response;

    private void OnEnable()
    {
        Event.RegisterListener<GameEventListenerFloat>(this);
    }

    public void OnEventRaised(float parameter)
    {
        Response.Invoke(parameter);
    }
}
