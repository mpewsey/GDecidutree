using Godot;

namespace MPewsey.GDecidutree
{
    [GlobalClass]
    [Icon(PluginResources.Icons.DoubleArrow)]
    public partial class RandomSelectorNode : SelectorNode
    {
        protected override BehaviorStatus OnTick()
        {
            Randomizer.Shuffle(Children);
            return base.OnTick();
        }
    }
}