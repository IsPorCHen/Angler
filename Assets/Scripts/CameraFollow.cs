using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Collider2D _boundaryCollider;

    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private float limitScaleTops;
    [SerializeField] private float limitScaleSides;

    private void Start()
    {
       
    }
    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 desiredPosition = _target.position;
            desiredPosition.z = transform.position.z;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;

        }
    }
}
