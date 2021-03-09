using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config param
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprits;

    //cashed reference
    Level level;
    GameSession GS;

    //States
    [SerializeField] int timesHits;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        GS = FindObjectOfType<GameSession>();

        if(tag != "Unbreakable")
        {
            level.countBreakableBlocks();
            maxHits = UnityEngine.Random.Range(1, 4);
        }


        

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHits();

        }

    }

    private void HandleHits()
    {
        timesHits++;
        if (timesHits == maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprit();
        }
    }

    private void ShowNextHitSprit()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprits[timesHits];

    }

    private void DestroyBlock()
    {
        level.subBreakableBlocks();
        GS.addToScore();
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        Destroy(gameObject, 0);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(transform.position.x, transform.position.y, 0));
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
