﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public enum CurrencyType { COIN, EXP, HEALTH, OGREKEY, DEMONKEY, ZOMBIEKEY };
    public CurrencyType type;

    private GameObject player;    
    private float speed;    
    private float currentAcc;
    private bool startMoving;
    public float acceleration;
    public float hangTime;
    public float maxDistanceToFloat;
    public float driftSpeed;
    public float driftDistance;
    private Vector2 driftPos;
    public int quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PerformanceStats.collisions++;
        
        if (other.tag == "Player")
        {
            if (type == CurrencyType.COIN)
            {
                // PlayerStats.playerStats.coins += quantity;
                PlayerStats.playerStats.SetLevelUI();
                Destroy(gameObject);
            }
            else if (type == CurrencyType.EXP)
            {
                PlayerStats.playerStats.experience += quantity;
                PlayerStats.playerStats.SetExpUI();
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("ExpPop");
            }
            else if (type == CurrencyType.HEALTH)
            {
                PlayerStats.playerStats.HealCharacter(quantity);
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("HealthPickup");
            }
            else if (type == CurrencyType.DEMONKEY)
            {
                PlayerStats.playerStats.GiveDemonKey();
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("KeyGet");
            }
            else if (type == CurrencyType.OGREKEY)
            {
                PlayerStats.playerStats.GiveOgreKey();
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("KeyGet");
            }
            else if (type == CurrencyType.ZOMBIEKEY)
            {
                PlayerStats.playerStats.GiveZombieKey();
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("KeyGet");
            }
        }
    }

    private void Start()
    {
        player = PlayerStats.playerStats.GetPlayerObject();
        currentAcc = 0;
        speed = 0;
        startMoving = false;
        driftPos = transform.position;
        driftPos.x += Random.Range(-driftDistance, driftDistance);
        driftPos.y += Random.Range(-driftDistance, driftDistance);
    }

    private void Update()
    {
        if (player != null)
        {
            // keeps the coin where it is until the player gets close enough
            if (!startMoving && Vector3.Distance(transform.position, player.transform.position) < maxDistanceToFloat)
            {
                StartCoroutine(WaitBeforeMoving());
                startMoving = true;
            }

            speed += currentAcc;

            if (startMoving)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (currentAcc == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, driftPos, driftSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(hangTime);
        currentAcc = acceleration;
    }
}
