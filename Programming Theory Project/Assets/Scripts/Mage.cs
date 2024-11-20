using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    private int mana;

    public int Mana
    {
        get { return mana; }
        set { mana = Mathf.Clamp(value, 0, 100); }
    }

    public Mage(string name)
        : base(name)
    {
        Mana = 100;
    }

    // Method overloading example
    public void CastSpell()
    {
        Debug.Log($"{Name} casts a basic spell");
    }

    public void CastSpell(string spellName)
    {
        Debug.Log($"{Name} casts {spellName}");
    }

    public void CastSpell(string spellName, int manaCost)
    {
        if (Mana >= manaCost)
        {
            Mana -= manaCost;
            Debug.Log($"{Name} casts {spellName} using {manaCost} mana. Remaining mana: {Mana}");
        }
        else
        {
            Debug.Log($"{Name} doesn't have enough mana to cast {spellName}");
        }
    }

    // Implementation of abstract method
    public override void SpecialAbility()
    {
        Debug.Log($"{Name} uses Arcane Burst!");
    }
}
