// PlayerCombat.cs
using System.Collections;
using UnityEngine;

// 玩家战斗控制
public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;     // 攻击判定点
    public float attackRange = 0.5f;  // 攻击范围
    public LayerMask enemyLayers;     // 敌人所在层
    public int attackDamage = 20;     // 普通攻击伤害
    public float attackRate = 2f;     // 攻击频率
    private float nextAttackTime = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 使用空格键进行攻击，并检查冷却时间
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        // 播放攻击动画
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // 触发动画参数:contentReference[oaicite:7]{index=7}
        }
        // 检测攻击范围内的敌人
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            EntityStats stats = enemy.GetComponent<EntityStats>();
            if (stats != null)
            {
                stats.TakeDamage(attackDamage);
            }
        }
    }

    // 在Scene视图中绘制攻击范围
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
