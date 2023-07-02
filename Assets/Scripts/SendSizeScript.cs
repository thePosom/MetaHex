using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SendSizeScript : MonoBehaviour
{
    public TextMeshProUGUI height;
    public TextMeshProUGUI length;
    public Toggle flop1;
    public Toggle flop2;
    public Toggle flop3;
    public Toggle flop4;
    public Toggle flop5;
    public Toggle flop6;
    public Toggle flop7;
    public Toggle flop8;
    public Toggle auto;
    public Toggle moreAuto;
    public Toggle very;
    public int flon1 = 0;
    public int flon2 = 0;
    public int flon3 = 0;
    public int flon4 = 0;
    public int flon5 = 0;
    public int flon6 = 0;
    public int flon7 = 0;
    public int flon8 = 0;
    public int automo = 0;
    public int vari = 0;
    public int moreAutomo = 1;

    void Start()
    {
        Screen.fullScreen = false;
        //Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
    }

    private bool setFlons()
    {
        if (flop1.isOn)
            flon1 = 1;
        if (flop2.isOn)
            flon2 = 1;
        if (flop3.isOn)
            flon3 = 1;
        if (flop4.isOn)
            flon4 = 1;
        if (flop5.isOn)
            flon5 = 1;
        if (flop6.isOn)
            flon6 = 1;
        if (flop7.isOn)
            flon7 = 1;
        if (flop8.isOn)
            flon8 = 1;
        if (auto.isOn)
            automo = 1;
        if (moreAuto.isOn)
            moreAutomo = 0;
        if (very.isOn)
            vari = 1;
        return flon1==1 || flon2 == 1 || flon3 == 1 || flon4 == 1 || flon5 == 1 || flon6 == 1 || flon7 == 1 || flon8 == 1;
    }

    public void clickening()
    {
        string sh = height.text;
        string sl = length.text;
        int h = int.Parse(sh.Replace("\u200B", string.Empty));
        int l = int.Parse(sl.Replace("\u200B", string.Empty)); 
        if (h!=0&&l!=0&&setFlons())
        {
            PlayerPrefs.SetInt("height", h);
            PlayerPrefs.SetInt("length", l);
            PlayerPrefs.SetInt("floppy1", flon1);
            PlayerPrefs.SetInt("floppy2", flon2);
            PlayerPrefs.SetInt("floppy3", flon3);
            PlayerPrefs.SetInt("floppy4", flon4);
            PlayerPrefs.SetInt("floppy5", flon5);
            PlayerPrefs.SetInt("floppy6", flon6);
            PlayerPrefs.SetInt("floppy7", flon7);
            PlayerPrefs.SetInt("floppy8", flon8);
            PlayerPrefs.SetInt("auto", automo);
            PlayerPrefs.SetInt("done", moreAutomo);
            PlayerPrefs.SetInt("variations", vari);
            PlayerPrefs.SetInt("variMuch", vari);
            SceneManager.LoadScene(1);
        }
    }
}
