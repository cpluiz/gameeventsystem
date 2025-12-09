using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEditor;
using UnityEngine;
using cpluiz.GameEventSystemInterfaces;
using System;

namespace cpluiz.GameEventSystem
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        #region Public
        [VoidButton("RaiseVoid", "Raise Void")] public int debugVoid;
        [RaiseInt(columnSize:2)] public int debugInt;
        [RaiseFloat(columnSize:2)] public float debugFloat;
        [RaiseBool(columnSize:1)] public bool debugBool;
        [RaiseString(columnSize:5)] public string debugString;
        // TODO - Make object drawer works
        [RaiseObject(columnSize:5)] public UnityEngine.Object testObject;
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
                case UnityEngine.Object objectParameter:
                    for(int i = objectListeners.Count -1; i >= 0; i--)
                    {
                        if(objectListeners[i] != null) objectListeners[i].OnEventRaised(objectParameter);
                    }
                    break;
                default:
                    Debug.LogError($"Type for {parameter.GetType()} cannot be processed");
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
        public int MaxColumnSize { get{ return 10; } }
        public int PropertyColumnSize{get;}
        [ExecuteAlways]
        public VoidButtonAttribute(string methodName, string buttonLabel = "Raise")
        {
            MethodName = methodName;
            ButtonLabel = buttonLabel;
        }
    }
    
    [System.Serializable]
    public class RaiseButtonAttribute : PropertyAttribute
    {
        public string MethodName { get { return "Raise"; } }
        public string ButtonLabel { get; protected set; }
        public int MaxColumnSize { get{ return 10; } }
        public int PropertyColumnSize{ get; protected set; }
        public object ObjectType;
        public RaiseButtonAttribute(string buttonLabel = "RaiseButton", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
        }
    }


    [System.Serializable]
    public class RaiseIntAttribute : RaiseButtonAttribute
    {
        new public int ObjectType;
        public RaiseIntAttribute(string buttonLabel = "Raise Int", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
            base.ObjectType = 0;
        }
    }
    [System.Serializable]
    public class RaiseFloatAttribute : RaiseButtonAttribute
    {
        new public float ObjectType;
        public RaiseFloatAttribute(string buttonLabel = "Raise Float", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
            base.ObjectType = 0.4f;
        }
    }
    [System.Serializable]
    public class RaiseStringAttribute  : RaiseButtonAttribute
    {
        new public string ObjectType;
        public RaiseStringAttribute(string buttonLabel = "Raise String", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
            base.ObjectType = "";
        }
    }
    [System.Serializable]
    public class RaiseBoolAttribute  : RaiseButtonAttribute
    {
        new public bool ObjectType;
        public RaiseBoolAttribute(string buttonLabel = "Raise Bool", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
            base.ObjectType = false;
        }
    }

    [System.Serializable]
    public class RaiseObjectAttribute  : RaiseButtonAttribute
    {
        public RaiseObjectAttribute(string buttonLabel = "Raise Object", int columnSize = 5)
        {
            ButtonLabel = buttonLabel;
            PropertyColumnSize = columnSize;
            base.ObjectType = new object();
        }
    }
}