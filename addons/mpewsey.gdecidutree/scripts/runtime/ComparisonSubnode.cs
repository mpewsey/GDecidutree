using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.ComparisonSubnode)]
    public partial class ComparisonSubnode : BehaviorSubnode
    {
        [Export] public StringName Key { get; set; }
        [Export] public StringName Property { get; set; }
        [Export] public ComparisonType ComparisonType { get; set; }
        [Export] public double Value { get; set; }

        public override BehaviorSubnode CreateInstance()
        {
            return (BehaviorSubnode)Duplicate();
        }

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