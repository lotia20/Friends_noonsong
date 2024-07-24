using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Location;

public class MapManager : MonoBehaviour
{
    public GameObject mapPanel; // 맵 패널
    public Button mapButton; // 맵 버튼
    public Button backButton; // 뒤로 버튼
    public AbstractMap map; // Mapbox 맵

    void Start()
    {
        // 초기 상태에서 맵 패널 비활성화
        mapPanel.SetActive(false);

        // 버튼 클릭 이벤트 리스너 추가
        mapButton.onClick.AddListener(ShowMap);
        backButton.onClick.AddListener(HideMap);

        // 맵 초기화
        InitializeMap();
    }

    void ShowMap()
    {
        // 맵 패널 활성화
        mapPanel.SetActive(true);
        // 맵 업데이트
        UpdateMapLocation();
    }

    void HideMap()
    {
        // 맵 패널 비활성화
        mapPanel.SetActive(false);
    }

    void InitializeMap()
    {
        // 현재 위치를 기반으로 맵 초기화
        var locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
        locationProvider.OnLocationUpdated += OnLocationUpdated;
    }

    void OnLocationUpdated(Location location)
    {
        // 현재 위치 기반으로 맵 업데이트
        var mapPosition = new Vector2d(location.LatitudeLongitude.x, location.LatitudeLongitude.y);
        map.UpdateMap(mapPosition, map.Zoom);
    }

    void UpdateMapLocation()
    {
        // 현재 위치 기반으로 맵 업데이트
        var locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
        var currentLocation = locationProvider.CurrentLocation.LatitudeLongitude;
        var mapPosition = new Vector2d(currentLocation.x, currentLocation.y);
        map.UpdateMap(mapPosition, map.Zoom);
    }
}