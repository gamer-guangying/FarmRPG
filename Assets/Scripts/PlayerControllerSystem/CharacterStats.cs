// CharacterStats.cs
using UnityEngine;

// 管理角色属性和伤害处理
public class CharacterStats : MonoBehaviour
{
    public CharacterData baseData; // 角色基础数据（ScriptableObject）
    public int currentHealth;
    public int attack;
    public int defense;

    void Start()
    {
        // 初始化属性
        currentHealth = baseData.maxHealth;
        attack = baseData.attack;
        defense = baseData.defense;
    }

    // 受到伤害，扣除防御后减少生命值
    public void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - defense, 0);
        currentHealth -= actualDamage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    // 角色死亡处理
    private void Die()
    {
        // 这里简单销毁对象，也可以添加死亡动画等逻辑
        Destroy(gameObject);
    }
}
