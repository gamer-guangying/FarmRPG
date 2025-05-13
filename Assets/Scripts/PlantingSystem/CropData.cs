// CropData.cs
using UnityEngine;

// 定义作物数据的 ScriptableObject
[CreateAssetMenu(fileName = "NewCropData", menuName = "ScriptableObjects/CropData", order = 1)]
public class CropData : ScriptableObject
{
    public string cropName; // 作物名称
    public float growthTime; // 成长时间（秒）
    public Sprite initialSprite; // 播种时显示的精灵
    public Sprite grownSprite; // 成熟时显示的精灵
    public GameObject cropPrefab; // 用于实例化作物的预制件

    // 以上字段存储作物的共享数据:contentReference[oaicite:1]{index=1}。
}
