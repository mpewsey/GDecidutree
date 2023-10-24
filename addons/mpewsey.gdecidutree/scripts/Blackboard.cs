using Godot;
using System.Collections.Generic;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class Blackboard : Node
    {
        public Dictionary<StringName, object> Entries { get; } = new Dictionary<StringName, object>();

        public void Initialize()
        {
            Clear();
            var count = GetChildCount();

            for (int i = 0; i < count; i++)
            {
                var node = GetChild<BlackboardNode>(i);
                AddValue(node.Key, node.GetValue());
            }
        }

        public void Clear()
        {
            Entries.Clear();
        }

        public bool Remove(StringName key)
        {
            return Entries.Remove(key);
        }

        public T GetValue<T>(StringName key)
        {
            return (T)Entries[key];
        }

        public T GetValue<T>(StringName key, T fallback)
        {
            return Entries.TryGetValue(key, out object value) ? (T)value : fallback;
        }

        public T GetPropertyValue<[MustBeVariant] T>(StringName key, StringName property)
        {
            var value = Entries[key];

            if (!typeof(T).IsSubclassOf(typeof(GodotObject)) || property == null || property.IsEmpty)
                return (T)value;

            var obj = (GodotObject)value;
            return obj.Get(property).As<T>();
        }

        public bool TryGetValue<[MustBeVariant] T>(StringName key, out T value)
        {
            if (Entries.TryGetValue(key, out object obj))
            {
                value = (T)obj;
                return true;
            }

            value = default;
            return false;
        }

        public void AddValue<T>(StringName key, T value)
        {
            Entries.Add(key, value);
        }

        public void SetValue<T>(StringName key, T value)
        {
            Entries[key] = value;
        }

        public void SetValue<T>(StringName key, T value, bool skipIfExists)
        {
            if (!skipIfExists || !Entries.ContainsKey(key))
                Entries[key] = value;
        }
    }
}