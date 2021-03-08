using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    Level level;
    GameSession GS;

    private void Start()
    {
        level = FindObjectOfType<Level>();
       
        //These piece of code were causing bug.
        // Debug.Log(FindObjectsOfType<GameSession>().Length);
        //GS = FindObjectsOfType<GameSession>()[0];
       // Debug.Log(GS.name);
        level.countBreakableBlocks();

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GS = FindObjectsOfType<GameSession>()[0];
        Debug.Log(GS.name);


        AudioSource.PlayClipAtPoint(breakSound, new Vector3(transform.position.x, transform.position.y, 0));
        level.subBreakableBlocks();
        GS.addToScore();
        Destroy(gameObject, 0);
    }
}
