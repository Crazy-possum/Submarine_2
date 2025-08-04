using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button SceneLoadButton;
    public int Index;

    private void Awake()
    {
        SceneLoadButton.onClick.AddListener(LoadScene);
    }

    private void OnDestroy()
    {
        SceneLoadButton.onClick.RemoveAllListeners();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(Index);
    }
}