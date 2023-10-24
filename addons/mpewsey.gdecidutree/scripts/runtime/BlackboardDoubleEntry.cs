using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BlackboardDoubleEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public double Value { get; set; }

        public override object GetValue() => Value;
    }
}