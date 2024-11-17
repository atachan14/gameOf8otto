using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeEfect : MonoBehaviour
{
    // 共通のコルーチンメソッド
    public static IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
      }

    public static void ChangeTimeScale(float changeScale)
    {
        Time.timeScale = changeScale;
    }


        public static IEnumerator ChangeTimeScaleOverTime(float startScale, float endScale, float duration)
    {
        float elapsedTime = 0f;
        Time.timeScale = startScale;

        while (elapsedTime < duration)
        {
            Time.timeScale = Mathf.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = endScale;

        Debug.Log("Time.timeScale が目標値に到達しました: " + Time.timeScale);
    }

    public static IEnumerator AugmentGet()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
    }
}


