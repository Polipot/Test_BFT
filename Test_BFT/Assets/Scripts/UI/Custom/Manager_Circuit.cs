using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager_Circuit : MonoBehaviour
{
    #region Var_UI
    [Header("UI")]
    [SerializeField] private Image icon_circuit;
    [SerializeField] private Text nom_circuit;
    [SerializeField] private Text etoile_circuit;  //3 max par circuit

    [SerializeField] private Text indexCircuit_t;

    #endregion



    #region Var_

    public Circuit[] circuits;
    private int index = 0;

    #endregion


    private void Awake()                                    //AWAKE
    {
        SwitchCircuit(0);
    }



    #region Button


    public void LaunchCircuit()
    {
        if (!string.IsNullOrEmpty( circuits[index].NomSceneCircuit ))
        {
            SceneManager.LoadScene(circuits[index].NomSceneCircuit);
        }
    }

    public void SwitchCircuit(int add)
    {
        index += add;
        if (index < 0)
        {
            index = circuits.Length - 1;
        }
        if (index >= circuits.Length)
        {
            index = 0;
        }

        indexCircuit_t.text = (index+1) + " / " + circuits.Length;

        //Debug.Log(index + "  " + circuits[2].NomCircuit );


        icon_circuit = circuits[index].IconCircuit != null ? icon_circuit = circuits[index].IconCircuit : null;

        nom_circuit.text = circuits[index].NomCircuit != null? circuits[index].NomCircuit: "ERROR TEXT";

        etoile_circuit.text = "Etoile: " + circuits[index].EtoileGet;

    }


    #endregion
}



[System.Serializable]
public class Circuit
{
    public Image IconCircuit;
    public string NomCircuit;
    public string NomSceneCircuit;
    public int EtoileGet;

    /*
     * A lavenir, creer scriptable object avec playerpref pour save Etoile etc
     * */
}
