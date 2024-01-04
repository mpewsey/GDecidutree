using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BehaviorNode)]
    public abstract partial class BlackboardEntryNode : Node
    {
        public abstract StringName Key { get; set; }
        public abstract object GetValue();
    }
}