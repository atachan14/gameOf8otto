using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Augment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exe()
    {
        PauseAndResume();
        Debug.Log("Augment.Exe end");
    }

    public async void PauseAndResume()
    {
        Time.timeScale = 0; // 時間停止
        Debug.Log("Augment.time.Scale=0");
        // Time.unscaledDeltaTime を使って2秒待機する
        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            elapsedTime += Time.unscaledDeltaTime;
            await Task.Yield(); // 1フレーム待機
        }
        Time.timeScale = 0.5f; // 時間を半分で再開
        Debug.Log("Augment.time.Scale=0.5f");
        await SmoothlyChangeTimeScale(1f, 1f);
    }

    private async Task SmoothlyChangeTimeScale(float targetTimeScale, float duration)
    {
        float startTime = Time.unscaledTime;
        float startTimeScale = Time.timeScale;

        while (Time.unscaledTime - startTime < duration)
        {
            // 現在の経過時間に基づいて timeScale を変更
            float t = (Time.unscaledTime - startTime) / duration;
            Time.timeScale = Mathf.Lerp(startTimeScale, targetTimeScale, t);

            // 実時間で少し待機
            await Task.Yield(); // 1フレーム待つ
        }

        // 最後に確実に目標の timeScale に到達
        Time.timeScale = targetTimeScale;
    }
}
