// SkillData.cs
using UnityEngine;

// 定义技能数据的 ScriptableObject
[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObjects/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    public string skillName; // 技能名称
    public int damage;       // 技能伤害
    public float cooldown;   // 冷却时间
}
