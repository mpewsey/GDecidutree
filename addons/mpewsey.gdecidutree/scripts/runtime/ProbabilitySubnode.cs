using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class ProbabilitySubnode : BehaviorSubnode
    {
        [Export] public float ProbabilityOfSuccess { get; set; }

        public override BehaviorSubnode CreateInstance()
        {
            return (BehaviorSubnode)Duplicate();
        }

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