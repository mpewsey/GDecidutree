using Godot;
using MPewsey.GDecidutree.Exceptions;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.Minus)]
    public partial class NegationNode : BehaviorNode
    {
        protected override void OnInitialize()
        {
            if (Children.Length > 1)
                throw new InvalidChildCountException($"Negation node has more than one child: {this}.");

            if (Children.Length == 0)
                throw new InvalidChildCountException($"Negation node has no children: {this}.");
        }

        protected override BehaviorStatus OnTick()
        {
            var status = Children[0].Tick();

            switch (status)
            {
                case BehaviorStatus.Success:
                    return BehaviorStatus.Failure;
                case BehaviorStatus.Failure:
                    return BehaviorStatus.Success;
                default:
                    throw new NotImplementedException($"Unhandled behavior status: {status}.");
            }
        }
    }
}