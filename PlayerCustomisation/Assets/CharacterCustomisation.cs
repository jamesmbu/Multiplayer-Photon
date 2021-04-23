using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CharacterCustomisation : MonoBehaviourPun
{
    enum MODEL_DETAILS
    {
        HAIR_MODEL,
        BEARD_MODEL,
        OUTFIT_MODEL,
        PROP_MODEL,
        SKIN_COLOUR,
        HAIR_COLOUR,

    }
    public GameObject Canvas;
    public GameObject PlayerHead;
    public GameObject PlayerBody;

    public GameObject[] Hair;
    public GameObject[] Beard;
    public GameObject[] Outfit;
    public GameObject[] Prop;

    public Texture[] skinTexture;
    public Texture[] beardTextures;

    // Hair Textures 
    public Texture[] hair_a_textures;
    public Texture[] hair_b_textures;
    public Texture[] hair_c_textures;
    public Texture[] hair_d_textures;
    public Texture[] hair_e_textures;

   //hair
    private GameObject currentHair;
    private GameObject PrevHair;
    //beard
    private GameObject currentBeard;
    private GameObject PrevBeard;
    //outfit
    private GameObject currentOutfit;
    private GameObject PrevOutfit;
    //prop
    public GameObject CurrentProps;
    private GameObject PrevProps;

    private Texture currentHairColour;
    private Texture PrevHairColour;
    private Texture PrevSkin;
    private Texture currentskin;


    int HairIndex = 0;
    int BeardIndex = 0;
    int OutfitIndex = 0;
    int PropIndex = 0;
    int skinTextureIndex = 0;
    int BeardTexture = 0;

    Dictionary<MODEL_DETAILS, int> Save_Model;

    bool IndexCheck(int index, GameObject[] arraylength)
    {
        int length = arraylength.Length;
        return index <(length-1);
    }
    public void ModifyHairUp()
    {
        if(IndexCheck(HairIndex, Hair))
            HairIndex++; 
        else
            HairIndex = 0;
        ApplyModification(MODEL_DETAILS.HAIR_MODEL, HairIndex);
    }

    public void ModifyHairDown()
    {
        if (HairIndex < Hair.Length ) 
            HairIndex--; 
        else 
            HairIndex = 0; 
        ApplyModification(MODEL_DETAILS.HAIR_MODEL, HairIndex);
    }

    public void ModifyBeardUp()
    {
        if (IndexCheck(BeardIndex, Beard))
            BeardIndex++;
        else
            BeardIndex = 0;
        ApplyModification(MODEL_DETAILS.BEARD_MODEL, BeardIndex);
    }

    public void ModifyBeardDown()
    {
        if (BeardIndex < Beard.Length)
            BeardIndex--;
        else
            BeardIndex = 0;
        ApplyModification(MODEL_DETAILS.BEARD_MODEL, BeardIndex);
    }


    public void ModifyOutfitUp()
    {
        if (IndexCheck(OutfitIndex, Outfit))
            OutfitIndex++;
        else
            OutfitIndex = 0;
        ApplyModification(MODEL_DETAILS.OUTFIT_MODEL, OutfitIndex);
    }

    public void ModifyOutfitDown()
    {
        if (OutfitIndex < Outfit.Length)
            OutfitIndex--;
        else
            OutfitIndex = 0;
        ApplyModification(MODEL_DETAILS.OUTFIT_MODEL, OutfitIndex);
    }

    public void ModifyPropUp()
    {
        if (IndexCheck(PropIndex, Prop))
            PropIndex++;
        else
            PropIndex = 0;
        ApplyModification(MODEL_DETAILS.PROP_MODEL, PropIndex);
    }

    public void ModifyPropDown()
    {
        if (PropIndex < Prop.Length)
            PropIndex--;
        else
            PropIndex = 0;
        ApplyModification(MODEL_DETAILS.PROP_MODEL, PropIndex);
    }

    [PunRPC]void ApplyModification(MODEL_DETAILS details, int id)
    {
        if (photonView.IsMine)
        {
            switch (details)
            {
                case MODEL_DETAILS.HAIR_MODEL:
                    if (PrevHair != null)
                    {
                        PrevHair.SetActive(false);
                    }
                    currentHair = Hair[id];
                    currentHair.SetActive(true);
                    PrevHair = currentHair;
                    break;
                case MODEL_DETAILS.BEARD_MODEL:
                    if (PrevBeard != null)
                    {
                        PrevBeard.SetActive(false);
                    }
                    currentBeard = Beard[id];
                    currentBeard.SetActive(true);
                    PrevBeard = currentBeard;
                    break;
                case MODEL_DETAILS.OUTFIT_MODEL:
                    if (PrevOutfit != null)
                    {
                        PrevOutfit.SetActive(false);
                    }
                    currentOutfit = Outfit[id];
                    currentOutfit.SetActive(true);
                    PrevOutfit = currentOutfit;
                    break;
                case MODEL_DETAILS.PROP_MODEL:
                    if (PrevProps != null)
                    {
                        PrevProps.SetActive(false);
                    }
                    CurrentProps = Prop[id];
                    CurrentProps.SetActive(true);
                    PrevProps = CurrentProps;
                    break;

                default: break;
            }
        }
    }

    public void SaveButton()
    {
        Save_Model = new Dictionary<MODEL_DETAILS, int>();
        Save_Model.Add(MODEL_DETAILS.HAIR_MODEL, HairIndex);
        Save_Model.Add(MODEL_DETAILS.BEARD_MODEL, BeardIndex);
        Save_Model.Add(MODEL_DETAILS.OUTFIT_MODEL, OutfitIndex);
        Save_Model.Add(MODEL_DETAILS.PROP_MODEL, PropIndex);
        GameObject.Destroy(Canvas);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}