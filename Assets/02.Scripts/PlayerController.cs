using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _theRigid;
    [SerializeField] private float _gravityScale = 8;

    #region 이동 관련 속성
    [Header("이동 관련 속성")]
    [SerializeField] private float _playerSpeed;
    [SerializeField, Tooltip("플레이어 현재 속도")] private float _playerMaxSpeed;
    float _xPos = 0;
    #endregion

    #region 점프 관련 속성
    [Header("점프 관련 속성")]
    [SerializeField] private float _playerJumpPower;
    [SerializeField] private Transform _playerJumpTransform;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _playerDistance;
    [SerializeField] private int _maxPlayerJumpCount;
    [SerializeField] private bool _isUpsideDown = false;
    Vector2 _distance = Vector2.down;
    private int _currentPlayerJumpCount = 0;
    private bool _isPlayerJump = false;
    #endregion

    #region 프로퍼티

    public bool IsUpsideDown
    {
        get
        {
            return _isUpsideDown;
        }
        set
        {
            _isUpsideDown = value;

            _theRigid.gravityScale = _isUpsideDown ? (_gravityScale * -1) : _gravityScale;
            _distance = _isUpsideDown ? Vector2.up : Vector2.down;
            _playerJumpTransform.localPosition = new Vector2(0, (_isUpsideDown ? 0.5f : -0.5f));
        }
    }
    #endregion

    void Start() => _theRigid = GetComponent<Rigidbody2D>();

    private void Update()
    {
        Move();
        Jump();
        Dash();

        if (Input.GetKeyDown(KeyCode.A))
        {
            IsUpsideDown = !IsUpsideDown;
        }
    }

    void FixedUpdate() => FixedMove();

    /// <summary>
    /// 이동 함수
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
    /// 점프 함수
    /// </summary>
    void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.LeftAlt)) return;

        _isPlayerJump = !Physics2D.Raycast(_playerJumpTransform.position, _distance, _playerDistance, _groundLayerMask);

        if (!_isPlayerJump)
        {
            _currentPlayerJumpCount = _maxPlayerJumpCount;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && _currentPlayerJumpCount > 0)
        {
            _currentPlayerJumpCount--;
            _theRigid.velocity = new Vector2(_theRigid.velocity.x, 0);
            _theRigid.AddForce(_distance * -1 * _playerJumpPower, ForceMode2D.Impulse);
        }
    }
    /// <summary>
    /// Fixed에서 사용되는 이동 함수
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
