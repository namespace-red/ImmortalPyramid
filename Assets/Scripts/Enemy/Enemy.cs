using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(MoveTowardsTarget))]
[RequireComponent(typeof(EnemyAnimationsController))]
[RequireComponent(typeof(MeleeAreaAttack))]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public Health Health;
    [HideInInspector] public IMovableTowardsTarget Move;
    [HideInInspector] public MeleeAreaAttack Attack;
    
    [SerializeField] private Player _player;
    private EnemyAnimationsController _animationsController;
    private StateMachine _stateMachine;

    public int RewardMoney { get; } = 1;
    
    private void Start()
    {
        Health = GetComponent<Health>();
        Move = GetComponent<MoveTowardsTarget>();
        Attack = GetComponent<MeleeAreaAttack>();
        _animationsController = GetComponent<EnemyAnimationsController>();
        
        Health.Healing(Health.MaxValue);
        Attack.Radius = 2f;
        
        StateMachineFactory smFactory = new StateMachineFactory();
        _stateMachine = smFactory.CreateEnemyStateMachine(
            this, _player, _animationsController);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }
}
