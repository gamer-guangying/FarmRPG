// PlayerController.cs
using UnityEngine;

// 控制玩家移动和动画
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public CharacterData characterData; // 角色基础属性数据
    private CharacterStats stats;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        if (stats != null)
        {
            // 将角色数据应用到 CharacterStats
            stats.baseData = characterData;
        }
    }

    void Update()
    {
        // 读取输入
        float moveX = InputManager.Horizontal;
        float moveY = InputManager.Vertical;
        Vector2 move = new Vector2(moveX, moveY);

        // 更新动画参数
        if (animator != null)
        {
            animator.SetFloat("Horizontal", move.x);
            animator.SetFloat("Vertical", move.y);
            animator.SetFloat("Speed", move.magnitude);
        }
    }

    void FixedUpdate()
    {
        // 物理移动
        Vector2 move = new Vector2(InputManager.Horizontal, InputManager.Vertical);
        rb.velocity = move.normalized * characterData.moveSpeed;
    }
}
