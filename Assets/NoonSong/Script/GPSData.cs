using System.Collections;
using UnityEngine;

public class GPSData : MonoBehaviour
{
    public int id;
    public bool isPlace;

    private Vector2 initialPosition;
    private bool initialPositionCaptured = false;

    // 특정 위치 좌표 (위도, 경도)
    private Vector2 campus1Entrance = new Vector2(37.545849f, 126.964794f); // 숙명여자대학교 1캠퍼스 정문
    private Vector2 campus2Entrance = new Vector2(37.546641f, 126.961242f); // 숙명여자대학교 2캠퍼스 정문
    private Vector2 primeBuilding = new Vector2(37.547423f, 126.963625f); // 숙명여자대학교 프라임관

    private void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location service is not enabled.");
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            Debug.Log("Location service is running.");
            InvokeRepeating("UpdateGPSData", 0, 5f);
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;

            if (!initialPositionCaptured)
            {
                initialPosition = new Vector2(latitude, longitude);
                initialPositionCaptured = true;
                id = AssignID(latitude, longitude, true);
            }
            else
            {
                id = AssignID(latitude, longitude, false);
            }

            isPlace = (id == 1000 || id == 2000 || id == 3000 || id == 3100);
            Debug.Log("ID: " + id);
        }
        else
        {
            Debug.Log("Location service is not running.");
        }
    }

    private int AssignID(float latitude, float longitude, bool isInitial)
    {
        Vector2 currentPosition = new Vector2(latitude, longitude);

        if (isInitial)
        {
            if (initialPosition == campus1Entrance) return 1000;
            if (initialPosition == campus2Entrance) return 2000;
            if (initialPosition == primeBuilding) return 3000;
            return 0;
        }
        else
        {
            if (currentPosition == campus1Entrance) return 1000;
            if (currentPosition == campus2Entrance) return 2000;
            if (currentPosition == primeBuilding) return 3000;
            if (currentPosition == initialPosition) return 3100;
            return 100;
        }
    }

    private void OnDestroy()
    {
        Input.location.Stop();
    }
}
