using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class ArcherCommon : Guardian
    {
        public override void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,"archer_idle",true);
        }

        protected override void Attack()
        {
            base.Attack();
            float duration = skeletonAnimation.Skeleton.Data.FindAnimation("archer_happy")?.Duration ?? 0f;
            float desiredDuration = 1f / attackSpeed;
            float timeScale = duration/ desiredDuration;
            skeletonAnimation.timeScale = timeScale;
            var entry = skeletonAnimation.state.SetAnimation(0,"archer_happy",false);
            
            Debug.Log(timeScale);
            entry.Complete += (trackEntry) =>
            {
                Target.CurrentHealth -= damage;
                
                if (Vector3.Distance(Tile.transform.position, Target.transform.position) > range || !Target.gameObject.activeInHierarchy)
                {
                    Target = null;
                }
                if (Target == null)
                {
                    skeletonAnimation.state.SetAnimation(0, "archer_idle", true);
                }
                isAttacking = false;
            };
        }
    }
    public static class ArcherAnimation
    {
        
    }
}