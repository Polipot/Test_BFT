using System.Collections;
using UnityEngine;

public class Vehicle_Modifier : MonoBehaviour
{
    #region Var_Menu

    private Manager_Custom mcus;
    //public int Vitesse, Maniabilite, Nitro;

    #endregion




    #region Var_inGame

    private Player_Movement pm;
    [SerializeField] private MeshRenderer[] myrenderes;

    #endregion







    private void Awake()
    {
        mcus = GetComponent<Manager_Custom>();
        pm = GetComponent<Player_Movement> ();

        //pm?.gameObject.GetComponentsInChildren<MeshRenderer>();
    }


    private void Start()
    {
        if (mcus != null)
        {
            /*for (int i = 0; i < mcus.renderersTruck.Length; i++)
            {
                if (i == 0 && PlayerPrefs.HasKey("body"))
                {
                    //Debug.Log("load body");

                    mcus.renderersTruck[0].material = Resources.Load<Material>("Skin/Body/" + PlayerPrefs.GetInt("body"));
                }
                else if (i == 0)
                {
                    //Debug.Log("create body");

                    PlayerPrefs.SetInt("body", 0);
                    mcus.renderersTruck[0].material = Resources.Load<Material>("Skin/Body/" + 0);
                }


                if (PlayerPrefs.HasKey("roue"))
                {
                    //Debug.Log("load roue");
                    mcus.renderersTruck[i].material = Resources.Load<Material>("Skin/Roue/" + PlayerPrefs.GetInt("roue"));
                }
                else
                {
                    //Debug.Log("create roue");

                    PlayerPrefs.SetInt("roue", 2);
                    mcus.renderersTruck[i].material = Resources.Load<Material>("Skin/Roue/" + 2);
                }

            }*/
        }
        else if (pm != null)
        {
            // change skin of player
            myrenderes[0].material = myrenderes[0].material = Resources.Load<Material>("Skin/CSBody/" + PlayerPrefs.GetInt("body"));
        }
    }

    public void ChangeSkin(int index)
    {
        PlayerPrefs.SetInt("body", index);
        //PlayerPrefs.SetInt("roue", index);
        Debug.Log("save");
    }

}