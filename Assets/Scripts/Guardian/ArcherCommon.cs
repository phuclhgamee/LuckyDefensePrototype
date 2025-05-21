

namespace LuckyDenfensePrototype
{
    public class ArcherCommon : Guardian
    {
        public override void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,"archer_idle",true);
        }
    }
    public static class ArcherAnimation
    {
        
    }
}