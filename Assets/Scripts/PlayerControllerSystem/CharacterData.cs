// CharacterData.cs
using UnityEngine;

// 定义角色基础属性的 ScriptableObject
[CreateAssetMenu(fileName = "NewCharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public int maxHealth = 100; // 最大生命值
    public int attack = 10;     // 攻击力
    public int defense = 5;     // 防御力
    public float moveSpeed = 5f; // 移动速度
}
