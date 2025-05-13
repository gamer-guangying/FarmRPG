// ItemData.cs
using UnityEngine;

// 定义物品数据的 ScriptableObject
[CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName;   // 物品名称
    public Sprite icon;       // 物品图标
    public bool isStackable = true; // 是否可叠加
}
