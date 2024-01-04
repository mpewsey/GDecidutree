using Godot;
using System;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.SelectorNode)]
    public partial class SelectorNode : BehaviorNode
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
                    case BehaviorStatus.Success:
                        return BehaviorStatus.Success;
                    case BehaviorStatus.Failure:
                        break;
                    default:
                        throw new NotImplementedException($"Unhandled behavior status: {status}.");
                }
            }

            return BehaviorStatus.Failure;
        }
    }
}