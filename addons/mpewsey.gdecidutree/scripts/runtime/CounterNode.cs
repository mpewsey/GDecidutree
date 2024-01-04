using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.CounterNode)]
    public partial class CounterNode : BehaviorNode
    {
        [Export] public StringName Key { get; set; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            Blackboard.TryGetValue(Key, out int value);
            Blackboard.SetValue(Key, Mathf.Max(value + 1, 0));
            return BehaviorStatus.Success;
        }
    }
}