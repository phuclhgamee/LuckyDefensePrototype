using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Boss : Enemy
    {
        [SerializeField] private Event onBossKilled;

        protected override void BossKilled()
        {
            base.BossKilled();
            onBossKilled.Raise();
        }
    }
}