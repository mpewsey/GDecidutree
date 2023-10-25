using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.PlusSign)]
    public partial class CounterSubnode : BehaviorSubnode
    {
        [Export] public StringName Key { get; set; }

        public override BehaviorSubnode CreateInstance()
        {
            return (BehaviorSubnode)Duplicate();
        }

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