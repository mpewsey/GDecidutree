using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    public abstract partial class BehaviorNode : Node
    {
        [Export] public BehaviorSubnode[] Subnodes { get; set; } = Array.Empty<BehaviorSubnode>();
        public BehaviorTree Tree { get; private set; }
        public BehaviorNode[] Children { get; private set; } = Array.Empty<BehaviorNode>();
        public BehaviorSubnode[] SubnodeInstances { get; private set; } = Array.Empty<BehaviorSubnode>();
        public bool IsInitialized { get; private set; }
        public Blackboard Blackboard => Tree.Blackboard;

        protected abstract void OnInitialize();
        protected abstract BehaviorStatus OnTick();

        public void Initialize(BehaviorTree tree)
        {
            Tree = tree;
            Children = GetChildNodes();
            SubnodeInstances = CreateSubnodes();
            OnInitialize();

            foreach (var node in SubnodeInstances)
            {
                node.Initialize(tree, this);
            }

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

            foreach (var node in SubnodeInstances)
            {
                var status = node.Tick();

                switch (status)
                {
                    case BehaviorStatus.Failure:
                        return BehaviorStatus.Failure;
                    case BehaviorStatus.Success:
                        break;
                    default:
                        throw new NotImplementedException($"Unhandled behavior status: {status}.");
                }
            }

            return OnTick();
        }

        private BehaviorNode[] GetChildNodes()
        {
            var count = GetChildCount();

            if (count == 0)
                return Array.Empty<BehaviorNode>();

            var result = new BehaviorNode[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GetChild<BehaviorNode>(i);
            }

            return result;
        }

        private BehaviorSubnode[] CreateSubnodes()
        {
            if (Subnodes.Length == 0)
                return Array.Empty<BehaviorSubnode>();

            var result = new BehaviorSubnode[Subnodes.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Subnodes[i].CreateInstance();
            }

            return result;
        }
    }
}
