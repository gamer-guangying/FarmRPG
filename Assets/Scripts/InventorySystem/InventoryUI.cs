// InventoryUI.cs
using UnityEngine;
using UnityEngine.UI;

// 根据 InventoryManager 数据生成背包界面
public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventoryManager; // 背包管理器
    public Transform slotsParent;             // UI槽的父物体（用于布局）
    public GameObject slotPrefab;             // 单个物品槽预制体

    void Start()
    {
        RefreshUI();
    }

    // 刷新背包UI
    public void RefreshUI()
    {
        // 删除旧的UI槽
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }
        // 遍历所有物品槽并创建UI元素
        foreach (InventorySlot slot in inventoryManager.slots)
        {
            GameObject go = Instantiate(slotPrefab, slotsParent);
            // 假设slotPrefab有两个子对象：Image用于显示图标，Text用于显示数量
            Image icon = go.transform.Find("Icon").GetComponent<Image>();
            Text qtyText = go.transform.Find("Quantity").GetComponent<Text>();
            icon.sprite = slot.item.icon;
            qtyText.text = slot.quantity.ToString();
        }
    }
}
