using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text actionLogText;
    public Font buttonFont;
    private Queue<string> actionLog = new Queue<string>();
    private const int maxLogEntries = 5;

    public GameObject warriorPrefab;
    public GameObject magePrefab;

    private Warrior warrior;
    private Mage mage;
    private CharacterVisuals warriorVisuals;
    private CharacterVisuals mageVisuals;

    void Start()
    {
        // Spawn characters
        GameObject warriorObj = Instantiate(
            warriorPrefab,
            new Vector3(-2, 0, 0),
            Quaternion.identity
        );
        GameObject mageObj = Instantiate(magePrefab, new Vector3(2, 0, 0), Quaternion.identity);

        // Setup characters
        warrior = new Warrior("Aragorn");
        mage = new Mage("Gandalf");

        // Setup visuals
        warriorVisuals = warriorObj.GetComponent<CharacterVisuals>();
        mageVisuals = mageObj.GetComponent<CharacterVisuals>();
        warriorVisuals.Initialize(warrior);
        mageVisuals.Initialize(mage);

        // Add demo buttons
        CreateDemoButtons();
    }

    void AddToLog(string message)
    {
        actionLog.Enqueue(message);
        if (actionLog.Count > maxLogEntries)
            actionLog.Dequeue();

        // Update UI
        string fullText = "";
        foreach (string entry in actionLog)
        {
            fullText += entry + "\n";
        }
        actionLogText.text = fullText;
    }

    void CreateDemoButtons()
    {
        // Create buttons for demonstrations
        CreateButton(
            "Damage Warrior",
            new Vector2(-200, -90),
            () =>
            {
                warrior.TakeDamage(20);
                warriorVisuals.PlayDamageAnimation();
                warriorVisuals.UpdateBars(warrior.GetHealth() / 100f);
                AddToLog("Warrior took 20 damage.");
            }
        );

        CreateButton(
            "Damage Mage",
            new Vector2(200, -90),
            () =>
            {
                mage.TakeDamage(20);
                mageVisuals.PlayDamageAnimation();
                mageVisuals.UpdateBars(mage.GetHealth() / 100f, mage.Mana / 100f);
                AddToLog("Mage took 20 damage.");
            }
        );

        CreateButton(
            "Cast Spell",
            new Vector2(0, -90),
            () =>
            {
                mage.CastSpell("Fireball", 20);
                mageVisuals.UpdateBars(mage.GetHealth() / 100f, mage.Mana / 100f);
                AddToLog("Mage cast Fireball spell.");
            }
        );
    }

    private void CreateButton(string text, Vector2 position, UnityAction action)
    {
        GameObject buttonObj = new GameObject(text + " Button");
        buttonObj.transform.SetParent(GameObject.Find("UI").transform, false);

        // Add CanvasRenderer component for rendering
        CanvasRenderer canvasRenderer = buttonObj.AddComponent<CanvasRenderer>();

        RectTransform rect = buttonObj.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160, 30);
        rect.anchoredPosition = position;

        Button button = buttonObj.AddComponent<Button>();
        button.onClick.AddListener(action);

        // Add Text component
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);
        Text buttonText = textObj.AddComponent<Text>();
        buttonText.text = text;
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;

        // Set the font
        buttonText.font = buttonFont;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.sizeDelta = rect.sizeDelta;
    }
    // void Start()
    // {
    //     // Create characters
    //     Warrior warrior = new Warrior("Aragorn");
    //     Mage mage = new Mage("Gandalf");

    //     // Demonstrate polymorphism
    //     warrior.TakeDamage(50); // Will be reduced by armor
    //     mage.TakeDamage(50); // Will take full damage

    //     // Demonstrate special abilities
    //     warrior.SpecialAbility();
    //     mage.SpecialAbility();

    //     // Demonstrate method overloading
    //     mage.CastSpell();
    //     mage.CastSpell("Fireball");
    //     mage.CastSpell("Lightning Strike", 30);
    // }
}
