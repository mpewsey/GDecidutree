using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BlackboardEntryNode : Node
    {
        public abstract StringName Key { get; set; }
        public abstract object GetValue();
    }
}