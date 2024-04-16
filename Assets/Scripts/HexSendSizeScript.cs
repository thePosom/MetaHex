using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HexSendSizeScript : MonoBehaviour
{
    public TMP_InputField lengthField;
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
    public Toggle pery;
    public Toggle photo;
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
    public int peri = 0;
    public int foto = 0;
    public int moreAutomo = 1;

    void Start()
    {
        Screen.fullScreen = false;

        if (PlayerPrefs.HasKey("length"))
            lengthField.text = PlayerPrefs.GetInt("length")+"";
        if (PlayerPrefs.HasKey("floppy1"))
            flop1.isOn = PlayerPrefs.GetInt("floppy1") == 1;
        if (PlayerPrefs.HasKey("floppy2"))
            flop2.isOn = PlayerPrefs.GetInt("floppy2") == 1;
        if (PlayerPrefs.HasKey("floppy3"))
            flop3.isOn = PlayerPrefs.GetInt("floppy3") == 1;
        if (PlayerPrefs.HasKey("floppy4"))
            flop4.isOn = PlayerPrefs.GetInt("floppy4") == 1;
        if (PlayerPrefs.HasKey("floppy5"))
            flop5.isOn = PlayerPrefs.GetInt("floppy5") == 1;
        if (PlayerPrefs.HasKey("floppy6"))
            flop6.isOn = PlayerPrefs.GetInt("floppy6") == 1;
        if (PlayerPrefs.HasKey("floppy7"))
            flop7.isOn = PlayerPrefs.GetInt("floppy7") == 1;
        if (PlayerPrefs.HasKey("floppy8"))
            flop8.isOn = PlayerPrefs.GetInt("floppy8") == 1;
        if (PlayerPrefs.HasKey("auto"))
            auto.isOn = PlayerPrefs.GetInt("auto") == 1;
        if (PlayerPrefs.HasKey("done"))
            moreAuto.isOn = PlayerPrefs.GetInt("done") != 1;
        if (PlayerPrefs.HasKey("variMuch"))
            very.isOn = PlayerPrefs.GetInt("variMuch") == 1;
        // if (PlayerPrefs.HasKey("periodic"))
        //     pery.isOn = PlayerPrefs.GetInt("periodic") == 1;
        if (PlayerPrefs.HasKey("photo"))
            photo.isOn = PlayerPrefs.GetInt("photo") == 1;

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
        if (pery.isOn)
            peri = 1;
        if (photo.isOn)
            foto = 1;
        return flon1 == 1 || flon2 == 1 || flon3 == 1 || flon4 == 1 || flon5 == 1 || flon6 == 1 || flon7 == 1 || flon8 == 1;
    }

    public void clickening()
    {
        string sl = length.text;
        int l = int.Parse(sl.Replace("\u200B", string.Empty));
        if (l != 0 && setFlons())
        {
            PlayerPrefs.DeleteKey("height");
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
            PlayerPrefs.SetInt("periodic", peri);
            PlayerPrefs.SetInt("photo", foto);
            SceneManager.LoadScene(1);
        }
    }
}
