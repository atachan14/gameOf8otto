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
        Time.timeScale = 0; // ���Ԓ�~
        Debug.Log("Augment.time.Scale=0");
        // Time.unscaledDeltaTime ���g����2�b�ҋ@����
        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            elapsedTime += Time.unscaledDeltaTime;
            await Task.Yield(); // 1�t���[���ҋ@
        }
        Time.timeScale = 0.5f; // ���Ԃ𔼕��ōĊJ
        Debug.Log("Augment.time.Scale=0.5f");
        await SmoothlyChangeTimeScale(1f, 1f);
    }

    private async Task SmoothlyChangeTimeScale(float targetTimeScale, float duration)
    {
        float startTime = Time.unscaledTime;
        float startTimeScale = Time.timeScale;

        while (Time.unscaledTime - startTime < duration)
        {
            // ���݂̌o�ߎ��ԂɊ�Â��� timeScale ��ύX
            float t = (Time.unscaledTime - startTime) / duration;
            Time.timeScale = Mathf.Lerp(startTimeScale, targetTimeScale, t);

            // �����Ԃŏ����ҋ@
            await Task.Yield(); // 1�t���[���҂�
        }

        // �Ō�Ɋm���ɖڕW�� timeScale �ɓ��B
        Time.timeScale = targetTimeScale;
    }
}
