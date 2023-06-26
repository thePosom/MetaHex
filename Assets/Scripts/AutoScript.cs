using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class AutoScript : MonoBehaviour
{
    private int hexesTotal;
    private int[] usedMods;
    private int[] allowedMods;
    public HexeMatrixScript HexeMatrixScript;
    public ClicksScript idealHex;
    public SpriteRenderer wrongX;
    public GameObject UI;

    public void starter()
    {
        hexesTotal = HexeMatrixScript.height * HexeMatrixScript.length;
        usedMods = new int[8];
        allowedMods = setFlops();

        autoHex();
    }

    public void autoHex()
    {
        int[] order = new int[6];
        order = nextMod(order, 0);
        if (!autoHex(0, order))
            wrongX.enabled = true;
        else
        {
            for (int i = 0; i < hexesTotal; i++)
            {
                HexScript hex = GameObject.Find("HexClone " + i).GetComponent<HexScript>();
                hex.updateHex();
            }
            screeni();
        }
    }

    public void screeni()
    {
        UI.SetActive(false);
        int x = flopsList();
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine("autoSolves", x + ".png"));
        
    }

    public int flopsList()
    {
        int x = 0;
        for (int i = 0; i < allowedMods.Length; i++)
            x = x * 10 + allowedMods[i];
        return x;
    }

    public bool autoHex(int hexNum, int[] order)
    {
        if (hexesTotal <= hexNum)
            return true;

        HexScript hex = GameObject.Find("HexClone " + hexNum).GetComponent<HexScript>();
        int[] hexOrder = (int[])order.Clone();
        int[] lines = { hex.bs, hex.bls, hex.tls, hex.ts, hex.trs, hex.brs };
        int[] linesCopy = (int[])lines.Clone();

        for (int i = 0; i < 12 * allowedMods.Length; i++)
        {
            if (i % 12 == 6)
                reverse(hexOrder);

            if (i % 12 == 0)
                hexOrder = nextMod(hexOrder, i / 12);


            if (samezies(hexOrder, lines))
            {
                hex.setHexSides(lines);
                if (ratiod(hexNum, hexOrder) && autoHex(hexNum + 1, lines))
                    return true;
                hex.setHexSides(linesCopy);
                usedMods[idealHex.checkHex(hexOrder) - 1]--;
            }
            lines = (int[])linesCopy.Clone();
            slider(hexOrder);
        }
        hex.setHexSides(linesCopy);
        return false;
    }
    public bool ratiod(int hexNum, int[] hexOrder)
    {
        usedMods[idealHex.checkHex(hexOrder)-1]++;
        ////
        int thisNum = hexesTotal / allowedMods.Length;
        for (int i = 0; i < 8; i++)
        {
            if (usedMods[i] > thisNum)
                return false;
        }
        ////
        return true;
    }
    public int[] nextMod(int[] hexOrder, int modLoc)
    {
        int m = allowedMods[modLoc];
        if (m == 1)
        {
            int[] nextOrder = { 0, 0, 0, 0, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 2)
        {
            int[] nextOrder = { 2, 0, 0, 0, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 3)
        {
            int[] nextOrder = { 2, 2, 0, 0, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 4)
        {
            int[] nextOrder = { 2, 0, 2, 0, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 5)
        {
            int[] nextOrder = { 2, 0, 0, 2, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 6)
        {
            int[] nextOrder = { 2, 2, 2, 0, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 7)
        {
            int[] nextOrder = { 2, 2, 0, 2, 0, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        if (m == 8)
        {
            int[] nextOrder = { 2, 0, 2, 0, 2, 0 };
            hexOrder = nextOrder;
            return hexOrder;
        }
        return hexOrder;
    }
    public void reverse(int[] HexOrder)
    {
        for (int i = 0; i < 6; i++)
            HexOrder[i] = (HexOrder[i] + 2) % 4;
    }
    public void slider(int[] HexOrder)
    {
        int a = HexOrder[5];
        for (int i = 5; i > 0; i--)
            HexOrder[i] = HexOrder[i - 1];
        HexOrder[0] = a;
    }
    public bool samezies(int[] HexOrder, int[] lines)
    {
        for (int j = 0; j < 6; j++)
        {
            if (lines[j] == 1)
                lines[j] = HexOrder[j];
            if (lines[j] != HexOrder[j])
                return false;
        }
        return true;
    }
    public int[] setFlops()
    {
        int[] a = new int[8];
        int x = 0;
        if (HexeMatrixScript.floppy1)
            a[x++] = 1;
        if (HexeMatrixScript.floppy2)
            a[x++] = 2;
        if (HexeMatrixScript.floppy3)
            a[x++] = 3;
        if (HexeMatrixScript.floppy4)
            a[x++] = 4;
        if (HexeMatrixScript.floppy5)
            a[x++] = 5;
        if (HexeMatrixScript.floppy6)
            a[x++] = 6;
        if (HexeMatrixScript.floppy7)
            a[x++] = 7;
        if (HexeMatrixScript.floppy8)
            a[x++] = 8;
        int[] b = new int[x];
        for (int i = 0; i < x; i++)
            b[i] = a[i];
        return b;
    }
}
