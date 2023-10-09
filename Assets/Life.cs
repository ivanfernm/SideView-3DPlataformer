public class Life 
{
    public int Health { get; set; }
    int MaxHealth { get; set; }

    public Life(int maxHealth)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
    }

    public void Damage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int heal)
    {
        Health += heal;
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
    
}
