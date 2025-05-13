// HealthBar.cs
using UnityEngine;
using UnityEngine.UI;

// 生命值显示条（Slider 控件）
public class HealthBar : MonoBehaviour
{
    public EntityStats entityStats; // 需要显示生命值的实体
    public Slider healthSlider;     // UI Slider控件

    void Update()
    {
        if (entityStats != null && healthSlider != null)
        {
            // 更新Slider值为当前生命比例
            healthSlider.value = (float)entityStats.currentHealth / entityStats.maxHealth;
        }
    }
}
