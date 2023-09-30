public class StateMachineFactory
{
    public StateMachine CreateEnemyStateMachine(Enemy enemy, ITargetWithHeathData target, EnemyAnimationsController animationsController)
    {
        var newStateMachine = new EnemyStateMachine(enemy, target, animationsController);
        return newStateMachine;
    }
}
