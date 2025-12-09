using UnityEngine;
using UnityEngine.Events;
using cpluiz.GameEventSystemInterfaces;

namespace cpluiz.GameEventSystem
{
    public class GameEventListener<T> : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public UnityEvent<T> Response;

        protected void OnEnable()
        {
            Event.RegisterListener(this);
        }
        protected void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T parameter)
        {
            Response?.Invoke(parameter);
        }
    }
}