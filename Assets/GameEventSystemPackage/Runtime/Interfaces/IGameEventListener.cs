using UnityEngine;

public interface IGameEventListener
{
    public void OnEventRaised<T>(T param)
    {
        
    }

}
