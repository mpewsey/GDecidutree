using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BlackboardNode : Node
    {
        [Export] public StringName Key { get; set; }
        [Export] public BlackboardValueType ValueType { get; set; }
        [Export] public Node NodeValue { get; set; }
        [Export] public Resource ResourceValue { get; set; }
        [Export] public int IntValue { get; set; }
        [Export] public float FloatValue { get; set; }

        public object GetValue()
        {
            switch (ValueType)
            {
                case BlackboardValueType.Node:
                    return NodeValue;
                case BlackboardValueType.Resource:
                    return ResourceValue;
                case BlackboardValueType.Int:
                    return IntValue;
                case BlackboardValueType.Float:
                    return FloatValue;
                default:
                    throw new NotImplementedException($"Unhandled blackboard value type: {ValueType}.");
            }
        }
    }
}