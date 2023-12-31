using Godot;
using MPewsey.GDecidutree.Exceptions;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.BehaviorSubnode)]
    public abstract partial class BehaviorSubnode : Resource
    {
        public BehaviorTree Tree { get; private set; }
        public BehaviorNode Parent { get; private set; }
        public bool IsInitialized { get; private set; }
        public Blackboard Blackboard => Tree.Blackboard;

        public abstract BehaviorSubnode CreateInstance();
        protected abstract void OnInitialize();
        protected abstract BehaviorStatus OnTick();

        public void Initialize(BehaviorTree tree, BehaviorNode parent)
        {
            Tree = tree;
            Parent = parent;
            OnInitialize();
            IsInitialized = true;
        }

        public BehaviorStatus Tick()
        {
            if (!IsInitialized)
                throw new BehaviorSubnodeNotInitializedException($"Behaviour subnode has not been initialized: {this}.");

            return OnTick();
        }
    }
}