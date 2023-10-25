using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.PercentSign)]
    public partial class ModulusNode : BehaviorNode
    {
        [Export] public StringName Key { get; set; }
        [Export] public StringName Property { get; set; }
        [Export] public int Modulus { get; set; } = 1;
        [Export] public ComparisonType ComparisonType { get; set; }
        [Export] public int Value { get; set; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            var value = Blackboard.GetPropertyValue<int>(Key, Property);

            if (Comparison.IsSatisfied(ComparisonType, value % Modulus, Value))
                return BehaviorStatus.Success;

            return BehaviorStatus.Failure;
        }
    }
}