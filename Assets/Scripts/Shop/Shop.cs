using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Player Buttons")]
    public Button dmgbtn;
    public Button healthbtn;
    public Button attackspeedbtn;
    public Button movementspeedbtn;
    public Button healthregenbtn;
    [Header("Beb Buttons")]
    public Button carrycapacitybtn;
    public Button bebhealthbtn;
    public Button bebmovementspeedbtn;
    public Button miningspeedbtn;

    [Header("Player Upgrade Names")]
    public TextMeshProUGUI dmgName;
    public TextMeshProUGUI healthName;
    public TextMeshProUGUI attackspeedName;
    public TextMeshProUGUI movementspeedName;
    public TextMeshProUGUI healthregenName;
    [Header("Beb Upgrade Names")]
    public TextMeshProUGUI carrycapacityName;
    public TextMeshProUGUI bebhealthName;
    public TextMeshProUGUI bebmovementspeedName;
    public TextMeshProUGUI miningspeedName;

    [Header("Other Elements")]
    public Button backbtn;
    public Canvas shopCanvas;
    public Canvas guiCanvas;
    public Image crystalFiller;
    
    private int dmgCount = 0;
    private int healthCount = 0;
    private int attackspeedCount = 0;
    private int movementspeedCount = 0;
    private int healthregenCount = 0;
    private int carrycapacityCount = 0;
    private int bebhealthCount = 0;
    private int bebmovementspeedCount = 0;
    private int miningspeedCount = 0;

    [Header("Cost of Upgrades")]
    public float dmgCost;
    public float healthCost;
    public float attackspeedCost;
    public float movementspeedCost;
    public float healthregenCost;
    public float carrycapacityCost;
    public float bebhealthCost;
    public float bebmovementspeedCost;
    public float miningspeedCost;

    [Header("Player Upgrade Cost Text")]
    public TextMeshProUGUI dmgCostText;
    public TextMeshProUGUI healthCostText;
    public TextMeshProUGUI attackspeedCostText;
    public TextMeshProUGUI movementspeedCostText;
    public TextMeshProUGUI healthregenCostText;
    [Header("Beb Upgrade Cost Text")]
    public TextMeshProUGUI carrycapacityCostText;
    public TextMeshProUGUI bebhealthCostText;
    public TextMeshProUGUI bebmovementspeedCostText;
    public TextMeshProUGUI miningspeedCostText;

    [Header("Player and Beb stats")]
    public pohyb Pohyb;
    public BebControll bebControl;

    [Header("Player and Beb stats Texts")]
    public TextMeshProUGUI crystalCountText;
    public TextMeshProUGUI damageModifierText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackspeedModifierText;
    public TextMeshProUGUI movementspeedModifierText;
    public TextMeshProUGUI healthregenModifierText;
    public TextMeshProUGUI carrycapacityText;
    public TextMeshProUGUI bebhealthText;
    public TextMeshProUGUI bebmovementspeedModifierText;
    public TextMeshProUGUI miningspeedModifierText;

    void Start()
    {
        guiCanvas.enabled = false;
        backbtn.onClick.AddListener(BackbuttonClick);

        dmgbtn.onClick.AddListener(DamageClick);
        healthbtn.onClick.AddListener(HealthClick);
        attackspeedbtn.onClick.AddListener(AttackSpeedClick);
        movementspeedbtn.onClick.AddListener(MovementSpeedClick);
        healthregenbtn.onClick.AddListener(HealthRegenClick);
        carrycapacitybtn.onClick.AddListener(CarryCapacityClick);
        bebhealthbtn.onClick.AddListener(BebHealthClick);
        bebmovementspeedbtn.onClick.AddListener(BebMovementSpeedClick);
        miningspeedbtn.onClick.AddListener(MiningSpeedClick);
        UpdateShopUI();

    }
    void BackbuttonClick()
    {
        Debug.Log("clicked");
        guiCanvas.enabled = true;
        Time.timeScale = 1;
        shopCanvas.enabled = false;
    }
    void UpdateShopUI()
    {
        dmgName.text = "Damage " + (dmgCount + 1);
        dmgCostText.text = dmgCost.ToString();

        healthName.text = "Health " + (healthCount + 1);
        healthCostText.text = healthCost.ToString();

        attackspeedName.text = "Attackspeed " + (attackspeedCount + 1);
        attackspeedCostText.text = attackspeedCost.ToString();

        movementspeedName.text = "Movement Speed " + (movementspeedCount + 1);
        movementspeedCostText.text = movementspeedCost.ToString();

        healthregenName.text = "Health Regeneration " + (healthregenCount + 1);
        healthregenCostText.text = healthregenCost.ToString();

        carrycapacityName.text = "Carry Capacity " + (carrycapacityCount + 1);
        carrycapacityCostText.text = carrycapacityCost.ToString();

        bebhealthName.text = "Health " + (bebhealthCount + 1);
        bebhealthCostText.text = bebhealthCost.ToString();

        bebmovementspeedName.text = "Movement Speed " + (bebmovementspeedCount + 1);
        bebmovementspeedCostText.text = bebmovementspeedCost.ToString();

        miningspeedName.text = "Mining Speed " + (miningspeedCount + 1);
        miningspeedCostText.text = miningspeedCost.ToString();

        crystalCountText.text = bebControl.crystalCount.ToString();
        if(bebControl.carryCapacity != 0)
        {
            crystalFiller.fillAmount = bebControl.crystalCount / bebControl.carryCapacity;
        }

        damageModifierText.text = "Damage: " + Pohyb.damageModifier.ToString() + "x";
        healthText.text = "Health: " + Pohyb.hp.ToString();
        attackspeedModifierText.text = "Attack Speed: " + Pohyb.attackSpeedModifier.ToString() + "x";
        movementspeedModifierText.text = "Movement Speed: " + Pohyb.movementSpeedModifier.ToString() + "x";
        healthregenModifierText.text = "Health Regen: " + Pohyb.hpRegenModifier.ToString() + "x";

        carrycapacityText.text = "Carry Capacity: " + bebControl.carryCapacity.ToString();
        bebhealthText.text = "Health: " + bebControl.maxBebHealth.ToString();
        bebmovementspeedModifierText.text = "Movement Speed: " + bebControl.bebSpeed.ToString() + "x";
        miningspeedModifierText.text = "Mining Speed: " + bebControl.miningSpeed.ToString() + "x";
    }
   
    
    void DamageClick()
    {
        if(dmgCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= dmgCost;
            Pohyb.damageModifier += 0.2f;
            dmgCost += 50f;
            dmgCount++;
            UpdateShopUI();
        }
    }
    void HealthClick()
    {
        if (healthCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= healthCost;
            Pohyb.hp += 25f;
            healthCost += 50f;
            healthCount++;
            UpdateShopUI();
        }
    }
    void AttackSpeedClick()
    {
        if (attackspeedCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= attackspeedCost;
            Pohyb.attackSpeedModifier += 0.2f;
            attackspeedCost += 50f;
            attackspeedCount++;
            UpdateShopUI();
        }
    }
    void MovementSpeedClick()
    {
        if (movementspeedCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= movementspeedCost;
            Pohyb.movementSpeedModifier += 0.2f;
            movementspeedCost += 50f;
            movementspeedCount++;
            UpdateShopUI();
        }
    }
    void HealthRegenClick()
    {
        if (healthregenCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= healthregenCost;
            Pohyb.hpRegenModifier += 0.2f;
            healthregenCost += 50f;
            healthregenCount++;
            UpdateShopUI();
        }
    }
    void CarryCapacityClick()
    {
        if (carrycapacityCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= carrycapacityCost;
            bebControl.carryCapacity += 100f;
            carrycapacityCost += 50f;
            carrycapacityCount++;
            UpdateShopUI();
        }
    }
    void BebHealthClick()
    {
        if (bebhealthCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= bebhealthCost;
            bebControl.maxBebHealth += 50f;
            bebhealthCost += 50f;
            bebhealthCount++;
            UpdateShopUI();
        }
    }
    void BebMovementSpeedClick()
    {
        if (bebmovementspeedCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= bebmovementspeedCost;
            bebControl.bebSpeed += 0.2f;
            bebmovementspeedCost += 50f;
            bebmovementspeedCount++;
            UpdateShopUI();
        }
    }
    void MiningSpeedClick()
    {
        if (miningspeedCost <= bebControl.crystalCount)
        {
            bebControl.crystalCount -= miningspeedCost;
            bebControl.miningSpeed += 0.2f;
            miningspeedCost += 50f;
            miningspeedCount++;
            UpdateShopUI();
        }
    }
}