namespace LuckyDenfensePrototype
{
    public class WukongCommon : Guardian
    {
        public override void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,"idle",true);
        }
    }
}