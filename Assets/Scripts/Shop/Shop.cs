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
    //public Button shopbtn;
    
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
    public float crystalCount;
    public float damageModifier;
    public float health;
    public float attackspeedModifier;
    public float movementspeedModifier;
    public float healthregenModifier;
    public float carrycapacity;
    public float bebhealth;
    public float bebmovementspeedModifier;
    public float miningspeedModifier;

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
        //guiCanvas.enabled = false;
        backbtn.onClick.AddListener(BackbuttonClick);
        //shopbtn.onClick.AddListener(EnableShop);
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
        shopCanvas.enabled = false;
        guiCanvas.enabled = true;
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

        crystalCountText.text = crystalCount.ToString();
        if(carrycapacity != 0)
        {
            crystalFiller.fillAmount = crystalCount / carrycapacity;
        }

        damageModifierText.text = "Damage: " + damageModifier.ToString() + "x";
        healthText.text = "Health: " + health.ToString();
        attackspeedModifierText.text = "Attack Speed: " + attackspeedModifier.ToString() + "x";
        movementspeedModifierText.text = "Movement Speed: " + movementspeedModifier.ToString() + "x";
        healthregenModifierText.text = "Health Regen: " + healthregenModifier.ToString() + "x";

        carrycapacityText.text = "Carry Capacity: " + carrycapacity.ToString();
        bebhealthText.text = "Health: " + bebhealth.ToString();
        bebmovementspeedModifierText.text = "Movement Speed: " + bebmovementspeedModifier.ToString() + "x";
        miningspeedModifierText.text = "Mining Speed: " + miningspeedModifier.ToString() + "x";
    }
    void EnableShop()
    {
        guiCanvas.enabled = false;
        shopCanvas.enabled = true;
    }
    void DamageClick()
    {
        if(dmgCost <= crystalCount)
        {
            crystalCount -= dmgCost;
            damageModifier += 0.2f;
            dmgCost += 50f;
            dmgCount++;
            UpdateShopUI();
        }
    }
    void HealthClick()
    {
        if (healthCost <= crystalCount)
        {
            crystalCount -= healthCost;
            health += 25f;
            healthCost += 50f;
            healthCount++;
            UpdateShopUI();
        }
    }
    void AttackSpeedClick()
    {
        if (attackspeedCost <= crystalCount)
        {
            crystalCount -= attackspeedCost;
            attackspeedModifier += 0.2f;
            attackspeedCost += 50f;
            attackspeedCount++;
            UpdateShopUI();
        }
    }
    void MovementSpeedClick()
    {
        if (movementspeedCost <= crystalCount)
        {
            crystalCount -= movementspeedCost;
            movementspeedModifier += 0.2f;
            movementspeedCost += 50f;
            movementspeedCount++;
            UpdateShopUI();
        }
    }
    void HealthRegenClick()
    {
        if (healthregenCost <= crystalCount)
        {
            crystalCount -= healthregenCost;
            healthregenModifier += 0.2f;
            healthregenCost += 50f;
            healthregenCount++;
            UpdateShopUI();
        }
    }
    void CarryCapacityClick()
    {
        if (carrycapacityCost <= crystalCount)
        {
            crystalCount -= carrycapacityCost;
            carrycapacity += 100f;
            carrycapacityCost += 50f;
            carrycapacityCount++;
            UpdateShopUI();
        }
    }
    void BebHealthClick()
    {
        if (bebhealthCost <= crystalCount)
        {
            crystalCount -= bebhealthCost;
            bebhealth += 50f;
            bebhealthCost += 50f;
            bebhealthCount++;
            UpdateShopUI();
        }
    }
    void BebMovementSpeedClick()
    {
        if (bebmovementspeedCost <= crystalCount)
        {
            crystalCount -= bebmovementspeedCost;
            bebmovementspeedModifier += 0.2f;
            bebmovementspeedCost += 50f;
            bebmovementspeedCount++;
            UpdateShopUI();
        }
    }
    void MiningSpeedClick()
    {
        if (miningspeedCost <= crystalCount)
        {
            crystalCount -= miningspeedCost;
            miningspeedModifier += 0.2f;
            miningspeedCost += 50f;
            miningspeedCount++;
            UpdateShopUI();
        }
    }
}