// EnemyAI.cs
using UnityEngine;

// 简单的敌人AI：追踪玩家并在靠近时造成伤害
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;       // 移动速度
    public float chaseRange = 5f;      // 侦测玩家的范围
    public float attackRange = 0.5f;   // 攻击距离
    public int attackDamage = 10;      // 攻击伤害
    public float attackCooldown = 1.5f; // 攻击冷却
    private float lastAttackTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= chaseRange)
        {
            // 靠近玩家
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            // 如果在攻击范围内并且冷却完成，则攻击玩家
            if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                // 对玩家造成伤害（假设玩家有 CharacterStats）
                CharacterStats playerStats = player.GetComponent<CharacterStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(attackDamage);
                }
                lastAttackTime = Time.time;
            }
        }
    }
}
