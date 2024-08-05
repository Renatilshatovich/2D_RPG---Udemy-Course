using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] private GameObject endText;
    [Space]
    
    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skillTreeUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject inGameUI;
    
    public UI_SkillToolTip skillToolTip;
    public UI_ItemToolTip itemToolTip;
    public UI_StatToolTip statToolTip;
    public UI_CraftWindow craftWindow;

    private void Awake()
    {
        SwitchTo(skillTreeUI);
    }

    void Start()
    {
        SwitchTo(inGameUI);

        itemToolTip.gameObject.SetActive(false);
        statToolTip.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SwitchWithKeyTo(characterUI);        
        
        if (Input.GetKeyDown(KeyCode.B))
            SwitchWithKeyTo(craftUI);        
        
        if (Input.GetKeyDown(KeyCode.K))
            SwitchWithKeyTo(skillTreeUI);        
        
        if (Input.GetKeyDown(KeyCode.O))
            SwitchWithKeyTo(optionsUI);
    }

    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;
            
            if (fadeScreen == false)
                transform.GetChild(i).gameObject.SetActive(false);
        }
        
        if (_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            CheckForInGamUI();
            return;
        }
        
        SwitchTo(_menu);
    }

    private void CheckForInGamUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                return;
        }
        
        SwitchTo(inGameUI);
    }

    public void SwitchOnEndScreen()
    {
        SwitchTo(null);
        fadeScreen.FadeOut();
        StartCoroutine(EndScreenCoroutine());
    }

    IEnumerator EndScreenCoroutine()
    {
        yield return new WaitForSeconds(2);
        
        endText.SetActive(true);
    }
}