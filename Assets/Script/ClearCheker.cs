using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCheker : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("接触確認");

        if (other.gameObject.TryGetComponent(out FPSController fPSController) == true)
        {
            // for文を使ってアイテムを持っているか一つずつチェックして
            // それを繰り返してクリアするために必要なアイテムを全て所持しているかを確認する
            // 持っていないアイテムがある場合はfor文の処理を中断する
            for (int i = 0; i < fPSController.itemManager.haveItems.Length; i++)
            {
                // 繰り返し確認する為固定の番号を確認ではなく何番目かで確認する
                if (fPSController.itemManager.haveItems[i])
                {
                    Debug.Log("アイテムを持っている : " + i + "番目");
                }
                else
                {
                    return;
                }
            }

            SceneManager.LoadScene("GameClear");

        }
    }
}
