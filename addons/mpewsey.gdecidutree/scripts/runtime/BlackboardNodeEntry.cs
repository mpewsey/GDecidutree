using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BlackboardNodeEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public Node Value { get; set; }

        public override object GetValue() => Value;
    }
}