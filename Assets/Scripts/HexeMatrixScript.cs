using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Reflection;

public class HexeMatrixScript : MonoBehaviour
{
    public GameObject Hexegon;
    public GameObject first;
    public GameObject firstText;
    public GameObject UI;
    public AutoScript AutoScript;
    public ResetScript ResetScript;
    public int height;
    public int length;
    public float hDiff;
    public float LDiffX;
    public float LDiffY;
    private float x;
    private float y;
    public bool floppy1 = true;
    public bool floppy2 = true;
    public bool floppy3 = true;
    public bool floppy4 = true;
    public bool floppy5 = true;
    public bool floppy6 = true;
    public bool floppy7 = true;
    public bool floppy8 = true;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        starterCoords();
        spawner(height,length);
        setFlops();
        yield return new WaitForSeconds(0.05f);

        //arrayToFlops(flopsToArray());
        if ((!PlayerPrefs.HasKey("auto")) || PlayerPrefs.GetInt("auto") == 1)
        {
            AutoScript.starter();

            yield return new WaitForSeconds(0.05f);
            UI.SetActive(true);
        }
        //PlayerPrefs.DeleteKey("auto");
        int x = PlayerPrefs.GetInt("done");
        if (PlayerPrefs.GetInt("done") == 0)
            autoProject();
    }
    public void autoProject()
    {
        PlayerPrefs.SetInt("done", 0);
        bool[] a = flopsToArray();

        int x = findLastUntilPoint(a);
        a[x] = false;
        if (x!=7)
        {
            a[x+1] = true;
            arrayToFlops(a);
            UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
            ResetScript.reset(true);
        }
        else
        {
            int y = findLastUntilPoint(a);
            a[y] = false;
            if (y != 6)
            {
                a[y + 1] = true;
                a[y + 2] = true;
                arrayToFlops(a);
                UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                ResetScript.reset(true);
            }
            else
            {
                int z = findLastUntilPoint(a);
                a[z] = false;
                if (z != 5)
                {
                    a[z + 1] = true;
                    a[z + 2] = true;
                    a[z + 3] = true;
                    arrayToFlops(a);
                    UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                    ResetScript.reset(true);
                }
                else
                {
                    int w = findLastUntilPoint(a);
                    a[w] = false;
                    if (w != 4)
                    {
                        a[w + 1] = true;
                        a[w + 2] = true;
                        a[w + 3] = true;
                        a[w + 4] = true;
                        arrayToFlops(a);
                        UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                        ResetScript.reset(true);
                    }
                    else
                    {
                        int q = findLastUntilPoint(a);
                        a[q] = false;
                        if (q != 3)
                        {
                            a[q + 1] = true;
                            a[q + 2] = true;
                            a[q + 3] = true;
                            a[q + 4] = true;
                            a[q + 5] = true;
                            arrayToFlops(a);
                            UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                            ResetScript.reset(true);
                        }
                        else
                        {
                            int u = findLastUntilPoint(a);
                            a[u] = false;
                            if (u != 2)
                            {
                                a[u + 1] = true;
                                a[u + 2] = true;
                                a[u + 3] = true;
                                a[u + 4] = true;
                                a[u + 5] = true;
                                a[u + 6] = true;
                                arrayToFlops(a);
                                UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                                ResetScript.reset(true);
                            }
                            else
                            {
                                int t = findLastUntilPoint(a);
                                a[t] = false;
                                if (t != 1)
                                {
                                    a[t + 1] = true;
                                    a[t + 2] = true;
                                    a[t + 3] = true;
                                    a[t + 4] = true;
                                    a[t + 5] = true;
                                    a[t + 6] = true;
                                    a[t + 7] = true;
                                    arrayToFlops(a);
                                    UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                                    ResetScript.reset(true);
                                }
                                else
                                {
                                    a[0] = true;
                                    a[1] = true;
                                    a[2] = true;
                                    a[3] = true;
                                    a[4] = true;
                                    a[5] = true;
                                    a[6] = true;
                                    a[7] = true;
                                    arrayToFlops(a);
                                    PlayerPrefs.SetInt("done", 1);
                                    UnityEngine.Debug.Log(a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7]);
                                    ResetScript.reset(true);
                                }
                            }
                        }
                    }
                }
            }
        }
                 
    }
    public int findLastUntilPoint(bool[] a)
    {
        int x=-1;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i])
                x = i;
        }
        if(x!=-1)
            return x;
        PlayerPrefs.SetInt("done", 1);
        ResetScript.reset(true);
        return x;
    }
    public bool[] flopsToArray()
    {
        bool[] x = new bool[8];
        for(int i = 0; i < 8; i++)
        {
            if ((bool)GetType().GetField(("floppy" + (i + 1)), BindingFlags.Public | BindingFlags.Instance)?.GetValue(this))
                x[i] = true;
        }
        return x;
    }
    //ss
    public void arrayToFlops(bool[] n)
    {
        floppy1 = false;
        floppy2 = false;
        floppy3 = false;
        floppy4 = false;
        floppy5 = false;
        floppy6 = false;
        floppy7 = false;
        floppy8 = false;
        for (int i = 0; i < 8; i++)
        {
            if (n[i])
            {
                FieldInfo field = GetType().GetField(("floppy" + (i+1)), BindingFlags.Public | BindingFlags.Instance);
                field?.SetValue(this, true);
            }
        }
        int flon1 = 0;
        int flon2 = 0;
        int flon3 = 0;
        int flon4 = 0;
        int flon5 = 0;
        int flon6 = 0;
        int flon7 = 0;
        int flon8 = 0;

        if (floppy1)
            flon1 = 1;
        if (floppy2)
            flon2 = 1;
        if (floppy3)
            flon3 = 1;
        if (floppy4)
            flon4 = 1;
        if (floppy5)
            flon5 = 1;
        if (floppy6)
            flon6 = 1;
        if (floppy7)
            flon7 = 1;
        if (floppy8)
            flon8 = 1;

        PlayerPrefs.SetInt("floppy1", flon1);
        PlayerPrefs.SetInt("floppy2", flon2);
        PlayerPrefs.SetInt("floppy3", flon3);
        PlayerPrefs.SetInt("floppy4", flon4);
        PlayerPrefs.SetInt("floppy5", flon5);
        PlayerPrefs.SetInt("floppy6", flon6);
        PlayerPrefs.SetInt("floppy7", flon7);
        PlayerPrefs.SetInt("floppy8", flon8);
    }
    public int flopsToNum()
    {
        int x = 0;
        for(int i = 1; i <= 8; i++)
        {
            if ((bool)GetType().GetField(("floppy" + i), BindingFlags.Public | BindingFlags.Instance)?.GetValue(this))
                x = x * 10 + i;
        }
        return x;
    }
    public void numToFlops(int n)
    {
        floppy1 = false;
        floppy2 = false;
        floppy3 = false;
        floppy4 = false;
        floppy5 = false;
        floppy6 = false;
        floppy7 = false;
        floppy8 = false;
        while (n != 0)
        {
            FieldInfo field = GetType().GetField(("floppy" + n % 10), BindingFlags.Public | BindingFlags.Instance);
            field?.SetValue(this, true);
            //(bool)GetType().GetField(("floppy" + n % 10), BindingFlags.Public | BindingFlags.Instance)?.GetValue(this) = true;
            n = n / 10;
        }
    }
    public bool checkHex(int type)
    {
        return (bool)GetType().GetField("floppy" + type).GetValue(this);
    }
    private void setFlops()
    {
        if (!PlayerPrefs.HasKey("floppy1"))
            return;

        if (PlayerPrefs.GetInt("floppy1") == 1)
            floppy1 = true;
        else
            floppy1 = false;

        if (PlayerPrefs.GetInt("floppy2") == 1)
            floppy2 = true;
        else
            floppy2 = false;

        if (PlayerPrefs.GetInt("floppy3") == 1)
            floppy3 = true;
        else
            floppy3 = false;

        if (PlayerPrefs.GetInt("floppy4") == 1)
            floppy4 = true;
        else
            floppy4 = false;

        if (PlayerPrefs.GetInt("floppy5") == 1)
            floppy5 = true;
        else
            floppy5 = false;

        if (PlayerPrefs.GetInt("floppy6") == 1)
            floppy6 = true;
        else
            floppy6 = false;

        if (PlayerPrefs.GetInt("floppy7") == 1)
            floppy7 = true;
        else
            floppy7 = false;

        if (PlayerPrefs.GetInt("floppy8") == 1)
            floppy8 = true;
        else
            floppy8 = false;
        /*
        PlayerPrefs.DeleteKey("floppy1");
        PlayerPrefs.DeleteKey("floppy2");
        PlayerPrefs.DeleteKey("floppy3");
        PlayerPrefs.DeleteKey("floppy4");
        PlayerPrefs.DeleteKey("floppy5");
        PlayerPrefs.DeleteKey("floppy6");
        PlayerPrefs.DeleteKey("floppy7");
        PlayerPrefs.DeleteKey("floppy8");
        */
    }
    private void starterCoords()
    {
        if (PlayerPrefs.HasKey("height"))
        {
            height = PlayerPrefs.GetInt("height");
            length = PlayerPrefs.GetInt("length");
            //PlayerPrefs.DeleteKey("height");
            //PlayerPrefs.DeleteKey("length");
        }
        x = 0 - ((float)(length - 1) * LDiffX / 2);
        y = 0 - ((float)(height - 1) * (hDiff + LDiffY)) / 2;
        this.transform.position = new Vector3(x, y, 0);
        firstText.transform.position = new Vector3(x, y, 0);
    }
    private void spawner(int height, int length)
    {
        first = Instantiate(Hexegon, transform.position, transform.rotation);
        first.tag = "HexClone";
        first.name = "HexClone 0";
        float y = hDiff;
        float x = 0;
        int h = height - 1;
        int l = length;
        int c = 1;
        float preY = 0;
        for (; l > 0; l--)
        {
            for (; h > 0; h--)
            {
                GameObject HexClone = Instantiate(Hexegon, transform.position + new Vector3(x, y, 0), transform.rotation);
                HexClone.tag = "HexClone";
                HexClone.name = "HexClone "+c;
                y += hDiff;
                c++;
            }
            h = height;
            preY += LDiffY;
            y = preY;
            x += LDiffX;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
