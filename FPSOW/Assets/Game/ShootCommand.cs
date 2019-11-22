using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    IEnumerator shoot;

    public void SetShoot(IEnumerator shoot)
    {
        this.shoot = shoot;
    }

    public override void Execute()
    {
        Debug.Log("SHOOTING");
        StartCoroutine(shoot);
    }
}
