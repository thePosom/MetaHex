using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public int state = 1; //0=out, 1=normal, 2=in
    public int preState = 1;
    // Update is called once per frame
    void Update()
    {
        if (preState != state)
            this.gameObject.transform.parent.GetComponent<HexScript>().setHex();
        preState = state;
    }
    public void changeState(int x)
    {
        preState = x;
        state = x;
    }
}
