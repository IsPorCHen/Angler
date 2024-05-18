using System.Collections;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _spotlightSpeed;
    [SerializeField] private float _spotlightCooldown;
    private Transform _spotlight;
    private bool _spotlightCooldownEnabled = false;
    private bool isMoving = false;
    private Vector3 _targetPosition;

    private void Start()
    {
        _spotlight = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_spotlightCooldownEnabled && !isMoving)
        {
            _targetPosition = new Vector3(_player.position.x, _player.position.y, _spotlight.position.z);
            isMoving = true;
        }

        if (isMoving)
        {
            float step = _spotlightSpeed * Time.deltaTime;
            _spotlight.position = Vector3.MoveTowards(_spotlight.position, _targetPosition, step);

            if (Vector3.Distance(_spotlight.position, _targetPosition) < 0.001f)
            {
                isMoving = false;
                _spotlightCooldownEnabled = true;
                StartCoroutine(CooldownTimer(_spotlightCooldown));
            }
        }
    }

    private IEnumerator CooldownTimer(float time)
    {
        yield return new WaitForSeconds(time);
        _spotlightCooldownEnabled = false;
    }
}