// EntityStats.cs
using UnityEngine;

// 管理实体的属性和生命值
public class EntityStats : MonoBehaviour
{
    public int maxHealth = 100;    // 最大生命值
    public int currentHealth;      // 当前生命值

    void Start()
    {
        currentHealth = maxHealth;
    }

    // 受到伤害处理
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    // 实体死亡
    private void Die()
    {
        // 添加死亡逻辑，如播放动画
        Destroy(gameObject);
    }
}
