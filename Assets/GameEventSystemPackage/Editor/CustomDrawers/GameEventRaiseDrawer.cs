#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;
using cpluiz.GameEventSystem;
using System.Linq;

namespace cpluiz.GameEventSystemEditor{
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

                MethodInfo method = targetObject.GetType().GetMethods().Single(m => m.Name == buttonAttribute.MethodName && m.GetParameters().Length == 0);
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

    [CustomPropertyDrawer(typeof(RaiseButtonAttribute))]
    public class GameEventRaiser : PropertyDrawer
    {
        protected UnityEngine.Object target = null;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RaiseButtonAttribute buttonAttribute = attribute as RaiseButtonAttribute;

            float fieldWidth = position.width;
            float columWidth = fieldWidth / buttonAttribute.MaxColumnSize;
            float fieldSize = buttonAttribute.PropertyColumnSize * columWidth;
            float buttonSize = (buttonAttribute.MaxColumnSize - buttonAttribute.PropertyColumnSize) * columWidth;

            Rect propertyRect = new Rect(position.x, position.y, fieldSize , EditorGUIUtility.singleLineHeight);
            Rect buttonRect = new Rect(position.x + fieldSize, position.y, buttonSize, EditorGUIUtility.singleLineHeight);
            if(buttonAttribute.ObjectType.GetType() == typeof(Transform))
                target = (Transform)EditorGUI.ObjectField(propertyRect, target, typeof(Transform), true);
            else if(buttonAttribute.ObjectType.GetType() != typeof(UnityEngine.Object))
                EditorGUI.PropertyField(propertyRect, property, GUIContent.none, true);
            else
                target = (UnityEngine.Object)EditorGUI.ObjectField(propertyRect, target, typeof(UnityEngine.Object), true);

            if(GUI.Button(buttonRect, buttonAttribute.ButtonLabel))
            {
                object targetObject = property.serializedObject.targetObject;
                MethodInfo method = targetObject.GetType().GetMethods().Single( m => m.Name == buttonAttribute.MethodName && m.GetGenericArguments().Length == 1 && m.GetParameters().Length == 1 ).MakeGenericMethod(buttonAttribute.ObjectType.GetType());
                if(method != null)
                {
                    switch (buttonAttribute.ObjectType)
                    {
                        case int intType:
                            method.Invoke(targetObject, new object[]{property.intValue});
                            break;
                        case float floatType:
                            method.Invoke(targetObject, new object[]{property.floatValue});
                            break;
                        case string stringType:
                            method.Invoke(targetObject, new object[]{property.stringValue});
                            break;
                        case bool boolType:
                            method.Invoke(targetObject, new object[]{property.boolValue});
                            break;
                        case Transform transformType:
                            method.Invoke(targetObject, new object[]{target as Transform});
                            break;
                        case UnityEngine.Object objectType:
                            method.Invoke(targetObject, new object[]{target});
                            break;
                        default:
                            Debug.LogError($"Method with type {buttonAttribute.ObjectType.GetType()} don't have a implementation");
                            break;
                    }
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
    public class GameEventRaiserInt : GameEventRaiser
    {
        
    }
    [CustomPropertyDrawer(typeof(RaiseFloatAttribute))]
    public class GameEventRaiserFloat : GameEventRaiser
    {
        
    }
    [CustomPropertyDrawer(typeof(RaiseStringAttribute))]
    public class GameEventRaiserString : GameEventRaiser
    {
        
    }
    [CustomPropertyDrawer(typeof(RaiseBoolAttribute))]
    public class GameEventRaiserBool : GameEventRaiser
    {
        
    }
    [CustomPropertyDrawer(typeof(RaiseTransformAttribute))]
    public class GameEventRaiserTransform : GameEventRaiser
    {
        
    }
    [CustomPropertyDrawer(typeof(RaiseObjectAttribute))]
    public class GameEventRaiserObject : GameEventRaiser
    {
        
    }
}
#endif