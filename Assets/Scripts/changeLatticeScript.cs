using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLatticeScript : MonoBehaviour
{
    public void toSquareLattice() {
        SceneManager.LoadScene(0);
    }

    public void toHexLattice() {
        SceneManager.LoadScene(2);
    }
}
