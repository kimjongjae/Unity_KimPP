using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Unit : MonoBehaviour, UnitAnim, CharacterHandle 
{
    public virtual void Init() { }
}

//스킬 관련 컨트롤
public abstract partial class Unit
{
    public virtual void Skill() { }
}

//애니메이션 관련 컨트롤
public abstract partial class Unit
{
    public virtual void PlayAnim() { }

    public virtual void StopAnim() { }
}
