// using Mapbox.Unity.Map;
// using Mapbox.Unity.Utilities;
// using Mapbox.Utils;
// using UnityEngine;

// public class PlaceObjectOnMap : MonoBehaviour
// {
//     [SerializeField]
//     private AbstractMap map;

//     [SerializeField]
//     private GameObject objectPrefab;

//     private Vector3 location = new Vector3(37.7749f, 0, -122.4194f); // 유니티 좌표계에 맞게 Z축 사용

//     [SerializeField]
//     private GameManager gameManager; // GameManager 참조

//     private GameObject spawnedObject;
//     private bool dialogueTriggered = false;

//     void Start()
//     {
//         // 객체를 생성하고 맵상의 위치로 이동
//         spawnedObject = Instantiate(objectPrefab);
//         PositionObject(spawnedObject, location);
//     }

//     void Update()
//     {
//         // 카메라의 현재 위치를 얻어 특정 위치와의 거리를 계산
//         Vector3 cameraLocation = Camera.main.transform.position;
//         float distance = Vector3.Distance(cameraLocation, location);

//         // 특정 거리 이내로 도달하면 대사 호출
//         if (distance < 10f && !dialogueTriggered) // 거리는 적절히 조정 필요
//         {
//             TriggerDialogue();
//         }
//     }

//     private void PositionObject(GameObject obj, Vector3 location)
//     {
//         obj.transform.position = location;
//     }

//     private void TriggerDialogue()
//     {
//         // if (!gameManager.isAction)
//         // {
//         //     gameManager.Talk(0, true); // 초기 대화 시작
//         //     dialogueTriggered = true;
//         // }
//     }
// }
