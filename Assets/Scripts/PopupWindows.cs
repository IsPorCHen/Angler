using UnityEngine;

public class PopupWindows : MonoBehaviour
{
    [SerializeField] private GameObject _Computer;
    private bool _inCollider;

    void Update()
    {
        if (_inCollider && Input.GetKeyDown(KeyCode.F))
        {
            if (!_Computer.activeSelf)
            {
                _Computer.SetActive(true);
            }
            else
            {
                _Computer.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inCollider = false;
            _Computer.SetActive(false);
        }
    }
}
