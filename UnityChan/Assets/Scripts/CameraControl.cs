using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject parent;
    public GameObject target;

    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;
    void Start()
    {
        parent = transform.parent.gameObject;

        // 기본 위치 저장
        defPosition = transform.position;
        defRotation = parent.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }

    void Update()
    {
        // 왼쪽 드래그로 카메라 이동
        if(Input.GetMouseButton(0))
        {
            target.transform.Translate(
                -Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
                0);
        }
        // 오른쪽 드래그로 카메라 이동
        if(Input.GetMouseButton(1))
        {
            target.transform.Rotate(
                -Input.GetAxis("Mouse Y") * 10,
                -Input.GetAxis("Mouse X") * 10,
                0);
        }
        // 휠 회전으로 확대/축소
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));
            if (Camera.main.fieldOfView < 10)
            {
                Camera.main.fieldOfView = 10;
            }
            else if (Camera.main.fieldOfView > 100)
            {
                Camera.main.fieldOfView = 100;
            }
        }

        // 휠 클릭으로 설정 초기화
        if (Input.GetMouseButton(2))
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}
