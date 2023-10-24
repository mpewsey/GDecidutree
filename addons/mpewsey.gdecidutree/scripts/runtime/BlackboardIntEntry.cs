using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class BlackboardIntEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public int Value { get; set; }

        public override object GetValue() => Value;
    }
}