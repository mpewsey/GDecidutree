using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BlackboardFloatEntry)]
    public partial class BlackboardFloatEntry : BlackboardEntryNode
    {
        [Export] public override StringName Key { get; set; }
        [Export] public float Value { get; set; }

        public override object GetValue() => Value;
    }
}