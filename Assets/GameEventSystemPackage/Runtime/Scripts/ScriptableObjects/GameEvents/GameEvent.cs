using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

namespace cpluiz.GameEventSystem
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        #region Public
        [VoidButton("RaiseVoid", "Raise Void")]
        public int debugVoid;
        [RaiseInt("Raise", "Raise Int")]
        public int debugInt;
        [RaiseFloat("Raise", "Raise Float")]
        public float debugFloat;
        [RaiseString("Raise", "Raise String")]
        public string debugString;
        [RaiseBool("Raise", "Raise Boolean")]
        public bool debugBool;
        // TODO - Make object drawer works
        // [RaiseObject("Raise", "Raise Object")]
        // public object debugObject;
        #endregion Public

        #region Private variables
        private List<GameEventListenerVoid> voidListeners = new List<GameEventListenerVoid>();
        private List<GameEventListenerBool> boolListeners = new List<GameEventListenerBool>();
        private List<GameEventListenerInt> intListeners = new List<GameEventListenerInt>();
        private List<GameEventListenerFloat> floatListeners = new List<GameEventListenerFloat>();
        private List<GameEventListenerString> stringListeners = new List<GameEventListenerString>();
        private List<GameEventListenerObject> objectListeners = new List<GameEventListenerObject>();
        #endregion Private variables

        public void RaiseVoid()
        {
            for(int i = voidListeners.Count -1; i >= 0; i--)
            {
                if(voidListeners[i] != null) voidListeners[i].OnEventRaised();
            }
        }
        public void Raise<T>(T parameter)
        {
            switch (parameter)
            {
                case int intParameter:
                for(int i = intListeners.Count -1; i >= 0; i--)
                {
                    if(intListeners[i] != null) intListeners[i].OnEventRaised(intParameter);
                }
                break;
                case float floatParameter:
                for(int i = floatListeners.Count -1; i >= 0; i--)
                {
                    if(floatListeners[i] != null) floatListeners[i].OnEventRaised(floatParameter);
                }
                break;
                case string stringParameter:
                for(int i = stringListeners.Count -1; i >= 0; i--)
                {
                    if(stringListeners[i] != null) stringListeners[i].OnEventRaised(stringParameter);
                }
                break;
                case bool boolParameter:
                for(int i = boolListeners.Count -1; i >= 0; i--)
                {
                    if(boolListeners[i] != null) boolListeners[i].OnEventRaised(boolParameter);
                }
                break;
                case object objectParameter:
                for(int i = objectListeners.Count -1; i >= 0; i--)
                {
                    if(objectListeners[i] != null) objectListeners[i].OnEventRaised(objectParameter);
                }
                break;
            }
        }
        public void RegisterListener<T>(T listener)
        {
            switch (listener)
            {
                case GameEventListenerVoid voidGameListener:
                if(!voidListeners.Contains(voidGameListener)) voidListeners.Add(voidGameListener);
                    break;
                case GameEventListenerObject objectListener:
                    if(!objectListeners.Contains(objectListener)) objectListeners.Add(objectListener);
                    break;
                case GameEventListenerBool boolListener:
                    if(!boolListeners.Contains(boolListener)) boolListeners.Add(boolListener);
                    break;
                case GameEventListenerInt intListener:
                    if(!intListeners.Contains(intListener)) intListeners.Add(intListener);
                    break;
                case GameEventListenerFloat floatListener:
                    if(!floatListeners.Contains(floatListener)) floatListeners.Add(floatListener);
                    break;
                case GameEventListenerString stringListener:
                    if(!stringListeners.Contains(stringListener)) stringListeners.Add(stringListener);
                    break;
                default:
                    //TODO change to a proper debug system
                    Debug.LogError($"Cannot add {listener} into a listener list - unknow type {typeof(T)} ");
                    break;
            }
        }
        public void UnregisterListener<T>(T listener)
        {
            switch (listener)
            {
                case GameEventListenerVoid voidGameListener:
                    voidListeners.Remove(voidGameListener);
                    break;
                case GameEventListenerObject objectListener:
                    objectListeners.Remove(objectListener);
                    break;
                case GameEventListenerBool boolListener:
                    boolListeners.Remove(boolListener);
                    break;
                case GameEventListenerInt intListener:
                    intListeners.Remove(intListener);
                    break;
                case GameEventListenerFloat floatListener:
                    floatListeners.Remove(floatListener);
                    break;
                case GameEventListenerString stringListener:
                    stringListeners.Remove(stringListener);
                    break;
                default:
                    //TODO change to a proper debug system
                    Debug.LogError($"Cannot remove {listener} from the listener list - unknow type {typeof(T)} ");
                    break;
            }
        }
    }

    [System.Serializable]
    public class VoidButtonAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public VoidButtonAttribute(string methodName, string buttonLabel = "Raise")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }

    [System.Serializable]
    public class RaiseIntAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public RaiseIntAttribute(string methodName, string buttonLabel = "Raise Int")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
    [System.Serializable]
    public class RaiseFloatAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public RaiseFloatAttribute(string methodName, string buttonLabel = "Raise Float")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
    [System.Serializable]
    public class RaiseStringAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public RaiseStringAttribute(string methodName, string buttonLabel = "Raise String")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
    [System.Serializable]
    public class RaiseBoolAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public RaiseBoolAttribute(string methodName, string buttonLabel = "Raise Bool")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }

    [System.Serializable]
    public class RaiseObjectAttribute : PropertyAttribute
    {
        public string MethodName {get; private set;}
        public string ButtonLabel {get; private set;}
        [ExecuteAlways]
        public RaiseObjectAttribute(string methodName, string buttonLabel = "Raise Bool")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
}