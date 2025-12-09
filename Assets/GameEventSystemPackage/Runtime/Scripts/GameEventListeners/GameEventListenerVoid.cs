using UnityEngine;
using UnityEngine.Events;
using GameEventSystemInterfaces;

namespace cpluiz.GameEventSystem
{
    public class GameEventListenerVoid : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }
        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}