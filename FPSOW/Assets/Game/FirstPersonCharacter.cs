using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacter : MonoBehaviour,IEntity
{
    [SerializeField]
    PlayerData data;
    Ability[] abilities;
    float reloadingTime;
    bool reloading;
    float actualBullets;
    float totalBullets;
    float shootingCooldown;
    bool shooting;
    float shootingTimer;
    Projectile projectile;

    const int numAbilities = 3;
    [SerializeField]
    public CharacterMove move;

    ShootCommand shootCommand;
    ReloadCommand reloadCommand;

    void setCharacter()
    {
        abilities = new Ability[numAbilities];
        for(int i = 0; i< numAbilities; i++)
        {
            abilities[i] = data.abilities[i].GetComponent<Ability>();
            abilities[i].InitAbility(this);
            abilities[i].EAwake();
        }
        reloadingTime = data.reloadingTime;
        reloading = false;
        actualBullets = data.totalBullets;
        totalBullets = data.totalBullets;
        shootingCooldown = data.shootingCooldown;
        shooting = false;
        shootingTimer = 0.0f;

        shootCommand = gameObject.AddComponent<ShootCommand>();
        reloadCommand = gameObject.AddComponent<ReloadCommand>();

        shootCommand.SetShoot(Shoot());
        InputManager.SetInputs("shoot", shootCommand);
        reloadCommand.SetReload(Reload());
        InputManager.SetInputs("reload", reloadCommand);

        InputManager.SetInputs("useAbility_1", abilities[0]);
        InputManager.SetInputs("useAbility_2", abilities[1]);
        InputManager.SetInputs("useAbility_3", abilities[2]);
    }

    public void EAwake()
    {
        setCharacter();
    }

    public void EUpdate(float delta)
    {
       
    }

    IEnumerator Shoot()
    {
        Debug.Log("TOTAL: " + totalBullets + "  ACTUAL: " + actualBullets);

        actualBullets--;
        if (actualBullets <= 0)
            actualBullets = totalBullets;

        yield return null;
    }

    IEnumerator Reload()
    {
        yield return null;
    }
}
