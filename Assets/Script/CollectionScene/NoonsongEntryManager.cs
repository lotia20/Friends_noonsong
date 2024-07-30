using System.Collections.Generic;
using UnityEngine;

public class NoonsongEntryManager : MonoBehaviour
{
  private List<NoonsongEntry> noonsongEntries = new List<NoonsongEntry>();

  public void AddNoonsongEntry(NoonsongEntry entry)
  {
    if (!noonsongEntries.Contains(entry))
    {
      noonsongEntries.Add(entry);
      // UI 팝업 추가 구간
      Debug.Log("added to the collection: " + entry.noonsongName);
    }
  }

  public bool IsEntryInCollection(NoonsongEntry entry)
  {
    return noonsongEntries.Contains(entry);
  }

  public NoonsongEntry[] GetNoonsongEntries()
  {
    return noonsongEntries.ToArray();
  }
}

