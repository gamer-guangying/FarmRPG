// Crop.cs
using UnityEngine;

public class Crop : MonoBehaviour
{
    [HideInInspector]
    public CropData data; // 作物的数据定义
    private FarmTile tile; // 所属地块
    private float growthTimer = 0f; // 成长计时器
    public bool isGrown = false; // 是否已成熟
    private SpriteRenderer spriteRenderer;

    // 初始化作物数据
    public void Initialize(CropData data, FarmTile tile)
    {
        this.data = data;
        this.tile = tile;
        // 获取或添加SpriteRenderer用于显示精灵
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        // 设置初始阶段的精灵
        if (data.initialSprite != null)
            spriteRenderer.sprite = data.initialSprite;
    }

    void Update()
    {
        // 如果未成熟，则增加成长时间
        if (!isGrown)
        {
            growthTimer += Time.deltaTime;
            // 达到生长时间后切换为成熟状态
            if (growthTimer >= data.growthTime)
            {
                isGrown = true;
                if (data.grownSprite != null)
                    spriteRenderer.sprite = data.grownSprite; // 切换成熟精灵
            }
        }
    }
}
