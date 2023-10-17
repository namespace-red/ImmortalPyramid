using UnityEngine;

[CreateAssetMenu(fileName = "StateMachineFactory", menuName = "SO/Factory/StateMachineFactory")]
public class StateMachineFactory : ScriptableObject
{
    public StateMachine CreateEnemyStateMachine(Enemy enemy, ITargetWithHeathData target, IEnemyAnimationsController animationsController)
    {
        var newStateMachine = new EnemyStateMachine(enemy, target, animationsController);
        return newStateMachine;
    }
}
