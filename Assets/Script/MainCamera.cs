using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラのプレイヤー追尾用関数
public class MainCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 cursorPos;
    public float smoothing = 3f;
    public Vector3 targetPosition;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position + offset;
    }

    void Update()
    {
        // マウスカーソルの2次元座標をワールドの3次元座標に変換
        // z座標は決め打ち
        cursorPos.Set(Input.mousePosition.x, Input.mousePosition.y, 10f);
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorPos.Set(cursorPos.x, 0f, cursorPos.z);
        // カーソル座標とプレイヤーの座標の中点＋オフセット座標にカメラを移動
        targetPosition = (player.position + cursorPos) / 2 + offset;
        // ゆっくり移動するように線形補完
        transform.position = Vector3.Lerp(transform.position, targetPosition,  smoothing * Time.deltaTime);
    }
}
