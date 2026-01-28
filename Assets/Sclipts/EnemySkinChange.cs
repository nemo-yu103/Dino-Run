using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class EnemySkinChange : MonoBehaviour
{
    [SerializeField]ChangeMapSkin changeMap;
    [SerializeField] SpriteLibrary spriteLibrary;
    [SerializeField] SpriteResolver spriteResolver;

    int animNo = 0;

    // skinNo と対応するキャラクター名（＝Category名）
    [SerializeField]
    string[] characterNames =
    {
        "Bear_brown",
        "Tornado",
        "Bear_polar",
    };

    Coroutine animCoroutine;

    private void Start()
    {
        //GameObject obj = GameObject.Find("SkinManager");
        //changeMap = GetComponent<ChangeMapSkin>();

        
    }


    // ----------------------------
    // ③ 指定キャラのフレーム数を取得 (呼ばなくてよい)
    // ----------------------------
    int GetFrameCount(string characterName)
    {
        int count = 0;
        SpriteLibraryAsset asset = spriteLibrary.spriteLibraryAsset;

        foreach (var label in asset.GetCategoryLabelNames(characterName))
        {
            if (asset.GetSprite(characterName, label) != null)
            {
                count++;
            }
        }
        return count;
    }

    // ----------------------------
    // ④ 指定キャラのフレーム一覧を取得
    // ----------------------------
    List<string> GetFrames(string characterName)
    {
        List<string> frames = new List<string>();
        SpriteLibraryAsset asset = spriteLibrary.spriteLibraryAsset;

        foreach (var label in asset.GetCategoryLabelNames(characterName))
        {
            if (asset.GetSprite(characterName, label) != null)
            {
                frames.Add(label);
            }
        }

        // 0,1,2,3... の順にする
        frames.Sort();
        return frames;
    }

    // ----------------------------
    // ⑤ skinNo でキャラを切り替えてアニメ再生
    // ----------------------------
    public void ChangeAnim()
    {
        animNo = changeMap.skinNo;
        

        if (animNo < 0 || animNo >= characterNames.Length)
        {
            Debug.LogWarning("skinNo が範囲外です");
            return;
        }
        
        string character = characterNames[animNo];

        List<string> frames = GetFrames(character);

        if (frames.Count == 0)
        {
            Debug.LogWarning($"{character} にフレームがありません");
            return;
        }

        // すでに再生中なら止める
        if (animCoroutine != null)
        {
            StopCoroutine(animCoroutine);
        }
        
        animCoroutine = StartCoroutine(PlayCharacterAnim(character, frames));
    }

    // ----------------------------
    // 実際のアニメ再生処理
    // ----------------------------
    IEnumerator PlayCharacterAnim(string category, List<string> frames)
    {
        int frame = 0;

        while (true)
        {
            spriteResolver.SetCategoryAndLabel(category, frames[frame]);
            frame = (frame + 1) % frames.Count;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
