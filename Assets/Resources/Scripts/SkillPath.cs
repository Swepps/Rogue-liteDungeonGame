﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPath
{   
    public SkillPath (Weapon weapon, Special special)
    {
        this.weapon = weapon;
        this.special = special;
    }

    public SkillPath()
    {

    }

    public string title;
    public string description;

    public int path;

    public enum Weapon { BOW, SWORD, STAFF };
    public Weapon weapon;
    public string weaponSprite;

    public enum Special { NONE, DASH, THROWSWORD, THROWDAGGERS, CLOAK, ICEBEAM, DANGERDASH, FIRESPIN, IMPS}
    public Special special;

    public string character;

    public float maxHealth;
    public float healthRegenRate;

    public float maxAbility;
    public float abilityChargeRate;
    public float abilityCost;

    public float attacksPerSecond;
    public float projectileForce;
    public float projectileRange;
    public float damageMin, damageMax;
    public float knockback;
    public int shotSpread;
    public bool parallel;

    public float moveSpeed;   

    public bool invulnerable;

    public static SkillPath[] skillPaths;

    public static void InitialiseSkillPaths()
    {
        skillPaths = new SkillPath[26];

        skillPaths[0] = new SkillPath
        {
            title = "",
            description = "",
            path = 0,
            weapon = Weapon.SWORD,
            weaponSprite = "rusty_sword",
            special = Special.NONE,
            character = "man",
            maxHealth = 50.0f,
            healthRegenRate = 0,
            maxAbility = 50.0f,
            abilityChargeRate = 0,
            abilityCost = 20.0f,
            attacksPerSecond = 2.0f,
            projectileForce = 10.0f,
            projectileRange = 6.0f,
            damageMin = 15.0f,
            damageMax = 17.0f,
            knockback = 20.0f,
            shotSpread = 0,
            parallel = false,
            moveSpeed = 3.0f,
            invulnerable = false
        };

        skillPaths[1] = new SkillPath
        {
            title = "Novice Archer",
            description = "- Increased Fire Rate\n- Quicker Move Speed",
            path = 0,
            weapon = Weapon.BOW,
            weaponSprite = "basic_bow",
            special = Special.NONE,
            character = "elf",
            maxHealth = 50.0f,
            healthRegenRate = 0,
            maxAbility = 50.0f,
            abilityChargeRate = 0,
            abilityCost = 20.0f,
            attacksPerSecond = 3.0f,
            projectileForce = 10.0f,
            projectileRange = 6.0f,
            damageMin = 5.0f,
            damageMax = 10.0f,
            knockback = 10.0f,
            shotSpread = 0,
            parallel = false,
            moveSpeed = 4.0f,
            invulnerable = false
        };

        skillPaths[2] = new SkillPath
        {
            title = "Novice Knight",
            description = "- Swings a sword for lots of damage",
            path = 1,
            weapon = Weapon.SWORD,
            weaponSprite = "regular_sword",
            special = Special.NONE,
            character = "knight",
            maxHealth = 70.0f,
            healthRegenRate = 0.5f,
            maxAbility = 50.0f,
            abilityChargeRate = 0,
            abilityCost = 20.0f,
            attacksPerSecond = 1.5f,
            projectileForce = 10.0f,
            projectileRange = 6.0f,
            damageMin = 20.0f,
            damageMax = 25.0f,
            knockback = 20.0f,
            shotSpread = 0,
            parallel = false,
            moveSpeed = 3.5f,
            invulnerable = false
        };

        skillPaths[3] = new SkillPath
        {
            title = "Novice Mage",
            description = "- Shoots fireballs from his staff",
            path = 2,
            weapon = Weapon.STAFF,
            weaponSprite = "red_magic_staff",
            special = Special.NONE,
            character = "wizard",
            maxHealth = 50.0f,
            healthRegenRate = 0,
            maxAbility = 50.0f,
            abilityChargeRate = 0,
            abilityCost = 20.0f,
            attacksPerSecond = 1.3f,
            projectileForce = 10.0f,
            projectileRange = 8.0f,
            damageMin = 10.0f,
            damageMax = 15.0f,
            knockback = 5.0f,
            shotSpread = 0,
            parallel = false,
            moveSpeed = 3.5f,
            invulnerable = false
        };
    }
}