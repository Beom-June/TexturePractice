using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private bool isFollowing = false; // 마우스 따라다니는 여부를 저장할 변수
    private void Update()
    {
        if (isFollowing)
        {
            // 마우스 위치를 가져옵니다.
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = transform.position.z; // 프리팹과 동일한 z 좌표로 설정

            // 마우스 위치를 월드 좌표로 변환합니다.
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 히트된 지점으로 프리팹을 이동시킵니다.
                transform.position = hit.point;
            }
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
