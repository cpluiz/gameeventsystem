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
    public void DebugObject(object test)
    {
        Debug.Log(test.GetType());
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
