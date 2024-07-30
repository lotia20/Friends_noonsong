using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleHandler : MonoBehaviour
{
  public Toggle sceneToggle;
  public string targetSceneName; // 전환할 씬의 이름

  void Start()
  {
    // 토글의 OnValueChanged 이벤트에 메서드 등록
    sceneToggle.onValueChanged.AddListener(OnToggleValueChanged);
  }

  void OnToggleValueChanged(bool isOn)
  {
    // 토글이 선택되었을 때 (isOn이 true일 때) 씬 전환
    if (isOn)
    {
      SceneManager.LoadScene(targetSceneName);
    }
  }
}
