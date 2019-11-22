using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCommand : Command
{
    IEnumerator reload;

    public void SetReload(IEnumerator reload)
    {
        this.reload = reload;
    }

    public override void Execute()
    {
        Debug.Log("RELOADING");
        StartCoroutine(reload);
    }
}
