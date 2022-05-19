using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Skills", fileName = "WarrirSkill")]
public class WarrirSkill : SkillBase
{
    public override void UseSkill(out float delay)
    {
        base.UseSkill(out delay);

        if (_skillWarrirType == SkillWarrirType.None)
        {

        }
        else if (_skillWarrirType == SkillWarrirType.WieldingSword)
        {
            WidldingSword();
        }
        else if (_skillWarrirType == SkillWarrirType.ThrowingDagger)
        {
            ThrowingDagger();
        }
        else if (_skillWarrirType == SkillWarrirType.Recovery)
        {
            Recovery();
        }
    }

    [SerializeField] private GameObject slashObj;
    float radius = 2f;
    void WidldingSword()
    {

        PlayerController playerTransform = GameManager._instance._playerController;
        GameObject newSlash = Instantiate(slashObj, null);

        float posX = -Mathf.Sin((playerTransform.Angle - 90) * Mathf.Deg2Rad) * radius;
        float posY = Mathf.Cos((playerTransform.Angle - 90) * Mathf.Deg2Rad) * radius;

        newSlash.transform.position = new Vector2(playerTransform.transform.position.x + posX, playerTransform.transform.position.y + posY);
        newSlash.transform.rotation = Quaternion.Euler(0f, 0f, playerTransform.Angle);

        Destroy(newSlash, 0.2f);
    }
    void ThrowingDagger()
    {
        PlayerController playerTransform = GameManager._instance._playerController;
        GameObject newDagger = Instantiate(slashObj, null);

        float posX = -Mathf.Sin((playerTransform.Angle - 90) * Mathf.Deg2Rad) * radius;
        float posY = Mathf.Cos((playerTransform.Angle - 90) * Mathf.Deg2Rad) * radius;

        newDagger.transform.position = playerTransform.transform.position;
        newDagger.transform.rotation = Quaternion.Euler(0f, 0f, playerTransform.Angle - 90);

        newDagger.GetComponent<Rigidbody2D>().velocity = new Vector2(posX, posY) * 10f;
        newDagger.GetComponent<Attack>()._isDisable = true;

        Destroy(newDagger, 2f);
    }
    void Recovery()
    {

    }
}
