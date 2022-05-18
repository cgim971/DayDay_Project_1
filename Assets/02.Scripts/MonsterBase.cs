using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    [SerializeField] private float _hp = 5;
    public void TakeDamaged(float damage)
    {
        _hp -= damage;

        Debug.Log(_hp);

        if(_hp <= 0)
        {
            Debug.Log("죽었다. 몬스터");
        }
    }



}
