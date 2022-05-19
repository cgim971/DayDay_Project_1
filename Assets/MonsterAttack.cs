using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    float damage = 0;
    private void Start()
    {
        damage = transform.GetComponentInParent<MonsterBase>().Damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hp -= damage;
        }
    }
    private float _time = 0;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_time < 0)
            {
                other.GetComponent<PlayerController>().Hp -= damage;
                _time = 0.5f;
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }
    }
}
