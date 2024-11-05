using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gridSize = 1f;
    [SerializeField] private GameObject _segmentPrefab;

    private PlayerInput _playerInput;
    private List<Transform> _segments;
    private Vector2 _direction;
    private Vector3 _nextPosition;
    private float _moveTimer;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _segments = new List<Transform> { transform };
        _direction = Vector2.right;
    }

    private void Update()
    {
        HandleInput();
        Move();
    }

    private void HandleInput()
    {
        Vector2 input = _playerInput.MoveInput;
        if (input != Vector2.zero)
        {
            // Prevent 180-degree turns
            if ((input.x != 0 && _direction.x != -input.x) ||
                (input.y != 0 && _direction.y != -input.y))
            {
                _direction = input;
            }
        }
    }

    private void Move()
    {
        _moveTimer += Time.deltaTime;
        if (_moveTimer >= 1f / _moveSpeed)
        {
            _moveTimer = 0f;

            // Calculate next position
            _nextPosition = transform.position;
            _nextPosition.x += _direction.x * _gridSize;
            _nextPosition.y += _direction.y * _gridSize;

            // Move body
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            // Move head
            transform.position = _nextPosition;
        }
    }

    public void Grow()
    {
        GameObject newSegment = Instantiate(_segmentPrefab);
        newSegment.transform.position = _segments[^1].position;
        _segments.Add(newSegment.transform);
    }

    public bool CheckSelfCollision()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            if (Vector2.Distance(transform.position, _segments[i].position) < 0.1f)
            {
                return true;
            }
        }
        return false;
    }
}
