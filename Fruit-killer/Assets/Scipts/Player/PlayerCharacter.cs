using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector2 _targetPosition;

    public void MovePlayer()
    {
        _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _targetPosition;
    }

    public bool PlayerIsActive
    {
        get
        {
            return gameObject.activeSelf;
        }
        set
        {
            gameObject.SetActive(value);
        }
    }
}
