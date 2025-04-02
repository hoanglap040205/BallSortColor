using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int type;
    public Sprite[] sprites;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    

    public void Selected()
    {
        anim.SetBool("Selected", true);
    }
    public void Deselected()
    {
        anim.SetBool("Selected", false);
    }
    public void SetType(int type)
    {
        this.type = type;
        this.GetComponent<SpriteRenderer>().sprite = sprites[type];
    }
    
    
    
    
    
}
