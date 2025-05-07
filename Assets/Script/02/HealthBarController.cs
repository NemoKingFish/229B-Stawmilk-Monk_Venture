using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private float maxHp;
    private float currentHp;

    public void Initialize(float maxHealth)
    {
        maxHp = maxHealth;
        currentHp = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        UpdateUI();
    }

    public void Heal(float amount)
    {
        currentHp += amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHp / maxHp;
        }
    }
}

