// FarmTile.cs
using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [HideInInspector]
    public bool isPlanted = false; // 地块是否已被种植
    [HideInInspector]
    public Crop currentCrop; // 当前种植的作物实例

    // 在地块上种植作物
    public void PlantCrop(CropData cropData)
    {
        if (isPlanted) return; // 已种植则不执行

        // 使用作物数据中的预制件在此地块位置实例化作物
        GameObject cropGO = Instantiate(cropData.cropPrefab, transform.position, Quaternion.identity, transform);
        Crop cropScript = cropGO.GetComponent<Crop>();
        cropScript.Initialize(cropData, this); // 初始化作物脚本
        currentCrop = cropScript;
        isPlanted = true;
    }

    // 收获作物：移除作物实例
    public void HarvestCrop()
    {
        if (!isPlanted || currentCrop == null) return;
        if (currentCrop.isGrown)
        {
            Destroy(currentCrop.gameObject);
            currentCrop = null;
            isPlanted = false;
        }
    }
}
