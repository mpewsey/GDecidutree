using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class StatusNode : BehaviorNode
    {
        [Export] public BehaviorStatus Status { get; set; }

        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            return Status;
        }
    }
}