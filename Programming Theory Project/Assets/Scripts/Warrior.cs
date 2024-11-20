using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    private int armor;

    public int Armor
    {
        get { return armor; }
        set { armor = Mathf.Clamp(value, 0, 100); }
    }

    public Warrior(string name)
        : base(name)
    {
        Armor = 50;
    }

    // Polymorphism: Override of TakeDamage
    public override void TakeDamage(int damage)
    {
        int reducedDamage = damage - (damage * Armor / 100);
        base.TakeDamage(reducedDamage);
    }

    // Implementation of abstract method
    public override void SpecialAbility()
    {
        Debug.Log($"{Name} uses Shield Bash!");
    }
}
