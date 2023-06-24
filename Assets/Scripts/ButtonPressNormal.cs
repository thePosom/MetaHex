using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressNormal : MonoBehaviour
{
    public SpriteRenderer spriteRendererFront;
    public Sprite newSpriteFront;
    public SpriteRenderer spriteRendererBack;
    public Sprite newSpriteBack;
    // Start is called before the first frame update
    public void Clicked()
    {
        this.transform.parent.GetComponent<LineScript>().state = 1;
        spriteRendererFront.sprite = newSpriteFront;
        spriteRendererBack.sprite = newSpriteBack;
    }
}
