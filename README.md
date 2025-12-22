# GameEventSystem

The GameEventSystem is a package based on the 2017 Unity Austin Game Architecture with Scriptable Objects.

This package enables you to use simple GameVariable Scriptable Objects, GameEvents and GameEventListeners.

By default, you can use GameVariables for each of the basic variable types (Int, Float, Bool and String)

<img width="375" height="100" alt="NewGameVariables" src="https://github.com/user-attachments/assets/ce0d060d-14f3-4b40-a95a-39ba809510f2" />

## Disclaimer
**Right now this package is a work in progress. Instalantion instructions, documentation and sample code and scenes will be added in the near future**

## GameVariable

<img width="509" height="185" alt="FloatGameVariableExample" src="https://github.com/user-attachments/assets/145e1922-18b8-49df-9d1c-61371fe2dcf9" />

Each of the GameVariable cointains:
- Default Value: The default value for the GameVariable, that will overwrite the current Value when the ScriptableVariable is loaded on the memory;
- Value: The current value for the GameVariable, that can be changed in the runtime;
- OnValueChanged: A event that will be triggered every time that the current Value changes.

Usage:
```C#
using UnityEngine;
using cpluiz.GameEventSystem;

public class GameVariableUsageExample  : MonoBehaviour
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
}
```
*Note: Never forget to use the RemoveListener when the object is destroyed and/or disabled, otherwise you can have unexpected errors on your project.*

You can easily create your own type of GameVariable by extending the base class `ScriptableVariable`.

```C#
using UnityEngine;
using cpluiz.GameEventSystem;

[CreateAssetMenu(menuName = "GameVariable/CustomTypeVariable", fileName = "CustomTypeVariable")]
public class CustomGameVariable : ScriptableVariable<CustomType>
{
}
```

Where *CustomType* is the class/struct that you want to store as a reference in a GameVariable.

The *DefaultValue* isn't required, and will be default value for that primitive type, or a null reference, depending on the type of variable that your GameVariable was setup to store.

## GameEvent
Using a GameEvent you can broadcast/send diferent types of values between GameObjects using a ScriptableObject as a medium, without the need to use Unity generic BroadcastMessage to all objects.

The GameEvent system works with a pair of a GameEvent and GameEventListener. The GameEvent can send the following types:

<img width="233" height="127" alt="GameEventListeners" src="https://github.com/user-attachments/assets/fe956b83-344e-470a-aec4-04e7996e014e" />

- Void/No Value, received using the GameEventListenerVoid component;
- Boolean, received using the GameEventListenerBool component;
- Integer, received using the GameEventListenerInt component;
- Float, received using the GameEventListenerFloat component;
- String, received using the GameEventListenerString component;
- Object, received using the GameEventListenerObject component;

The GameEventListenerObject can receive any kind of object/class, but you need to cast/convert the object into the expected type, so you need to be carefull and never forget to treat the edge cases to prevent unexpected failures if you receive the wrong type of object.

Each GameEventListener works as a bridge between the sender and the receiver component, using UnityEvents.

Example:

```C#
using UnityEngine;
using cpluiz.GameEventSystem;

public class GameEventSenderExample  : MonoBehaviour
{
    public GameEvent myGameEvent;

    public void OnTriggerEnter(Collider other)
    {
        myGameEvent.Raise(); //GameEvent void
        myGameEvent.Raise(other.name); //GameEvent string
        myGameEvent.Raise(other.transform.childCount); //GameEvent int
    }
}
```

```C#
using UnityEngine;

public class GameEventReceiverExample : MonoBehaviour
{
    public void ReceiveVoidEvent()
    {
        Debug.Log($"GameEventVoid Received");
    }

    public void ReceiveStringEvent(string value)
    {
        Debug.Log($"Received the following string: {value}");
    }
    public void ReceiveIntEvent(int value)
    {
        Debug.Log($"Received the following integer: {value}");
    }
}
```

<img width="512" height="600" alt="GameEventReceiverExample" src="https://github.com/user-attachments/assets/0a609eb8-748b-4979-8021-3e66167a0cb5" />

Since we are using *UnityEvent*s to receive those messages, as long as we are using a public function with the correct received variable type, we can pass the event values for the receiver function using the Dynamic parameters:

<img width="629" height="319" alt="GameEventIntListenerExample" src="https://github.com/user-attachments/assets/f4eabb88-f642-4fca-9cbc-22170531b0ea" />

You can create as much GameEvents as needed, but only the components that makes reference for the specific GameEvent that you want to use will receive the messages.

## Debugging
You can test and debug your GameEvents on the editor, using selecting the specific GameEvent that you have created on the editor and using the Inspector functions:

<img width="507" height="252" alt="GameEventExample" src="https://github.com/user-attachments/assets/94799268-d960-4b04-8fc7-2cd1a8b1fb1f" />

Using the example script above, if we want to test if the GameEvent is sending the string properly, and if we want to check if the receiver script is working as expected, we can use the "Raise String" button, after feeding the string field with the desired test value:
<img width="512" height="251" alt="GameEventDebugStringExample" src="https://github.com/user-attachments/assets/cbf5909f-0ae1-4382-82db-cad394029b44" />

`Note: You are free to parse a class or a struct into a JSON and use the *RaiseString* to broadcast anything that you want, as long as you don't forget to prepare your code for any edge cases, and test if the string received is a valid parseable JSON value or not.`

You can also use the **AssetUsageDetector** package (included in this package as a dependency):

<img width="331" height="614" alt="image" src="https://github.com/user-attachments/assets/44cc080a-3e2d-4818-97b9-04bedaad0def" />

`Link for this free asset on the References section`

## References

 - [Unity Austin 2017 - Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk)
 - [Asset Usage Detector page on Unity AssetStore](https://assetstore.unity.com/packages/tools/utilities/asset-usage-detector-112837)
