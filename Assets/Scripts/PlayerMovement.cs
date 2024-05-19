using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private SavePlayerPosition _playerPosition;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Collider2D _boundaryCollider;
    [SerializeField] private Sprite idleHorizontalSprite; // Спрайт для направлений влево и вправо
    [SerializeField] private Sprite idleUpSprite; // Спрайт для направления вверх
    [SerializeField] private Sprite idleDownSprite; // Спрайт для направления вниз

    private SpriteRenderer _characterSprite;
    private Rigidbody2D _rigidbody;
    private Animator _animation;

    private Vector2 _boundaryCenter;
    private float _boundaryRadius;
    private Vector2 _boundarySize;

    private Vector2 _lastDirection; // Последнее направление движения

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.position = _playerPosition.GetPlayerPosition();
        }

        _animation = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponentInChildren<SpriteRenderer>();

        Vector3 newPositon = transform.position;

        transform.position = newPositon;

        if (_boundaryCollider != null)
        {
            if (_boundaryCollider is CircleCollider2D circleCollider)
            {
                _boundaryCenter = circleCollider.transform.position;
                _boundaryRadius = circleCollider.radius * Mathf.Max(circleCollider.transform.localScale.x, circleCollider.transform.localScale.y);
            }
            else if (_boundaryCollider is BoxCollider2D boxCollider)
            {
                _boundaryCenter = boxCollider.transform.position;
                _boundarySize = boxCollider.size * (Vector2)boxCollider.transform.localScale;
            }
            else
            {
                Debug.LogError("Unsupported Collider type!");
            }
        }
        else
        {
            Debug.LogError("Boundary Collider is not assigned!");
        }
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float verticalInput = Input.GetAxis(Vertical);
        float horizontalInput = Input.GetAxis(Horizontal);

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 newPosition = (Vector2)transform.position + movement * _moveSpeed * Time.deltaTime;

        if (_boundaryCollider is CircleCollider2D)
        {
            if (Vector2.Distance(newPosition, _boundaryCenter) <= _boundaryRadius)
            {
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }
            else
            {
                Vector2 direction = (newPosition - _boundaryCenter).normalized;
                Vector2 clampedPosition = _boundaryCenter + direction * _boundaryRadius;
                transform.position = new Vector3(clampedPosition.x, clampedPosition.y, transform.position.z);
            }
        }
        else if (_boundaryCollider is BoxCollider2D)
        {
            Vector2 halfSize = _boundarySize / 2;
            Vector2 clampedPosition = new Vector2(
                Mathf.Clamp(newPosition.x, _boundaryCenter.x - halfSize.x, _boundaryCenter.x + halfSize.x),
                Mathf.Clamp(newPosition.y, _boundaryCenter.y - halfSize.y, _boundaryCenter.y + halfSize.y)
            );
            transform.position = new Vector3(clampedPosition.x, clampedPosition.y, transform.position.z);
        }

        _animation.SetFloat("Horizontal", horizontalInput);
        _animation.SetFloat("Vertical", verticalInput);
        _animation.SetFloat("Speed", movement.sqrMagnitude);

        if (horizontalInput != 0)
        {
            _characterSprite.flipX = horizontalInput > 0;
        }

        if (movement.sqrMagnitude > 0)
        {
            _lastDirection = movement; // Обновляем последнее направление движения
            _animation.enabled = true;
        }
        else
        {
            _animation.enabled = false;
            SetIdleSprite();
        }
    }

    private void SetIdleSprite()
    {
        // Устанавливаем спрайт покоя в зависимости от последнего направления движения
        if (Mathf.Abs(_lastDirection.x) > Mathf.Abs(_lastDirection.y))
        {
            _characterSprite.sprite = idleHorizontalSprite;
            _characterSprite.flipX = _lastDirection.x > 0; // Переворачиваем спрайт влево
        }
        else
        {
            _characterSprite.sprite = _lastDirection.y > 0 ? idleUpSprite : idleDownSprite;
        }
    }
}
