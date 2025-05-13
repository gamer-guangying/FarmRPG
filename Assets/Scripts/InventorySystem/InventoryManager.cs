// InventoryManager.cs
using System.Collections.Generic;
using UnityEngine;

// 管理背包物品列表
public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>(); // 物品槽列表

    // 添加物品
    public void AddItem(ItemData item, int count = 1)
    {
        if (item.isStackable)
        {
            // 检查是否已有相同物品，可以叠加
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == item)
                {
                    slot.quantity += count;
                    return;
                }
            }
        }
        // 如果物品不可叠加或列表中不存在，则创建新槽
        slots.Add(new InventorySlot(item, count));
    }

    // 移除物品
    public void RemoveItem(ItemData item, int count = 1)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                slots[i].quantity -= count;
                if (slots[i].quantity <= 0)
                {
                    slots.RemoveAt(i);
                }
                return;
            }
        }
    }
}
