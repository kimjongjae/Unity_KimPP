using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObj : MonoBehaviour
{
    public static void CreateProjectObj(bool isOnlyDamage, Unit fromUnit, Unit toUnit, int skillIdx = 0)
    {
        if (isOnlyDamage)
        {
            toUnit.Damage(fromUnit, toUnit);
        }
        else
        {
            if (skillIdx != 0)
            {

            }
            else
            {

            }
        }
    }
}
