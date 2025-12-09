using UnityEngine;
using UnityEngine.Events;
namespace cpluiz.GameEventSystem
{
    public abstract class ScriptableVariable : ScriptableObject{}
    public class ScriptableVariable<T> : ScriptableVariable
    {
        [SerializeField] protected T defaultValue;
        public T DefaultValue {get{ return defaultValue;}}
        [SerializeField] protected T value;
        public T Value {
            get{return this.value;}
            set{
                this.value = value;
                ForceUpdate();
            }
        }
        [HideInInspector] public UnityEvent OnValueChanged;

        public void ForceUpdate()
        {
            OnValueChanged?.Invoke();
        }
        private void OnValidate()
        {
            OnValueChanged?.Invoke();
        }

        private void OnEnable()
        {
            Value = DefaultValue;
        }
    }
}