using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class AutoScript : MonoBehaviour
{
    private int hexesTotal;
    private int times;
    private int vari;
    private int varia;
    public int totalVariationIsland = 0;
    private int[] usedMods;
    private int[] allowedMods;
    public HexeMatrixScript HexeMatrixScript;
    public ClicksScript idealHex;
    public SpriteRenderer wrongX;

    public void starter(int i)
    {
        hexesTotal = HexeMatrixScript.height * HexeMatrixScript.length;
        usedMods = new int[8];
        allowedMods = setFlops();
        if (i == 0 || PlayerPrefs.GetInt("photo") == 1)
        {
            vari = i - 1;
            varia = i - 1;
            times = 0;
            autoHex();
        }
        else
            veryAutoHex();
    }


    public void autoHex()
    {
        if (!autoHex(0))
        {
            wrongX.enabled = true;
            PlayerPrefs.SetInt("variations", 0);
        }

        else
        {
            for (int i = 0; i < hexesTotal; i++)
            {
                HexScript hex = GameObject.Find("HexClone " + i).GetComponent<HexScript>();
                hex.updateHex();
            }

        }
        if (PlayerPrefs.GetInt("photo") == 1)
            screeni();
    }
    public void veryAutoHex()
    {
        if (!veryAutoHex(0))
            PlayerPrefs.SetInt("variations", 0);
        HexeMatrixScript.VeryTexty.text = totalVariationIsland.ToString();
        //else
        //{
            
        //}
        //screeni();
    }


    public bool autoHex(int hexNum)
    {
        times++;
        if (hexesTotal <= hexNum)
            return true;

        HexScript hex = GameObject.Find("HexClone " + hexNum).GetComponent<HexScript>();
        int[] hexOrder = new int[6];
        int[] lines = { hex.bs, hex.bls, hex.tls, hex.ts, hex.trs, hex.brs };
        int[] linesCopy = (int[])lines.Clone();

        for (int i = 0; i < 12 * allowedMods.Length; i++)
        {
            i = skipper(i);
            if (i >= 12 * allowedMods.Length)
                break;

            if (i % 12 == 6)
                reverse(hexOrder);

            if (i % 12 == 0)
                hexOrder = nextMod(hexOrder, i / 12);


            if (samezies(hexOrder, lines))
            {
                hex.setHexSides(lines);
                if (ratiod(hexNum, hexOrder) && autoHex(hexNum + 1))
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

    public bool veryAutoHex(int hexNum)
    {
        times++;
        if (hexesTotal <= hexNum)
        {
            totalVariationIsland++;
            return false;
        } 

        HexScript hex = GameObject.Find("HexClone " + hexNum).GetComponent<HexScript>();
        int[] hexOrder = new int[6];
        int[] lines = { hex.bs, hex.bls, hex.tls, hex.ts, hex.trs, hex.brs };
        int[] linesCopy = (int[])lines.Clone();

        for (int i = 0; i < 12 * allowedMods.Length; i++)
        {
            i = skipper(i);
            if (i >= 12 * allowedMods.Length)
                break;

            if (i % 12 == 6)
                reverse(hexOrder);

            if (i % 12 == 0)
                hexOrder = nextMod(hexOrder, i / 12);


            if (samezies(hexOrder, lines))
            {
                hex.setHexSides(lines);
                if (ratiod(hexNum, hexOrder) && veryAutoHex(hexNum + 1))
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

    public int flopsList()
    {
        int x = 0;
        for (int i = 0; i < allowedMods.Length; i++)
            x = x * 10 + allowedMods[i];
        return x;
    }
    public void screeni()
    {
        int x = flopsList();
        if (varia == -1)
            ScreenCapture.CaptureScreenshot(System.IO.Path.Combine("autoSolves", x + ".png"));
        else
            ScreenCapture.CaptureScreenshot(System.IO.Path.Combine("autoSolves", x + " " + (varia + 1) + ".png"));

    }
    public int skipper(int i)
    {
        int x = i % 12;
        int m = allowedMods[i / 12];

        if (m == 2 || m == 3 || m == 4 || m == 7)
            return i;
        if ((m == 1) && (x == 1 || x == 7))
            return i + 5;
        if (m == 5 && (x == 3 || x == 9))
            return i + 3;
        if (m == 6 && x == 6)
            return i + 6;
        if (m == 8 && x == 1)
            return i + 10;

        return i;
    }
    public bool ratiod(int hexNum, int[] hexOrder)
    {
        int mode = idealHex.checkHex(hexOrder);
        usedMods[mode - 1]++;
        int thisNum = hexesTotal / allowedMods.Length;
        if(usedMods[mode - 1] > thisNum)
            return false;
        //להוריד כנראה
        if (hexesTotal <= hexNum + 1)
        {
            if (vari > 0)
            {
                vari--;
                return false;
            }
        }
        return true;
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
    public int sum(int[] a)
    {
        int s = 0;
        for (int i = 0; i < a.Length; i++)
            s += a[i];
        return s;
    }
}
