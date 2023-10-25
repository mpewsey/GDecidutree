using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.Arrow)]
    public partial class SequenceNode : BehaviorNode
    {
        protected override void OnInitialize()
        {

        }

        protected override BehaviorStatus OnTick()
        {
            foreach (var node in Children)
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

            return BehaviorStatus.Success;
        }
    }
}