using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerSystem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject spritePrefab; // 생성할 스프라이트 프리팹
    private GameObject currentSprite;
    [SerializeField] private Camera mainCamera;
    private bool isCreating = false; // 스프라이트 생성 중 여부

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCreating)
        {
            Ray ray = mainCamera.ScreenPointToRay(eventData.position);
            float distanceFromCamera = 10.0f; // 카메라와 스프라이트의 거리 설정

            Vector3 spawnPosition = ray.origin + ray.direction * distanceFromCamera;
            spawnPosition.z = 0.0f; // 적절한 z 좌표로 설정

            currentSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
            currentSprite.GetComponent<FollowMouse>().StartFollowing();

            isCreating = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isCreating)
        {
            // 스프라이트 생성 중단 및 제거
            currentSprite.GetComponent<FollowMouse>().StopFollowing();
            Destroy(currentSprite);

            isCreating = false;
        }
    }
}
