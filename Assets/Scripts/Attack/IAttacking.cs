public interface IAttacking
{
    public bool CanAttack { get; }
    public float Radius { get; }

    public void Attack();
}
