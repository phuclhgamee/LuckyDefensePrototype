using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Thrower : Guardian
    {
        [SerializeField] private Animator animator;

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void Attack()
        {
            base.Attack();
            animator.speed = attackSpeed;
            animator.SetBool(GuardianAnimation.BoolParamater, true);
        }

        public void OnAttackCompleted()
        {
            Target.CurrentHealth -= damage;
                
            if (Vector3.Distance(Tile.transform.position, Target.transform.position) > range || !Target.gameObject.activeInHierarchy)
            {
                Target = null;
            }
            if (Target == null)
            {
                skeletonAnimation.state.SetAnimation(0, "idle", true);
            }
            isAttacking = false;
        }
    }
}