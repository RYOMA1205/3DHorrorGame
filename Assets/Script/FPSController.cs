using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // 移動用の変数を作成
    float x, z;

    // スピード調整用の変数を作成
    float speed = 0.1f;

    // 変数の宣言
    public GameObject cam;
    Quaternion cameraRot, characterRot;

    float Xsensityvity = 3f, Ysensityvity = 3f;

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }
    // アップデートでマウスの入力を受け取り、その動きをカメラに反映
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y")　* Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
    }

    // 入力に合わせてプレイヤーの位置を変更していく
    // カメラの正面方向に進むようにコード記述
    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //transform.position += new Vector3(x, 0, z);
        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }
}
