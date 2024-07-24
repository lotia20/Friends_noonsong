using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class GPSManager : MonoBehaviour
{
    public GameObject arObject; // 표시할 AR 오브젝트
    public float targetLatitude = 37.7749f; // 목표 위도
    public float targetLongitude = -122.4194f; // 목표 경도
    public float threshold = 0.0001f; // 거리 허용 오차

    private ARSession arSession;

    void Start()
    {
        arSession = FindObjectOfType<ARSession>();
        arObject.SetActive(false); // 처음에 오브젝트를 비활성화
        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS is not enabled by the user.");
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location.");
            yield break;
        }

        while (true)
        {
            CheckLocation();
            yield return new WaitForSeconds(5); // 5초마다 위치 확인
        }
    }

    void CheckLocation()
    {
        float currentLatitude = Input.location.lastData.latitude;
        float currentLongitude = Input.location.lastData.longitude;

        if (IsWithinThreshold(currentLatitude, currentLongitude, targetLatitude, targetLongitude, threshold))
        {
            arObject.SetActive(true); // 목표 위치에 도달하면 오브젝트 활성화
        }
        else
        {
            arObject.SetActive(false); // 목표 위치에서 벗어나면 오브젝트 비활성화
        }
    }

    bool IsWithinThreshold(float currentLat, float currentLon, float targetLat, float targetLon, float threshold)
    {
        float latDiff = Mathf.Abs(currentLat - targetLat);
        float lonDiff = Mathf.Abs(currentLon - targetLon);
        return latDiff < threshold && lonDiff < threshold;
    }
}