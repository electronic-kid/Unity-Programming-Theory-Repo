using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Create characters
        Warrior warrior = new Warrior("Aragorn");
        Mage mage = new Mage("Gandalf");

        // Demonstrate polymorphism
        warrior.TakeDamage(50); // Will be reduced by armor
        mage.TakeDamage(50); // Will take full damage

        // Demonstrate special abilities
        warrior.SpecialAbility();
        mage.SpecialAbility();

        // Demonstrate method overloading
        mage.CastSpell();
        mage.CastSpell("Fireball");
        mage.CastSpell("Lightning Strike", 30);
    }
}
