public class StateMachineFactory
{

    public StateMachineFactory()
    {
    }

    public StateMachine CreateEnemyStateMachine(Enemy enemy, Player target, EnemyAnimationsController animationsController)
    {
        var newStateMachine = new EnemyStateMachine(enemy, target, animationsController);
        return newStateMachine;
    }

}
