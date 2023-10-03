public class StateMachineFactory
{
    public StateMachine CreateEnemyStateMachine(Enemy enemy, ITargetWithHeathData target, IEnemyAnimationsController animationsController)
    {
        var newStateMachine = new EnemyStateMachine(enemy, target, animationsController);
        return newStateMachine;
    }
}
