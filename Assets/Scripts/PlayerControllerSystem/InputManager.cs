// InputManager.cs
using UnityEngine;

// 单例模式下读取玩家输入轴
public class InputManager : MonoBehaviour
{
    public static float Horizontal { get; private set; }
    public static float Vertical { get; private set; }

    void Update()
    {
        // 获取水平和垂直轴输入（可在Unity Input设置中定义轴）
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
}
