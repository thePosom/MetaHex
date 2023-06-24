using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexScript : MonoBehaviour
{
    public ClicksScript idealHex;
    public HexeMatrixScript HexeMatrixScript;
    public SpriteRenderer xHex;
    public TextMeshPro hexText;
    public HexScript BottomHex;
    public HexScript BottomRightHex;
    public HexScript BottomLeftHex;
    public HexScript TopHex;
    public HexScript TopRightHex;
    public HexScript TopLeftHex;
    public int hexNum;
    public int hexType = -1;
    public int bs = 1;
    public int bls = 1;
    public int tls = 1;
    public int ts = 1;
    public int trs = 1;
    public int brs = 1;
    // Start is called before the first frame update
    void Start()
    {
        hexNum = stringToInt(this.name);
        idealHex = GameObject.FindWithTag("Logic").GetComponent<ClicksScript>();
        HexeMatrixScript = GameObject.FindWithTag("HexeMatrix").GetComponent<HexeMatrixScript>();
        sideHexs();
    }

    // Update is called once per frame
    void Update()
    {
        if (hexType != -1)
            hexText.text = hexType.ToString();
        else
            hexText.text = " ";
        if (hexType != -1 && !HexeMatrixScript.checkHex(hexType))
        {
            xHex.enabled = true;

        }
        else
        {
            xHex.enabled = false;
        }
        hexType = idealHex.checkHex(bs, bls, tls, ts, trs, brs);
    }

    public void updateHex()
    {
        if (bs == 0)
            this.transform.Find("LineBottom").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (bs == 1)
            this.transform.Find("LineBottom").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (bs == 2)
            this.transform.Find("LineBottom").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();

        if (bls == 0)
            this.transform.Find("LineBottomLeft").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (bls == 1)
            this.transform.Find("LineBottomLeft").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (bls == 2)
            this.transform.Find("LineBottomLeft").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();

        if (tls == 0)
            this.transform.Find("LineTopLeft").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (tls == 1)
            this.transform.Find("LineTopLeft").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (tls == 2)
            this.transform.Find("LineTopLeft").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();

        if (ts == 0)
            this.transform.Find("LineTop").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (ts == 1)
            this.transform.Find("LineTop").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (ts == 2)
            this.transform.Find("LineTop").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();

        if (trs == 0)
            this.transform.Find("LineTopRight").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (trs == 1)
            this.transform.Find("LineTopRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
        if (trs == 2)
            this.transform.Find("LineTopRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();

        if (brs == 0)
            this.transform.Find("LineBottomRight").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (brs == 1)
            this.transform.Find("LineBottomRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
        if (brs == 2)
            this.transform.Find("LineBottomRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void sideHexs()
    {
        int h = HexeMatrixScript.height;
        int l = HexeMatrixScript.length;

        if ((hexNum % h) != 0)
            BottomHex = GameObject.Find("HexClone " + (hexNum - 1)).GetComponent<HexScript>();
        else
            BottomHex = GameObject.Find("HexClone " + (hexNum + h - 1)).GetComponent<HexScript>();

        if ((hexNum - h) >= 0)
            BottomLeftHex = GameObject.Find("HexClone " + (hexNum - h)).GetComponent<HexScript>();
        else
            BottomLeftHex = GameObject.Find("HexClone " + (hexNum + h * l - h)).GetComponent<HexScript>();

        if ((hexNum + h) < h * l && hexNum % h != 0)
            BottomRightHex = GameObject.Find("HexClone " + (hexNum + h - 1)).GetComponent<HexScript>();
        else
        {
            if (hexNum > h * l - h)
                BottomRightHex = GameObject.Find("HexClone " + (hexNum - h * l + h - 1)).GetComponent<HexScript>();
            else
            {
                if (hexNum != h * l - h)
                    BottomRightHex = GameObject.Find("HexClone " + (hexNum + 2 * h - 1)).GetComponent<HexScript>();
                else
                    BottomRightHex = GameObject.Find("HexClone " + (h - 1)).GetComponent<HexScript>();
            }
        }

        if ((hexNum - h) >= 0 && (hexNum + 1) % h != 0)
            TopLeftHex = GameObject.Find("HexClone " + (hexNum - h + 1)).GetComponent<HexScript>();
        else
        {
            if (hexNum < h - 1)
                TopLeftHex = GameObject.Find("HexClone " + (hexNum + h * l - h + 1)).GetComponent<HexScript>();
            else
            {
                if (hexNum != h - 1)
                    TopLeftHex = GameObject.Find("HexClone " + (hexNum - 2 * h + 1)).GetComponent<HexScript>();
                else
                    TopLeftHex = GameObject.Find("HexClone " + (h * l - h)).GetComponent<HexScript>();
            }
        }

        if (((hexNum+1) % h) != 0)
            TopHex = GameObject.Find("HexClone " + (hexNum + 1)).GetComponent<HexScript>();
        else
            TopHex = GameObject.Find("HexClone " + (hexNum - h + 1)).GetComponent<HexScript>();

        if ((hexNum + h) < h*l)
            TopRightHex = GameObject.Find("HexClone " + (hexNum + h)).GetComponent<HexScript>();
        else
            TopRightHex = GameObject.Find("HexClone " + (hexNum - h * l + h)).GetComponent<HexScript>();
    }
    public int stringToInt(string a)
    {
        string n = string.Empty;
        int num = 0;
        for (int i = 0; i < a.Length; i++)
        {
            string str2 = string.Empty;
            if (Char.IsDigit(a[i]))
                n += a[i];
        }
        if (n.Length > 0)
            num = int.Parse(n);
        return num;
    }
    public void setHex()
    {
        setBottom(this.transform.Find("LineBottom").GetComponent<LineScript>().state, true);
        setBottomRight(this.transform.Find("LineBottomRight").GetComponent<LineScript>().state, true);
        setBottomLeft(this.transform.Find("LineBottomLeft").GetComponent<LineScript>().state, true);
        setTop(this.transform.Find("LineTop").GetComponent<LineScript>().state, true);
        setTopRight(this.transform.Find("LineTopRight").GetComponent<LineScript>().state, true);
        setTopLeft(this.transform.Find("LineTopLeft").GetComponent<LineScript>().state, true);

        setBottom(this.transform.Find("LineBottom").GetComponent<LineScript>().state, true);
        setBottomRight(this.transform.Find("LineBottomRight").GetComponent<LineScript>().state, true);
        setBottomLeft(this.transform.Find("LineBottomLeft").GetComponent<LineScript>().state, true);
        setTop(this.transform.Find("LineTop").GetComponent<LineScript>().state, true);
        setTopRight(this.transform.Find("LineTopRight").GetComponent<LineScript>().state, true);
        setTopLeft(this.transform.Find("LineTopLeft").GetComponent<LineScript>().state, true);

        hexType = idealHex.checkHex(bs, bls, tls, ts, trs, brs);
    }
    public void setBottom(int x, bool first)
    {
        bs = x;
        if (first)
        {
            if (x == 0) 
                BottomHex.setTop(2, false);
            if (x == 1) 
                BottomHex.setTop(1, false);
            if (x == 2)
                BottomHex.setTop(0, false);
        }
        if(x==0)
            this.transform.Find("LineBottom").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if(x==1)
            this.transform.Find("LineBottom").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if(x==2)
            this.transform.Find("LineBottom").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setBottomLeft(int x, bool first)
    {
        bls = x;
        if (first)
        {
            if (x == 0)
                BottomLeftHex.setTopRight(2, false);
            if (x == 1)
                BottomLeftHex.setTopRight(1, false);
            if (x == 2)
                BottomLeftHex.setTopRight(0, false);
        }
        if (x == 0)
            this.transform.Find("LineBottomLeft").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (x == 1)
            this.transform.Find("LineBottomLeft").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (x == 2)
            this.transform.Find("LineBottomLeft").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setTopLeft(int x, bool first)
    {
        tls = x;
        if (first)
        {
            if (x == 0)
                TopLeftHex.setBottomRight(2, false);
            if (x == 1)
                TopLeftHex.setBottomRight(1, false);
            if (x == 2)
                TopLeftHex.setBottomRight(0, false);
        }
        if (x == 0)
            this.transform.Find("LineTopLeft").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (x == 1)
            this.transform.Find("LineTopLeft").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (x == 2)
            this.transform.Find("LineTopLeft").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setTop(int x, bool first)
    {
        ts = x;
        if (first)
        {
            if (x == 0)
                TopHex.setBottom(2, false);
            if (x == 1)
                TopHex.setBottom(1, false);
            if (x == 2)
                TopHex.setBottom(0, false);

        }
        if (x == 0)
            this.transform.Find("LineTop").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (x == 1)
            this.transform.Find("LineTop").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (x == 2)
            this.transform.Find("LineTop").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setTopRight(int x, bool first)
    {
        trs = x;
        if (first)
        {
            if (x == 0)
                TopRightHex.setBottomLeft(2, false);
            if (x == 1)
                TopRightHex.setBottomLeft(1, false);
            if (x == 2)
                TopRightHex.setBottomLeft(0, false);
        }
        if (x == 0)
            this.transform.Find("LineTopRight").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (x == 1)
            this.transform.Find("LineTopRight").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (x == 2)
            this.transform.Find("LineTopRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setBottomRight(int x, bool first)
    {
        brs = x;
        if (first)
        {
            if (x == 0)
                BottomRightHex.setTopLeft(2, false);
            if (x == 1)
                BottomRightHex.setTopLeft(1, false);
            if (x == 2)
                BottomRightHex.setTopLeft(0, false);
        }
        if (x == 0)
            this.transform.Find("LineBottomRight").transform.Find("PressIn").GetComponent<ButtonPressIn>().Clicked();
        if (x == 1)
            this.transform.Find("LineBottomRight").transform.Find("PressNormal").GetComponent<ButtonPressNormal>().Clicked();
        if (x == 2)
            this.transform.Find("LineBottomRight").transform.Find("PressOut").GetComponent<ButtonPressOut>().Clicked();
    }
    public void setBottomA(int x, bool first)
    {
        bs = x;
        if (first)
        {
            if (x == 0) 
                BottomHex.setTopA(2, false);
            if (x == 1) 
                BottomHex.setTopA(1, false);
            if (x == 2)
                BottomHex.setTopA(0, false);
        }
    }
    public void setBottomLeftA(int x, bool first)
    {
        bls = x;
        if (first)
        {
            if (x == 0)
                BottomLeftHex.setTopRightA(2, false);
            if (x == 1)
                BottomLeftHex.setTopRightA(1, false);
            if (x == 2)
                BottomLeftHex.setTopRightA(0, false);
        }
    }
    public void setTopLeftA(int x, bool first)
    {
        tls = x;
        if (first)
        {
            if (x == 0)
                TopLeftHex.setBottomRightA(2, false);
            if (x == 1)
                TopLeftHex.setBottomRightA(1, false);
            if (x == 2)
                TopLeftHex.setBottomRightA(0, false);
        }
    }
    public void setTopA(int x, bool first)
    {
        ts = x;
        if (first)
        {
            if (x == 0)
                TopHex.setBottomA(2, false);
            if (x == 1)
                TopHex.setBottomA(1, false);
            if (x == 2)
                TopHex.setBottomA(0, false);

        }
    }
    public void setTopRightA(int x, bool first)
    {
        trs = x;
        if (first)
        {
            if (x == 0)
                TopRightHex.setBottomLeftA(2, false);
            if (x == 1)
                TopRightHex.setBottomLeftA(1, false);
            if (x == 2)
                TopRightHex.setBottomLeftA(0, false);
        }
    }
    public void setBottomRightA(int x, bool first)
    {
        brs = x;
        if (first)
        {
            if (x == 0)
                BottomRightHex.setTopLeftA(2, false);
            if (x == 1)
                BottomRightHex.setTopLeftA(1, false);
            if (x == 2)
                BottomRightHex.setTopLeftA(0, false);
        }
    }
    public void setHexSides(int b, int bl, int tl, int t, int tr, int br)
    {
        setBottom(b, true);
        setBottomLeft(bl, true);
        setTopLeft(tl, true);
        setTop(t, true);
        setTopRight(tr, true);
        setBottomRight(br, true);
    }
    public void setHexSides(int[] lines)
    {
        setBottomA(lines[0], true);
        setBottomLeftA(lines[1], true);
        setTopLeftA(lines[2], true);
        setTopA(lines[3], true);
        setTopRightA(lines[4], true);
        setBottomRightA(lines[5], true);
    }
}
