using UnityEngine;

[CreateAssetMenu]
public class SavePlayerPosition : ScriptableObject
{
    [SerializeField] private Vector3 _playerPosition;

    public Vector3 GetPlayerPosition()
    {
        return _playerPosition;
    }

    public void SetPlayerPosition(Vector3 PlayerPosition)
    {
        _playerPosition = PlayerPosition;
    }
}
