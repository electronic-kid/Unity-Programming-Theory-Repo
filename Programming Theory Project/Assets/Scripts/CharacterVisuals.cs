using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterVisuals : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar; // Only used for Mage
    public float smoothSpeed = 5f;

    private Character characterReference; // Changed variable name
    private Vector3 initialScale;
    private Color initialColor;
    private Material materialInstance;

    void Start()
    {
        initialScale = transform.localScale;
        materialInstance = GetComponent<Renderer>().material;
        initialColor = materialInstance.color;
    }

    public void Initialize(Character character)
    {
        characterReference = character; // Changed variable name
    }

    public void UpdateBars(float healthPercent, float manaPercent = 1f)
    {
        if (healthBar != null)
            healthBar.fillAmount = healthPercent;
        if (manaBar != null)
            manaBar.fillAmount = manaPercent;
    }

    public void PlayDamageAnimation()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        materialInstance.color = Color.red;
        transform.localScale = initialScale * 1.2f;

        yield return new WaitForSeconds(0.1f);

        materialInstance.color = initialColor;
        transform.localScale = initialScale;
    }
}
