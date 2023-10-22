using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [Header("Stats")]
    public float bebHealth;
    public float currentBebHealth;
    public float carryCapacity;
    public float crystalCount;
    public float stoneCount;

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

    public void UpdateBebHealthUI()
    {
        hpBar.value = currentBebHealth;
    }
    public void UpdateCrystalCountUI()
    {
        crystalBar.value = crystalCount;
        crystalCountText.text = crystalCount.ToString();
    }

    public void UpdateStoneCountUI() {
        stoneBar.value = stoneCount;
        if(stoneCount < 5)
        {
            stoneCountText.text = "Portal Stones: " + stoneCount.ToString() + "/5";
        }else
        {
            stoneCountText.text = "Go repair the Portal!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
