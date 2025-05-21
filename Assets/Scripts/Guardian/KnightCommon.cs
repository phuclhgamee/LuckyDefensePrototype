

namespace LuckyDenfensePrototype
{
    public class KnightCommon : Guardian
    {
        public override void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,"idle",true);
        }
    }
}