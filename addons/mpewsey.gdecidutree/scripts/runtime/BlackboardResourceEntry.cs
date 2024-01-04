using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BlackboardResourceEntry)]
    public partial class BlackboardResourceEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public Resource Value { get; set; }

        public override object GetValue() => Value;
    }
}