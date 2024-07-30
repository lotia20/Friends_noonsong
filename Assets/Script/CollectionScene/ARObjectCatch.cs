using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectCatch : MonoBehaviour
{
  [SerializeField]
  private ARObjectSpawn arObjectSpawn; 

  [SerializeField]
  private NoonsongEntryManager noonsongEntryManager; 

  [SerializeField]
  private GameObject catchButton; 

  private GameObject currentTarget; 

  void Start()
  {
    catchButton.SetActive(false); 
  }

  void Update()
  {
    CheckForObjectInView();
  }

  void CheckForObjectInView()
  {
    if (arObjectSpawn != null && arObjectSpawn.SpawnedObjects.Count > 0)
    {
      GameObject target = arObjectSpawn.SpawnedObjects[0];
      Vector3 screenPoint = Camera.main.WorldToViewportPoint(target.transform.position);
      bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

      if (onScreen)
      {
        catchButton.SetActive(true);
        currentTarget = target;
      }
      else
      {
        catchButton.SetActive(false);
        currentTarget = null;
      }
    }
  }

  public void OnCatchButtonClicked()
  {
    if (currentTarget != null)
    {
      NoonsongEntry entry = currentTarget.GetComponent<NoonsongEntry>();
      if (entry != null && !noonsongEntryManager.IsEntryInCollection(entry))
      {
        noonsongEntryManager.AddNoonsongEntry(entry);
        Destroy(currentTarget);
        arObjectSpawn.SpawnedObjects.Remove(currentTarget);
        catchButton.SetActive(false);
      }
      else
      {
        Debug.Log("This entry is already in the collection or is invalid.");
      }
    }
  }
}

