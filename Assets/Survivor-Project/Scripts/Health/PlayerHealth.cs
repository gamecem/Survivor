using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerHealth : Health
{
    private readonly int GetHitHash = Animator.StringToHash("GetHit");

    [SerializeField] protected PlayerSO playerSO;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        health = playerSO.health;
        maxHealth = playerSO.maxHealth;
        health = maxHealth;
    }
    private void Start()
    {
        OnTakeDamage += HandleTakeDamage;
        OnDie += HandleDie;

        UpdatePlayerHealthDisplay();
    }
    private void OnDestroy()
    {
        OnTakeDamage -= HandleTakeDamage;
        OnDie -= HandleDie;
    }
    private void HandleTakeDamage()
    {
        Debug.Log("Take Damage");
        UpdatePlayerHealthDisplay();
        HandleGetHitAnimation();
    }
    private void HandleDie()
    {
        Debug.Log("Die");
    }
    private void UpdatePlayerHealthDisplay() // Call this function whenever the player takes damage or heals AND on Start
    {
        healthBar.fillAmount = (float)health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }
    private void HandleGetHitAnimation()
    {
        animator.SetTrigger(GetHitHash);
    }
    
    public void HealPlayer(int amount)
    {
        if(health + amount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
        UpdatePlayerHealthDisplay();
    }
}
 