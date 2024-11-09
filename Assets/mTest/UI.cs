using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerScript player; // PlayerScriptの参照
    public GameObject lifePrefab; // ライフの表示用Prefab
    private List<GameObject> lifeIcons = new List<GameObject>(); // ライフアイコンのリスト

    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeDisplay(player.getLife()); // 初期ライフ表示を設定
    }

    // プレイヤーのライフが変わったときに呼び出すメソッド
    public void UpdateLifeDisplay(int life)
    {
        // 既存のライフアイコンをすべて削除
        foreach (var icon in lifeIcons)
        {
            Destroy(icon);
        }
        lifeIcons.Clear();

        // 新しいライフアイコンを表示
        Vector3 lifeDisplayStart = new Vector3(0, 0, 0); // 表示開始位置
        for (int i = 0; i < life; i++)
        {
            GameObject icon = Instantiate(lifePrefab, lifeDisplayStart + Vector3.right * i, Quaternion.identity, transform);
            lifeIcons.Add(icon); // アイコンをリストに追加
        }
    }
}