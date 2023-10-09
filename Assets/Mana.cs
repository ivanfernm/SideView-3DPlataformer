public class Mana  
{
    public float ManaPoints { get; private set; }

    public Mana(float manaPoints)
    {
        ManaPoints = manaPoints;
    }

    public void AddMana(float manaPoints)
    {
        ManaPoints += manaPoints;
    }

    public void RemoveMana(float manaPoints)
    {
        ManaPoints -= manaPoints;
    }

}
