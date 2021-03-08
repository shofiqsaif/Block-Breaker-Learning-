using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoder sceneLoder;
    private void Start()
    {
        sceneLoder = FindObjectOfType<SceneLoder>();
    }

    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void subBreakableBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0 )
        {
            sceneLoder.LoadNextScene();
        }
    }
}
