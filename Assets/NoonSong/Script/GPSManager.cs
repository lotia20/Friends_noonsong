using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPSManager : MonoBehaviour
{
    public Text textUI;
    public GameObject[] popUps; // 7개의 팝업을 배열로 관리
    public bool[] isVisited; // 3개의 위치 방문 여부를 배열로 관리
    public double[] lats; // 3개의 위도 배열
    public double[] longs; // 3개의 경도 배열
    public Animator popup_anim;
    public GameManager gameManager; // GameManager에서 Talk 가져오기s

    private int currentIndex = 0; // 현재 순서

    IEnumerator Start()
    {
        while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            yield return null;
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start(10, 1);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude);
            StartCoroutine(gameManager.ShowInitialDialogues()); // 초기 대화 표시
            while (true)
            {
                yield return null;
                textUI.text = Input.location.lastData.latitude + "/" + Input.location.lastData.longitude;
            }
        }
    }

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            double myLat = Input.location.lastData.latitude;
            double myLong = Input.location.lastData.longitude;

            // 현재 인덱스 위치에 대한 거리 계산
            if (currentIndex < lats.Length && !isVisited[currentIndex])
            {
                double remainDistance = distance(myLat, myLong, lats[currentIndex], longs[currentIndex]);

                if (remainDistance <= 1f) // 1m
                {
                    isVisited[currentIndex] = true;
                    gameManager.ShowDialogueAtLocation(currentIndex); // 대화 표시
                    currentIndex++; // 다음 위치로 이동
                }
            }
        }
    }

    private double distance(double lat1, double lon1, double lat2, double lon2)
    {
        double theta = lon1 - lon2;
        double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
        dist = Math.Acos(dist);
        dist = Rad2Deg(dist);
        dist = dist * 60 * 1.1515;
        dist = dist * 1609.344; // 미터 변환
        return dist;
    }

    private double Deg2Rad(double deg)
    {
        return (deg * Mathf.PI / 180.0f);
    }

    private double Rad2Deg(double rad)
    {
        return (rad * 180.0f / Mathf.PI);
    }
}
