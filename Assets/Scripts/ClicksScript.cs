using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClicksScript : MonoBehaviour
{
    public HexScript starterHex;
    public HexeMatrixScript HexSpawner;
    public TextMeshPro idealText;
    public int idealHex = -1;

    // Start is called before the first frame update
    void Start()
    {
        starterHex = HexSpawner.first.GetComponent<HexScript>();
    }

    // Update is called once per frame
    void Update()
    {
        clicking();
        /*idealHex = starterHex.hexType;
        if (idealHex == -1)
            idealText.text = " ";
        else
            idealText.text = idealHex.ToString();
        */

    }
    public void clicking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
            foreach (Collider2D col in colliders)
            {
                GameObject line = col.gameObject;
                if (line.name.Equals("PressIn"))
                    line.GetComponent<ButtonPressIn>().Clicked();
                if (line.name.Equals("PressNormal"))
                    line.GetComponent<ButtonPressNormal>().Clicked();
                if (line.name.Equals("PressOut"))
                    line.GetComponent<ButtonPressOut>().Clicked();
            }
        }
    }

    public int checkHex(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 1 || bls == 1 || tls == 1 || ts == 1 || trs == 1|| brs == 1)
            return -1;
        if (checkHexOne(bs,bls,tls,ts,trs,brs))
            return 1;
        if (checkHexTwo(bs, bls, tls, ts, trs, brs))
            return 2;
        if (checkHexThree(bs, bls, tls, ts, trs, brs))
            return 3;
        if (checkHexFour(bs, bls, tls, ts, trs, brs))
            return 4;
        if (checkHexFive(bs, bls, tls, ts, trs, brs))
            return 5;
        if (checkHexSix(bs, bls, tls, ts, trs, brs))
            return 6;
        if (checkHexSeven(bs, bls, tls, ts, trs, brs))
            return 7;
        if (checkHexEight(bs, bls, tls, ts, trs, brs))
            return 8;
        return -1;
        
    }
    public int checkHex(int[] lines)
    {
        return checkHex(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5]);
    }
    public bool checkHexOne(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 2 && bls == 2 && tls == 2 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 0 && trs == 0 && brs == 0)
            return true;
        return false;
    }
    public bool checkHexTwo(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 0 && bls == 2 && tls == 2 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 2 && trs == 2 && brs == 0)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexThree(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 0 && bls == 0 && tls == 2 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 0 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 2 && trs == 2 && brs == 0)
            return true;

        if (bs == 2 && bls == 2 && tls == 0 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 2 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexFour(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 0 && bls == 2 && tls == 0 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 2 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 2 && trs == 2 && brs == 0)
            return true;

        if (bs == 2 && bls == 0 && tls == 2 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 0 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexFive(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 0 && bls == 2 && tls == 2 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 2 && trs == 2 && brs == 0)
            return true;

        if (bs == 2 && bls == 0 && tls == 0 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexSix(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 2 && bls == 2 && tls == 2 && ts == 0 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 2 && trs == 2 && brs == 0)
            return true;

        if (bs == 0 && bls == 0 && tls == 0 && ts == 2 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexSeven(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 0 && bls == 0 && tls == 2 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 2 && tls == 0 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 0 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 2 && trs == 2 && brs == 0)
            return true;

        if (bs == 2 && bls == 2 && tls == 0 && ts == 2 && trs == 0 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 2 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 0 && tls == 2 && ts == 2 && trs == 0 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 0 && ts == 2 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 0 && trs == 2 && brs == 2)
            return true;
        if (bs == 2 && bls == 0 && tls == 2 && ts == 0 && trs == 0 && brs == 2)
            return true;
        return false;
    }
    public bool checkHexEight(int bs, int bls, int tls, int ts, int trs, int brs)
    {
        if (bs == 2 && bls == 0 && tls == 2 && ts == 0 && trs == 2 && brs == 0)
            return true;
        if (bs == 0 && bls == 2 && tls == 0 && ts == 2 && trs == 0 && brs == 2)
            return true;
        return false;
    }
}
