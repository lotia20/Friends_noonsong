using UnityEngine;
using TMPro;  // TextMeshPro 네임스페이스 추가
using UnityEngine.UI;
using System.Collections.Generic;

public class NoonsongManager : MonoBehaviour
{
  public GameObject undiscoveredEntryPrefab;  // 발견되지 않은 항목 프리팹
  public GameObject discoveredEntryPrefab;    // 발견된 항목 프리팹
  public Transform entryParent;               // 도감 항목의 부모 오브젝트
  public List<NoonsongEntry> entries;         // 모든 도감 항목 리스트
  void Start()
  {
    // 디버깅 코드 추후 제거
    if (undiscoveredEntryPrefab == null || discoveredEntryPrefab == null)
    {
      Debug.LogError("Entry prefabs are not set in the inspector!");
    }
    if (entryParent == null)
    {
      Debug.LogError("entryParent is not set in the inspector!");
    }
    if (entries == null)
    {
      Debug.LogError("entries list is not set in the inspector!");
    }
    else if (entries.Count == 0)
    {
      Debug.LogError("entries list is empty!");
    }

    PopulateNoonsong();
  }

  void PopulateNoonsong()
  {
    foreach (Transform child in entryParent)
    {
      Destroy(child.gameObject);
    }

    foreach (var entry in entries)
    {
      GameObject newEntry;
      if (entry.isDiscovered)
      {
        newEntry = Instantiate(discoveredEntryPrefab, entryParent);

        var nameText = newEntry.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        if (nameText != null) nameText.text = entry.noonsongName;
        else Debug.LogError("NameText component missing");

        var universityText = newEntry.transform.Find("UniversityText").GetComponent<TextMeshProUGUI>();
        if (universityText != null) universityText.text = entry.university;
        else Debug.LogError("UniversityText component missing");

        var descriptionText = newEntry.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        if (descriptionText != null) descriptionText.text = entry.description;
        else Debug.LogError("DescriptionText component missing");

        var noonsongImage = newEntry.transform.Find("NoonsongImage").GetComponent<Image>();
        if (noonsongImage != null) noonsongImage.sprite = entry.noonsongSprite;
        else Debug.LogError("NoonsongImage component missing");
      }
      else
      {
        newEntry = Instantiate(undiscoveredEntryPrefab, entryParent);
      }
    }
  }

  public void DiscoverItem(NoonsongEntry entry)
  {
    entry.isDiscovered = true;
    PopulateNoonsong();
  }
}