using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject destroyVFX;

    //State variables
    [SerializeField] int timesHit;
    [SerializeField] int maxHits;
    [SerializeField] int scoreToAdd;

    //Cached references
    GameSession gameSession;
    NextLevelDelay nextLevelDelay;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        nextLevelDelay = FindObjectOfType<NextLevelDelay>();

        CountBlocks();
    }

    private void CountBlocks()
    {
        gameSession.blocksRemaining++;

        if(tag == "Breakable")
        {
            gameSession.breakableBlocksRemaining++;
        }

        if(tag != "Breakable")
        {
            gameSession.unbreakableBlocksRemaining++;
        }
    }

    private void SubtractBreakableBlock()
    {
        gameSession.blocksRemaining--;
        gameSession.breakableBlocksRemaining--;

        CheckForWin();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit < maxHits) 
        {
            //Hit VFX 
            GameObject hitParticle = Instantiate(hitVFX, transform.position, transform.rotation);
            Destroy(hitParticle, 1f);
            
        }
        else 
        {
            //Destroy VFX
            GameObject destroyParticle = Instantiate(destroyVFX, transform.position, transform.rotation);
            Destroy(destroyParticle, 1f);
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        gameSession.addToScore(scoreToAdd);
        SubtractBreakableBlock();

        Destroy(gameObject);
    }

    private void CheckForWin()
    {
        if(gameSession.breakableBlocksRemaining == 0)
        {
            Debug.Log("You won next level");
            nextLevelDelay.TriggerNextLevelSequence();
        }
    }

    public int getTimesHit()
    {
        return timesHit;
    }

    public int getMaxHits()
    {
        return maxHits;
    }

}
