using System.Collections;
using UnityEngine;

public class Vehicle_Modifier : MonoBehaviour
{

    private Manager_Custom mcus;

    //public int Vitesse, Maniabilite, Nitro;


    private void Awake()
    {
        mcus = GetComponent<Manager_Custom>();
    }

    private void Start()
    {
        for (int i = 0; i < mcus.renderersTruck.Length; i++)
        {
            if (i == 0 && PlayerPrefs.HasKey("body"))
            {
                //Debug.Log("load body");

                mcus.renderersTruck[0].material = Resources.Load<Material>("Skin/Body/" + PlayerPrefs.GetInt("body"));
            }
            else if(i == 0)
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

                 PlayerPrefs.SetInt("roue", 0);
                 mcus.renderersTruck[i].material = Resources.Load<Material>("Skin/Roue/" + 0);
            }

        }


    }

    public void ChangeSkin(int index)
    {
        PlayerPrefs.SetInt("body", index);
        PlayerPrefs.SetInt("roue", index);
        Debug.Log("save");
    }

}