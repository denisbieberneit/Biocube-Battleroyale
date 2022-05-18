using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectionController : MonoBehaviour
{
    private Animator anim;

    private string characterKey = "Character";
    private int selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        selectedCharacter = 1;
        ShowSkinBasedOnSelection();
        //SelectHero();
    }
   

    public void NextHero(){
        selectedCharacter = selectedCharacter + 1;
        if (selectedCharacter == 4)
        {
            selectedCharacter = 1;
        }
        ShowSkinBasedOnSelection();
    }
    public void LastHero()
    {
        selectedCharacter = selectedCharacter - 1;
        if (selectedCharacter == 0)
        {
            selectedCharacter = 3;
        }
        ShowSkinBasedOnSelection();
    }

    private void ShowSkinBasedOnSelection(){
        
        ResetAllSkins();
        if (selectedCharacter == 1)
        {
            anim.SetBool("isMage", true);
        }
        if (selectedCharacter == 2)
        {
            anim.SetBool("isEvilMage", true);
        }
        if (selectedCharacter == 3)
        {
            anim.SetBool("isHuntress", true);
        }
    }
    private void ResetAllSkins()
    {
        anim.SetBool("isMage", false);
        anim.SetBool("isEvilMage", false);
        anim.SetBool("isHuntress", false);
    }

    public void StartGame(){
        PlayerPrefs.SetInt(characterKey, selectedCharacter);
        SceneManager.LoadScene("Main");
    }
}
