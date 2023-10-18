using Assets.Scripts.GameManager;
using Assets.Scripts.Menu;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    private AudioSource _audioSource;
    /// <summary>
    /// 2 müzik barýndýrýr. ilki ana menü müziðidir
    /// </summary>
    [SerializeField] private AudioClip[] _musics;

    private void OnEnable()
    {
        GameController.OnStartGame += ChangeMusicToInGame;
        MenuManager.OnGameOverPanel += ChangeMusicToMenu;
    }
    private void OnDisable()
    {
        GameController.OnStartGame -= ChangeMusicToInGame;
        MenuManager.OnGameOverPanel -= ChangeMusicToMenu;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
            ChangeMusicToMenu();
        }
    }

    private void ChangeMusicToMenu()
    {
        _audioSource.clip = _musics[0];
        _audioSource.Play();
    }

    private void ChangeMusicToInGame()
    {
        _audioSource.clip = _musics[1];
        _audioSource.Play();
    }

}
