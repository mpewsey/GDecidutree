using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class ComparisonNode : BehaviorNode
    {
        [Export] public StringName Key { get; set; }
        [Export] public StringName Property { get; set; }
        [Export] public ComparisonType ComparisonType { get; set; }
        [Export] public double Value { get; set; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            var value = Blackboard.GetPropertyValue<double>(Key, Property);

            if (Comparison.IsSatisfied(ComparisonType, value, Value))
                return BehaviorStatus.Success;

            return BehaviorStatus.Failure;
        }
    }
}