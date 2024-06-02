using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Unit : MonoBehaviour, UnitAnim, CharacterHandle 
{
    public virtual void Init() { }
}

//��ų ���� ��Ʈ��
public abstract partial class Unit
{
    public virtual void Skill() { }
}

//�ִϸ��̼� ���� ��Ʈ��
public abstract partial class Unit
{
    public virtual void PlayAnim() { }

    public virtual void StopAnim() { }
}
