using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Initialisations

    private int coins {get ; set ;} //variable membre
    private float counter;

    public float cooldown;
    public Text CoinsText;

    #endregion

    #region Lists

    public List<string> Names = new List<string>(); //nécessaire pour initialiser
    public List<int> Numbers = new List<int>();
    public List<int> Costs = new List<int>();
    public List<int> Cooldowns = new List<int>();
    private List<float> Counters = new List<float>() {0, 0, 0, 0}; //created here, so we need to initalize it here too
    public List<int> Rates = new List<int>();

    #endregion
    #region Lists Associated Initialisations

    public Text PiggyBankText;
    public Text CashDispenserText;
    public Text BankVaultText;
    public Text CashPrinterText;

    [SerializeField]
    private GameObject PiggyBank;
    [SerializeField]
    private GameObject CashDispenser;
    [SerializeField]
    private GameObject BankVault;
    [SerializeField]
    private GameObject CashPrinter;

    #endregion
    
    #region Custom Functions
       
    //O- BuyElements --------------------------------------------------------------------------------------
    public void BuyPiggyBank () {
        if (coins >= Costs[0]) {
            coins -= Costs[0];
            UpdateCoinsDisplay(coins);
            Numbers[0]++;
            PiggyBankText.text = Names[0] + ": " + Numbers[0].ToString() + " (+" + (Numbers[0]*Rates[0]).ToString() + "/" + Cooldowns[0].ToString() + "s)";
        }
    }
    public void BuyCashDispenser () {
        if (coins >= Costs[1]) {
            coins -= Costs[1];
            UpdateCoinsDisplay(coins);
            Numbers[1]++;
            CashDispenserText.text = Names[1] + ": " + Numbers[1].ToString() + " (+" + (Numbers[1]*Rates[1]).ToString() + "/" + Cooldowns[1].ToString() + "s)";
        }
    }
    public void BuyBankVault () {
        if (coins >= Costs[2]) {
            coins -= Costs[2];
            UpdateCoinsDisplay(coins);
            Numbers[2]++;
            BankVaultText.text = Names[2] + ": " + Numbers[2].ToString() + " (+" + (Numbers[2]*Rates[2]).ToString() + "/" + Cooldowns[2].ToString() + "s)";
        }
    }
    public void BuyCashPrinter () {
        if (coins >= Costs[3]) {
            coins -= Costs[3];
            UpdateCoinsDisplay(coins);
            Numbers[3]++;
            CashPrinterText.text = Names[3] + ": " + Numbers[3].ToString() + " (+" + (Numbers[3]*Rates[3]).ToString() + "/" + Cooldowns[3].ToString() + "s)";
        }
    }    


    /*  Doesn't work because of the "[...]Text.text"
    public void BuyElements() { 
        for(int i = 0; i <= 2; i++){
            if (coins >= Costs[i]) {
                coins -= Costs[i];
                UpdateCoinsDisplay(coins);
                Numbers[i]++;
                PiggyBankText.text = Names[i] + ": " + Numbers[i].ToString();
            }
        }
    }
    */

    //C- --------------------------------------------------------------------------------------------------

    public int Increment(int value){
        int total = coins + value;
        
        UpdateCoinsDisplay(total);
        //Debug.Log(total);
        return total;
    }
    public void ManualIncrement(){ //we need this to add the function on the button "On Click"
        coins = Increment(1);
    }

    private void UpdateCoinsDisplay(int newNumber){
        CoinsText.text = "Coins: " + newNumber.ToString();
    }
    
    #endregion
    #region Unity Functions

    void Start()
    {
        coins = 0; //Init coins nb
        CoinsText.text = "Coins: 0";

        PiggyBank.GetComponent<Image>().color = Color.red;
        CashDispenser.GetComponent<Image>().color = Color.red;
        BankVault.GetComponent<Image>().color = Color.red;
        CashPrinter.GetComponent<Image>().color = Color.red;
    }

    void Update()
    {
        //I- Basic Counter --------------------------------------------------
        counter += Time.deltaTime;
        if (counter >= cooldown) {
            coins = Increment(1);
            counter -= cooldown;
        }
        //O- Basic Counter --------------------------------------------------
        //I- All Elements Counter -------------------------------------------
        for (int i = 0; i <= 3; i++) {
            Counters[i] += Time.deltaTime;
            if (Counters[i] >= Cooldowns[i]){
                coins = Increment(Rates[i]*Numbers[i]);
                Counters[i] -= Cooldowns[i];
            }
        }
        //O- All Elements Counter -------------------------------------------
        //I- Elements Colors ------------------------------------------------
        var colorPiggyBank = PiggyBank.GetComponent<Image>().color;
        var colorCashDispenser = CashDispenser.GetComponent<Image>().color;
        var colorBankVault = BankVault.GetComponent<Image>().color;
        var colorCashPrinter = CashPrinter.GetComponent<Image>().color;

        if (coins >= Costs[0]) {
            colorPiggyBank = Color.green;
        }
        else colorPiggyBank = Color.red;

        if (coins >= Costs[1]) {
            colorCashDispenser = Color.green;
        }
        else colorCashDispenser = Color.red;  

        if (coins >= Costs[2]) {
            colorBankVault = Color.green;
        }
        else colorBankVault = Color.red;

        if (coins >= Costs[3]) {
            colorCashPrinter = Color.green;
        }
        else colorCashPrinter = Color.red;

        PiggyBank.GetComponent<Image>().color = colorPiggyBank;
        CashDispenser.GetComponent<Image>().color = colorCashDispenser;
        BankVault.GetComponent<Image>().color = colorBankVault;
        CashPrinter.GetComponent<Image>().color = colorCashPrinter;
        //O- Elements Colors ------------------------------------------------
    }

    #endregion
}
