using UnityEngine;
using UnityEngine.U2D.Animation;

public class EnemySkinChange : MonoBehaviour
{
    public SpriteLibrary sr;

    void Start()
    {
        SpriteLibraryAsset asset = sr.spriteLibraryAsset;

        int totalCount = 0;

        // 全カテゴリを取得
        var categories = asset.GetCategoryNames();

        foreach ( var category in categories)
        {
            // カテゴリ内の全ラベルを取得
            var labels = asset.GetCategoryLabelNames(category);

            foreach (var label in labels)
            {
                // Sprite が存在するものだけカウント
                if (asset.GetSprite(category, label) != null)
                {
                    totalCount++;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
