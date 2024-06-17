using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountData : Singleton<AccountData>
{
    public Account_Skill account_Skill = null;

    private void Awake()
    {
        account_Skill = new Account_Skill();
    }
}
