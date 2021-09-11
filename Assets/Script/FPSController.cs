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

    // 変数の宣言
    bool cursorLock = true;

    // 変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    public Transform doorDirection;

    // 変数の宣言(アニメーション用)
    public Animator animator;

    public ItemManager itemManager;

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // アップデートでマウスの入力を受け取り、その動きをカメラに反映
    // アップデートで各ボタンの入力を確認したらアニメーション遷移
    // 歩き・走り
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y")　* Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        // 作成した関数をUPdateで呼び出す
        UpdateCursorLock();

        Opening();

        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)
        {
            if (!animator.GetBool("Walk"))
            {
                animator.SetBool("Walk", true);
            }
        }
        else if(animator.GetBool("Walk"))
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
                speed = 0.4f;
            }
        }
        else if (animator.GetBool("Run"))
        {
            animator.SetBool("Run", false);
            speed = 0.1f;
        }
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

    // マウスカーソルの表示を切り替える関数を作成する
    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        // q = x, y, z, w (x, y, zはベクトル(量と向き) : wはスカラー(座標とは無関係の量))

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    public void Opening()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            Debug.DrawRay(doorDirection.transform.position, doorDirection.transform.forward, Color.yellow);

            if (Physics.Raycast(doorDirection.transform.position, doorDirection.transform.forward, out hitInfo, 100))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out DoorController doorController))
                {
                    doorController.OpeningDoor();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemDetail itemDetail) == true)
        {
            // ItemDetailがゲームオブジェクトにアタッチされていた場合
            // アイテムを獲得する処理を実行する
            itemManager.UpdateHaveItems(itemDetail.GetItem());

            Destroy(itemDetail.gameObject);
        }
    }
}
