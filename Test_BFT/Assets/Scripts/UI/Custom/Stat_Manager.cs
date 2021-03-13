using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stat_Manager : MonoBehaviour
{
    #region var_
    public int Gold;

    public float Vitesse, Maniabilite, Nitro;

    #endregion

    #region var_UI
    [Header("UI")]
    [SerializeField] private Text gold_t;
    [SerializeField] private Image bar_Vit, bar_Mani, bar_Nitro;

    #endregion


    private void Update()
    {
        UpdateBarStat();
        gold_t.text = Gold + " :Gold";

    }


    private void UpdateBarStat()
    {
        if (bar_Vit != null)
        {
            bar_Vit.fillAmount = Vitesse / 100;
        }
        if (bar_Mani!= null)
        {
            bar_Mani.fillAmount = Maniabilite / 100;
        }
        if (bar_Nitro != null) 
        {
            bar_Nitro.fillAmount = Nitro / 100;
        }
    }

}