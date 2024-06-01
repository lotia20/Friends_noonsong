using UnityEngine;
using UnityEngine.Android;

public class RequestCameraPermission : MonoBehaviour
{
    void Start()
    {
        // 카메라 권한이 있는지 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // 카메라 권한 요청
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
}
