using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class CooldownCounterNode : BehaviorNode
    {
        [Export] public StringName Key { get; set; }
        [Export] public int InitialCooldown { get; set; }
        [Export] public int Cooldown { get; set; }

        private int _cooldownTurn;
        private int CooldownTurn { get => _cooldownTurn; set => _cooldownTurn = Mathf.Max(value, 0); }

        protected override void OnInitialize()
        {
            CooldownTurn = InitialCooldown;
        }

        protected override BehaviorStatus OnTick()
        {
            return IsCooledDown() ? BehaviorStatus.Success : BehaviorStatus.Failure;
        }

        public bool IsCooledDown()
        {
            Blackboard.TryGetValue(Key, out int turn);
            return turn > CooldownTurn;
        }

        public void BeginCooldown()
        {
            Blackboard.TryGetValue(Key, out int turn);
            CooldownTurn = turn + Mathf.Max(Cooldown, 0);
        }
    }
}