using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Helper 
{
    // 共通のコルーチンメソッド
    public static IEnumerator Wait(float delay)
    {
        Debug.Log("helperwait mae");
        yield return new WaitForSeconds(delay);
        Debug.Log("helperwait ato");
    }
}

