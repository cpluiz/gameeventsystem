using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

//GameEventRaiseDrawer
[CustomPropertyDrawer(typeof(VoidButtonAttribute))]
public class GameEventVoidRaiser : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        VoidButtonAttribute buttonAttribute = attribute as VoidButtonAttribute;

        Rect buttonRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName);
            if(method != null)
            {
                method.Invoke(targetObject, null);
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}

[CustomPropertyDrawer(typeof(RaiseIntAttribute))]
public class GameEventRaiserInt : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RaiseIntAttribute buttonAttribute = attribute as RaiseIntAttribute;

        Rect buttonRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        Rect propertyRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName).MakeGenericMethod(typeof(int));
            if(method != null)
            {
                method.Invoke(targetObject, new object[]{property.intValue});
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}

[CustomPropertyDrawer(typeof(RaiseFloatAttribute))]
public class GameEventRaiserFloat : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RaiseFloatAttribute buttonAttribute = attribute as RaiseFloatAttribute;

        Rect buttonRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        Rect propertyRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName).MakeGenericMethod(typeof(float));
            if(method != null)
            {
                method.Invoke(targetObject, new object[]{property.floatValue});
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}

[CustomPropertyDrawer(typeof(RaiseObjectAttribute))]
public class GameEventRaiserObject : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RaiseObjectAttribute buttonAttribute = attribute as RaiseObjectAttribute;

        Rect buttonRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        Rect propertyRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName).MakeGenericMethod(typeof(object));
            if(method != null)
            {
                method.Invoke(targetObject, new object[]{property.objectReferenceValue});
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}

[CustomPropertyDrawer(typeof(RaiseStringAttribute))]
public class GameEventRaiserString : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RaiseStringAttribute buttonAttribute = attribute as RaiseStringAttribute;

        Rect buttonRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        Rect propertyRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName).MakeGenericMethod(typeof(string));
            if(method != null)
            {
                method.Invoke(targetObject, new object[]{property.stringValue});
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}
[CustomPropertyDrawer(typeof(RaiseBoolAttribute))]
public class GameEventRaiserBool : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        RaiseBoolAttribute buttonAttribute = attribute as RaiseBoolAttribute;

        Rect buttonRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        Rect propertyRect = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(propertyRect, property, GUIContent.none);

        if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
        {
            object targetObject = property.serializedObject.targetObject;

            MethodInfo method = targetObject.GetType().GetMethod(buttonAttribute.MethodName).MakeGenericMethod(typeof(bool));
            if(method != null)
            {
                method.Invoke(targetObject, new object[]{property.intValue});
            }
            else
            {
                Debug.LogWarning($"Method '{buttonAttribute.MethodName}' not found");
            }

        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }
}