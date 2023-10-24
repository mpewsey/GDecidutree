using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class ProbabilityNode : BehaviorNode
    {
        [Export] public float ProbabilityOfSuccess { get; set; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            if (Randomizer.ChanceSatisfied(ProbabilityOfSuccess))
                return BehaviorStatus.Success;

            return BehaviorStatus.Failure;
        }
    }
}