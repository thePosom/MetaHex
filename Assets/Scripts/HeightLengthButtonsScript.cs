using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;



public class HeightLengthButtonsScript : MonoBehaviour
{
    public TMP_InputField heightField;
    public TMP_InputField lengthField;

    // Start is called before the first frame update
    public void heightChange(int i){
        if (heightField.text==""){
            if (i==1){
                heightField.text="1";
                return;
            }
            if (i==-1)
                return;
        }
        int value = Int32.Parse(heightField.text);
        if (value==1&&i==-1)
            heightField.text = "";
        else 
            heightField.text = value+i+"";
    }

    public void lengthChange(int i){
        if (lengthField.text==""){
            if (i==1){
                lengthField.text="1";
                return;
            }
            if (i==-1)
                return;
        }
        int value = Int32.Parse(lengthField.text);
        if (value==1&&i==-1)
            lengthField.text = "";
        else 
            lengthField.text = value+i+"";
    }


}
