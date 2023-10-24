using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BehaviorNode : Node
    {
        public BehaviorTree Tree { get; private set; }
        public BehaviorNode[] Children { get; private set; } = Array.Empty<BehaviorNode>();
        public bool IsInitialized { get; private set; }
        public Blackboard Blackboard => Tree.Blackboard;

        protected abstract void OnInitialize();
        protected abstract BehaviorStatus OnTick();

        public void Initialize(BehaviorTree tree)
        {
            Tree = tree;
            Children = GetChildNodes();
            OnInitialize();

            foreach (var node in Children)
            {
                node.Initialize(tree);
            }

            IsInitialized = true;
        }

        public BehaviorStatus Tick()
        {
            if (!IsInitialized)
                throw new Exception($"Behavior node has not been initialized: {this}.");

            return OnTick();
        }

        private BehaviorNode[] GetChildNodes()
        {
            var count = GetChildCount();

            if (count == 0)
                return Array.Empty<BehaviorNode>();

            var result = new BehaviorNode[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = GetChild<BehaviorNode>(i);
            }

            return result;
        }
    }
}