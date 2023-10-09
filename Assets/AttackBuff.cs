using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PoweupEffect/AttackBuff")]
public class AttackBuff : PoweupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<SwordAttack>().damage += amount;
    }
}
