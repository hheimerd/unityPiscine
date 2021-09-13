using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Player player;
    private Weapon _weapon;
    public Image icon;
    public Text ammo;
    public Text type;

    // Update is called once per frame
    void Update()
    {
        _weapon = player.weapon;
        FillWeaponInfo();
    }

    private void FillWeaponInfo()
    {
        if (_weapon == null)
        {
            icon.enabled = false;
            ammo.text = "-";
            type.text = "No weapon";
            return;
        }
        
        icon.sprite = _weapon.icon;
        icon.enabled = true;
        if (_weapon.type == Weapon.WeaponType.Melee)
            ammo.text = "-";
        else
            ammo.text = _weapon.ammo.ToString();
        type.text = _weapon.type.ToString();
    }
}