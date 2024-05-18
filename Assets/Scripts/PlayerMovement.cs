using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Collider2D _boundaryCollider;

    private SpriteRenderer _characterSprite;
    private Rigidbody2D _rigidbody;
    private Animator _animation;

    private float leftLimit;
    private float rightLimit;
    private float upperLimit;
    private float bottomLimit;

    public void Start()
    {
        _animation = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponentInChildren<SpriteRenderer>();

        Vector3 newPositon = transform.position;

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            newPositon.y = PlayerPrefs.GetFloat("PlayerPositionY");
        }

        transform.position = newPositon;

        if (_boundaryCollider != null)
        {
            Bounds bounds = _boundaryCollider.bounds;

            leftLimit = bounds.min.x;
            rightLimit = bounds.max.x;
            bottomLimit = bounds.min.y;
            upperLimit = bounds.max.y;
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

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
        );

        _animation.SetFloat("Horizontal", horizontalInput);
        _animation.SetFloat("Vertical", verticalInput);
        _animation.SetFloat("Speed", movement.sqrMagnitude);

        // Поворачиваем спрайт в зависимости от направления движения
        if (horizontalInput != 0)
        {
            _characterSprite.flipX = horizontalInput > 0;
        }
    }
}
