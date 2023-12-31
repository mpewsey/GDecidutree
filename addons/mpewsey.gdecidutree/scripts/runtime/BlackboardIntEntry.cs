using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BlackboardIntEntry)]
    public partial class BlackboardIntEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public int Value { get; set; }

        public override object GetValue() => Value;
    }
}