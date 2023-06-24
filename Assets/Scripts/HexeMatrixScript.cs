using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HexeMatrixScript : MonoBehaviour
{
    public GameObject Hexegon;
    public GameObject first;
    public GameObject firstText;
    public AutoScript AutoScript;
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
        if ((!PlayerPrefs.HasKey("auto")) || PlayerPrefs.GetInt("auto") == 1)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            AutoScript.starter();

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            UnityEngine.Debug.Log("Time elapsed: " + elapsedMilliseconds + " ms");
        }
        //PlayerPrefs.DeleteKey("auto");
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
