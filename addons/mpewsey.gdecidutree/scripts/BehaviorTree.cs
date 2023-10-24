using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public partial class BehaviorTree : Node
    {
        [Export] public bool InitializeOnReady { get; set; } = true;
        [Export] public Blackboard Blackboard { get; set; }
        [Export] public BehaviorNode Root { get; set; }
        public bool IsInitialized { get; private set; }

        public override void _Ready()
        {
            base._Ready();

            if (InitializeOnReady)
                Initialize();
        }

        public void Initialize()
        {
            if (Blackboard == null)
                throw new Exception($"Behavior tree does not have a blackboard assigned: {this}.");
            if (Root == null)
                throw new Exception($"Behavior tree does not have a root node assigned: {this}.");

            Root.Initialize(this);
            IsInitialized = true;
        }

        public BehaviorStatus Tick()
        {
            if (!IsInitialized)
                throw new Exception($"Behavior tree has not been initialized: {this}.");

            return Root.Tick();
        }
    }
}