using UnityEngine;
using UnityEngine.Events;
using cpluiz.GameEventSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public FloatVariable playerHP;
    public GameEvent gameEventTest;

    void Awake()
    {
        playerHP.OnValueChanged.AddListener(PlayerHPChanged);
    }
    void OnDestroy()
    {
        playerHP.OnValueChanged.RemoveListener(PlayerHPChanged);
    }

    public void PlayerHPChanged()
    {
        Debug.Log(playerHP.Value);
    }
    public void DebugTransform(Transform transform)
    {
        Debug.Log(transform.name);
    }
    public void DebugObject(object test)
    {
        Camera testObject = test as Camera;
        Debug.Log($"Object {testObject.name} with type {test.GetType()}");
    }
    public void DebugString(string receivedString)
    {
        Debug.Log($"Received the string \"{receivedString}\"");
    }

    [ContextMenu("SetPlayerHpToHalf")]
    public void SetPlayerHPToHalf()
    {
        playerHP.Value = playerHP.DefaultValue / 2;
        gameEventTest?.Raise<object>(this);
    }
}
