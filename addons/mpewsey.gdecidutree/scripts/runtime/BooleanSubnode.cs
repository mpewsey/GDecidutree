using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.Bool)]
    public partial class BooleanSubnode : BehaviorSubnode
    {
        [Export] public StringName Key { get; set; }
        [Export] public StringName Property { get; set; }
        [Export] public bool NegateValue { get; set; }

        public override BehaviorSubnode CreateInstance()
        {
            return (BehaviorSubnode)Duplicate();
        }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            var value = Blackboard.GetPropertyValue<bool>(Key, Property);

            if (NegateValue)
                value = !value;

            return value ? BehaviorStatus.Success : BehaviorStatus.Failure;
        }
    }
}