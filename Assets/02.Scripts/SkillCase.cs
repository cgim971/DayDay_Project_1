using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCase : MonoBehaviour
{
    [SerializeField] SkillBase _skill;
    /// <summary>
    /// 이거는 스킬 바꿀 때 사용 만약에 초기 값 없으면 null로 적용 할 거에용
    /// </summary>
    /// <param name="skill"></param>
    public void SetSkill(SkillBase skill = null)
    {
        _skill = skill;
    }

    /// <summary>
    /// 스킬 사용 할 때
    /// </summary>
    /// <returns></returns>
    public float UseSkill()
    {
        float delay;
        _skill.UseSkill(out delay);

        return delay;
    }
}
