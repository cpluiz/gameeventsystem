using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public FloatVariable playerHP;

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

    [ContextMenu("SetPlayerHpToHalf")]
    public void SetPlayerHPToHalf()
    {
        playerHP.Value = playerHP.DefaultValue / 2;
    }
}
