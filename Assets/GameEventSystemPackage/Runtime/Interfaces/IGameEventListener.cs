using UnityEngine;

namespace GameEventSystemInterfaces{
    public interface IGameEventListener
    {
        public void OnEventRaised<T>(T param)
        {
            
        }

    }
}