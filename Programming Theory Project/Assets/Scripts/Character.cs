using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base Character class (Parent)
public abstract class Character
{
    private string name;
    private int health;
    private int maxHealth = 100;

    // Encapsulation: Protected properties
    protected string Name
    {
        get { return name; }
        set { name = value; }
    }

    protected int Health
    {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, maxHealth); }
    }

    // Abstract method (Abstraction)
    public abstract void SpecialAbility();

    // Virtual method for polymorphism
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{Name} took {damage} damage. Health: {Health}");
    }

    // Constructor
    protected Character(string name)
    {
        this.Name = name;
        this.Health = maxHealth;
    }
}
