using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _theRigid;


    #region �̵� ���� �Ӽ�
    [Header("�̵� ���� �Ӽ�")]
    [SerializeField] private float _playerSpeed;
    [SerializeField, Tooltip("�÷��̾� ���� �ӵ�")] private float _playerMaxSpeed;
    float _xPos = 0;
    #endregion

    #region ���� ���� �Ӽ�
    [Header("���� ���� �Ӽ�")]
    [SerializeField] private float _playerJumpPower;
    [SerializeField] private Transform _playerJumpTransform;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _playerDistance;
    [SerializeField] private int _maxPlayerJumpCount;
    private int _currentPlayerJumpCount = 0;
    private bool _isPlayerJump = false;
    #endregion

    void Start() => _theRigid = GetComponent<Rigidbody2D>();

    private void Update()
    {
        Move();
        Jump();
        Dash();
    }

    void FixedUpdate() => FixedMove();

    /// <summary>
    /// �̵� �Լ�
    /// </summary>
    void Move()
    {
        if (_xPos == 0)
        {
            _theRigid.velocity = new Vector2(_theRigid.velocity.normalized.x * 0.1f, _theRigid.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(_xPos, transform.localScale.y);
        }
    }
    /// <summary>
    /// ���� �Լ�
    /// </summary>
    void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.LeftAlt)) return;

        _isPlayerJump = !Physics2D.Raycast(_playerJumpTransform.position, Vector2.down, _playerDistance, _groundLayerMask);

        if (!_isPlayerJump)
        {
            _currentPlayerJumpCount = _maxPlayerJumpCount;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && _currentPlayerJumpCount > 0)
        {
            _currentPlayerJumpCount--;
            _theRigid.velocity = new Vector2(_theRigid.velocity.x, 0);
            _theRigid.AddForce(Vector2.up * _playerJumpPower, ForceMode2D.Impulse);
        }
    }
    /// <summary>
    /// Fixed���� ���Ǵ� �̵� �Լ�
    /// </summary>
    void FixedMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _xPos = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
            _theRigid.AddForce(Vector2.right * _xPos * _playerSpeed, ForceMode2D.Impulse);
        }
        else _xPos = 0;

        if (_xPos == 0) return;

        if (_theRigid.velocity.x > _playerMaxSpeed)
        {
            _theRigid.velocity = new Vector2(_playerMaxSpeed, _theRigid.velocity.y);
        }
        else if (_theRigid.velocity.x < _playerMaxSpeed * (-1))
        {
            _theRigid.velocity = new Vector2((-1) * _playerMaxSpeed, _theRigid.velocity.y);
        }
    }

    void Dash()
    {

    }
}
