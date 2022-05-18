using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : ScriptableObject
{

    public SkillWarrirType _skillWarrirType;

    public float _delay;

    public virtual void UseSkill(out float delay)
    {
        delay = _delay;
    }
}

public enum SkillWarrirType
{
    None = 0,
    WieldingSword = 1,
    ThrowingDagger = 3,
    Recovery = 7
}