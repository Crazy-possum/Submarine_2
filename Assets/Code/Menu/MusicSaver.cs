using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSaver : MonoBehaviour
{
    private static MusicSaver _instance;
    [SerializeField] private AudioSource _bgMusic;

    public static MusicSaver Instance { get => _instance; }

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "0" & scene.name == "1")
        {
            _bgMusic.mute = true;
        }
        else
        {
            _bgMusic.mute = false;
        }
    }
}
