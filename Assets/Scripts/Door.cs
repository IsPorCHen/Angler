using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private SavePlayerPosition _playerPosition;
    [SerializeField] private int _sceneIndex;
    private bool _playerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (_playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 && _playerPosition != null) 
            {
                _playerPosition.SetPlayerPosition(new Vector3(_player.position.x, _player.position.y, _player.position.z)); 
            }
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            if (_sceneIndex >= 0 && _sceneIndex < sceneCount)
            {
                SceneManager.LoadScene(_sceneIndex);
            }
        }
    }
}
