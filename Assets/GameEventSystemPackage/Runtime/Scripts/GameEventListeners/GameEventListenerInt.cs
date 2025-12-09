using UnityEngine;
using UnityEngine.Events;
using GameEventSystemInterfaces;

namespace cpluiz.GameEventSystem
{
    public class GameEventListenerInt : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public UnityEvent<int> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }
        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(int parameter)
        {
            Response.Invoke(parameter);
        }
    }
}