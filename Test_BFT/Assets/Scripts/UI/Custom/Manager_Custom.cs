using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Custom : MonoBehaviour
{

    #region Var_script

    private Vehicle_Modifier v_modif;
    private Stat_Manager stat_m;




    [SerializeField] private MeshRenderer[] renderersTruck;
    #endregion







    private void Awake()                                            //AWAKE
    {
        stat_m = GetComponent<Stat_Manager>();
        v_modif = GetComponent<Vehicle_Modifier>();
    }

    private void Start()                                            //START
    {
        Init_Btn();
    }


    private void Update()                                           //UPATDE
    {
        CheckUpdate_Btn();
    }




    #region Var_Upgarde
    [Header("Upgrade side")]
    [SerializeField] private Button Bt_Vit, Bt_Mania, Bt_Nitro;
    private Text t_Vit, t_Mania, t_Nitro;

    [Space]
    public int Level_Vit, Level_Mania, Level_Nitro;
    private int cost_Vit, cost_Mani, cost_Nitro;


    #endregion



    #region Button_Upgrade


    private void Init_Btn()
    {
        //Playerpref cost + Level or just one with a switch

        t_Vit = Bt_Vit.GetComponentInChildren<Text>();
        t_Mania = Bt_Mania.GetComponentInChildren<Text>();
        t_Nitro = Bt_Nitro.GetComponentInChildren<Text>();

        cost_Vit = 10;
        cost_Nitro = 10;
        cost_Mani = 10;
    }



    private void CheckUpdate_Btn()
    {

        if (Level_Vit < 10)
        {
            Bt_Vit.interactable = cost_Vit < stat_m.Gold;
            t_Vit.text = "Vitesse Lv " + Level_Vit + "\n" + cost_Vit;
        }
        else
        {
            Bt_Vit.interactable = false;
            t_Vit.text = "Vitesse Lv " + Level_Vit;

        }


        if (Level_Mania < 10)
        {
            Bt_Mania.interactable = cost_Mani < stat_m.Gold;
            t_Mania.text = "Mania Lv " + Level_Mania+ "\n" + cost_Mani;
        }
        else
        {
            Bt_Mania.interactable = false;
            t_Mania.text = "Mania Lv " + Level_Mania;
        }


        if (Level_Nitro < 10)
        {
            Bt_Nitro.interactable = cost_Nitro < stat_m.Gold;
            t_Nitro.text = "Nitro Lv " + Level_Nitro + "\n" + cost_Nitro;
        }
        else
        {
            Bt_Nitro.interactable = false;
            t_Nitro.text = "Nitro Lv " + Level_Nitro;
        }
    }




    public void Upgrade_Vitesse()
    {
        stat_m.Vitesse += 10;
        Level_Vit++;

        stat_m.Gold -= cost_Vit;
        cost_Vit += 10;
    }
    public void Upgrade_Mania()
    {
        stat_m.Maniabilite += 10;
        Level_Mania++;

        stat_m.Gold -= cost_Mani;
        cost_Mani += 10;
    }
    public void Upgrade_Nitro()
    {
        stat_m.Nitro += 10;
        Level_Nitro++;

        stat_m.Gold -= cost_Nitro;
        cost_Nitro += 10;
    }


    #endregion



    #region Button_CustomTruck

    public void ChangeSkin(int index)
    {
        for (int i = 0; i < renderersTruck.Length; i++)
        {
            if (i == 0)
            {
                renderersTruck[i].material = Resources.Load<Material>("Skin/Body/"+index);
            }
            renderersTruck[i].material = Resources.Load<Material>("Skin/Roue/"+index);
        }
    }


    #endregion


}
