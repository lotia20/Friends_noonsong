using UnityEngine;

[ExecuteInEditMode]
public class EditorCamera : MonoBehaviour
{
    public Camera editorCamera;

    private void OnEnable()
    {
        if (!Application.isPlaying && editorCamera != null)
        {
            editorCamera.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (editorCamera != null)
        {
            editorCamera.gameObject.SetActive(false);
        }
    }
}