using UnityEngine;

public class StaticEnemyController : BaseEnemyController
{
    public override void CheckTransitions()
    {
        
    }

    public override void HasTriggerEnterEnemy()
    {
        base.HasTriggerEnterEnemy();

        _animator.SetTrigger("TriggerArea");
    }

    public override void HasTriggerExitEnemy()
    {
        base.HasTriggerExitEnemy();

        _animator.SetTrigger("Idle");

    }
}
