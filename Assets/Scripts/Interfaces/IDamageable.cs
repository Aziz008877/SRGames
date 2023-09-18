

public interface IDamageable
{
    float Health { get; set; }

    void ReceiveDamage(float damageValue);
}
