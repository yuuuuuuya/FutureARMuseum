using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    Ray ray;
    float touchTime;

    void Update()
    {
        //押下時
        if (Application.isEditor)
        {
            // デバッグ用
            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Input.mousePosition;
                LongTouchSphere(pos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector3 pos = Input.mousePosition;
                PressSphere(pos);
            }
            if (Input.GetMouseButton(1))
            {

            }

        }
        else
        {
            //スマホ用
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 pos = touch.position;

                if (touch.phase == TouchPhase.Stationary)
                {
                    LongTouchSphere(pos);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    PressSphere(pos);
                }

            }
        }
    }

    // 球体をタップ→球体が離れる
    void PressSphere(Vector3 pos)
    {
        ray = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Sphere")
            {
                if (touchTime > 2.0f)
                {
                    touchTime = 0;
                }
                else
                {
                    rb = hit.collider.GetComponent<Rigidbody>();
                    Vector3 normal = hit.normal;
                    rb.AddForce(-1 * normal * 50);
                }
            }
        }
    }

    // 球体を長押し→球体が近づき中にはいる
    void LongTouchSphere(Vector3 pos)
    {
        ray = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Sphere")
            {
                touchTime += Time.fixedDeltaTime;
                if (touchTime > 2.0f)
                {
                    Vector3 distanceTwo = Camera.main.transform.position - hit.collider.transform.position;
                    rb = hit.collider.GetComponent<Rigidbody>();
                    rb.MovePosition(hit.collider.transform.position + distanceTwo.normalized * Time.fixedDeltaTime * 2);
                }
            }
        }
    }

    // 展示物をダブルタップ
    void DublePress(Vector3 pos)
    {
        ray = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit))
        {
            if (touchTime > 2.0f)
            {
                touchTime = 0;
            }
            else
            {
                Debug.Log("ダブルタップ");
            }
        }
    }
}
