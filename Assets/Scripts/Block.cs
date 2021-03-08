using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    Level level;
    GameState GS;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        GS = FindObjectOfType<GameState>();
        level.countBreakableBlocks();

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(transform.position.x, transform.position.y, 0));
        level.subBreakableBlocks();
        GS.addToScore();
        Destroy(gameObject, 0);
    }
}
