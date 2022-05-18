using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigid = null;

    private Vector2 _posAmount;

    [SerializeField] private float _speed = 3f;

    Vector2 _mousePos;
    float _angle;
    public float Angle
    {
        get { return _angle; }
    }
    [SerializeField] private List<SkillCase> _skillCases = new List<SkillCase>();

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        StartCoroutine(UseMouseLeftBtn());
        StartCoroutine(UseMouseRightBtn());
        StartCoroutine(UseSpaceBtn());
    }
    private void Update()
    {
        Move();
        Look();

    }
    private void Look()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _angle = Mathf.Atan2(_mousePos.y - transform.position.y, _mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        if (-90 < _angle && _angle < 90) transform.localScale = Vector2.one;
        else transform.localScale = new Vector2(-1, 1);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) _posAmount.x = Input.GetKey(KeyCode.D) ? 1 : -1;
        else _posAmount.x = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) _posAmount.y = Input.GetKey(KeyCode.W) ? 1 : -1;
        else _posAmount.y = 0;

        _posAmount.Normalize();

        _rigid.velocity = _posAmount * _speed;
    }

    private IEnumerator UseMouseLeftBtn()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            yield return new WaitForSeconds(_skillCases[0].UseSkill());
        }
    }
    private IEnumerator UseMouseRightBtn()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));

            Debug.Log("우클릭");

            yield return new WaitForSeconds(_skillCases[1].UseSkill());
        }
    }
    private IEnumerator UseSpaceBtn()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            Debug.Log("스페이스");

            yield return new WaitForSeconds(_skillCases[2].UseSkill());
        }
    }
}
