using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [Header("Stats")]
    public pohyb Pohyb;
    public BebControll bebControl;

    [Header("UI Elements")] 
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider crystalBar;
    [SerializeField] private Slider stoneBar;
    public TextMeshProUGUI crystalCountText;
    public TextMeshProUGUI stoneCountText;
    
    void Start()
    {
        UpdateBebHealthUI();
        UpdateCrystalCountUI();
        UpdateStoneCountUI();
    }

    public void UpdateBebHealthUI() //volat - beb takes damage or heals
    {
        hpBar.value = bebControl.currentBebHealth;
        hpBar.maxValue = bebControl.maxBebHealth;
    }
    public void UpdateCrystalCountUI() //volat - sebere crystal nebo neco koupi
    {
        crystalBar.value = bebControl.crystalCount;
        crystalCountText.text = bebControl.crystalCount.ToString();
        crystalBar.maxValue = bebControl.carryCapacity;
    }

    public void UpdateStoneCountUI() { //volat - sebere main quest kamen
        stoneBar.value = Pohyb.stoneCount;
        if(Pohyb.stoneCount < 5)
        {
            stoneCountText.text = "Portal Stones: " + Pohyb.stoneCount.ToString() + "/5";
        }else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
