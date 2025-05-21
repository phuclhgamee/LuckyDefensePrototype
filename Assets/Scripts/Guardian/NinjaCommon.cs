

namespace LuckyDenfensePrototype
{
    public class NinjaCommon : Guardian
    {
        public override void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,"idle",true);
        }
    }
}