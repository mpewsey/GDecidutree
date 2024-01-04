using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BooleanNode)]
    public partial class BooleanNode : BehaviorNode
    {
        [Export] public StringName Key { get; set; }
        [Export] public StringName Property { get; set; }
        [Export] public bool NegateValue { get; set; }

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