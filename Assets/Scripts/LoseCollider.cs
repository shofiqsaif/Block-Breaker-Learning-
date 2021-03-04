using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour
{
    [SerializeField] SceneLoder SL; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SL.LoadScene("Gameover");
        
    }
}
