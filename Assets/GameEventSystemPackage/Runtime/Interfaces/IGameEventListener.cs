using UnityEngine;

namespace cpluiz.GameEventSystemInterfaces{
    public interface IGameEventListener
    {
        public void OnEventRaised<T>(T param)
        {
            
        }

    }
}