using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] private float _hp = 5;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float damage = 0.5f;

    public float Damage
    {
        get { return damage; }
    }

    public void TakeDamaged(float damage)
    {
        _hp -= damage;

        Debug.Log(_hp);

        if (_hp <= 0)
        {
            Debug.Log("죽었다. 몬스터");
            Destroy(gameObject);
        }
    }
    private Rigidbody2D _rigid;
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    float time = 0f;
    public GameObject _target;
    Vector2 pos = Vector2.zero;


    private void Update()
    {
        if (_target == null)
        {
            if (time < 0)
            {
                pos = new Vector2(Random.Range(0, 2f) - 1, Random.Range(0f, 2f) - 1);
                time = 2;
            }
            time -= Time.deltaTime;
        }
        else
        {
            pos = _target.transform.position - transform.position;
        }
        if (pos.x != 0)
        {
            transform.localScale = new Vector3(pos.x > 0 ? 1 : -1, 1, 1);
        }
        pos.Normalize();
        _rigid.velocity = pos * _speed;
    }
}
