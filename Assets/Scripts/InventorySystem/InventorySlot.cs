// InventorySlot.cs
// 存储单个物品和数量的数据结构
[System.Serializable]
public class InventorySlot
{
    public ItemData item; // 物品数据
    public int quantity;  // 数量

    public InventorySlot(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
