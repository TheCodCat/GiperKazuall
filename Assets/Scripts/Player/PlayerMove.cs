using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector3[] _moveDirection;
    [SerializeField] private string _nameScene;
    [SerializeField] private float _minY;
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _addSpeed;
    [SerializeField] private float _timeAddSpeed;
    [SerializeField] private int _delitelSpeed;
    [SerializeField] private Player _player;
    [SerializeField] private LeaderBoard _board;
    private int _moveIndex;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Player.OnNewCoin += AddSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void StartGiveSpeed()
    {
        float _add;
        StartCoroutine(Speeder());
        IEnumerator Speeder()
        {
            _add = _startSpeed / _timeAddSpeed * Time.deltaTime;
            while (_moveSpeed != _startSpeed)
            {
                _moveSpeed += _add;
                _moveSpeed = Mathf.Clamp(_moveSpeed, 0, _startSpeed);
                yield return null;
            }
        }
    }

    private void Move()
    {
        if (Player.instance.GetTypeGame() == TypeGame.Pause) return;

        _rb.velocity = new Vector3 (0, _rb.velocity.y,0) + (_moveDirection[_moveIndex] * _moveSpeed);
        if(transform.position.y <= _minY)
        {
            _rb.isKinematic = true;
            StartCoroutine(Restart());
        }
    }
    private IEnumerator Restart()
    {
        yield return _board.SetScoreLeaderBoard(_player.GetCoin());
        SceneManager.LoadScene(_nameScene);
    }
    private void AddSpeed()
    {
        if (_player.GetCoin() % _delitelSpeed == 0 && _moveSpeed < _maxSpeed)
        {
            _moveSpeed += _addSpeed;
        }
    }

    public void NewDirection(InputAction.CallbackContext context)
    {
        if(context.performed)
            _moveIndex = (_moveIndex + 1) % _moveDirection.Length;
    }

}
