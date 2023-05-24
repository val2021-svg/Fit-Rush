using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showresults : MonoBehaviour
{

    public Image GameCompleted;
    public Image GameOver;

    public Text ProteinsText;
    public Text CarbText;
    public Text FatText;
    public Text ThanksTryAgainText;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("khdam ig");
        var results = GamePlayManager.instance.reslist;
        Debug.Log(results);

        //Proteins
        if (results[0] == 1)
        {
            
            ProteinsText.text = "Too much protein: While protein is an essential nutrient for our bodies, consuming too much can have potential downsides. Excessive protein intake, especially from animal sources, can strain the kidneys, lead to nutrient imbalances, and increase the risk of certain health conditions. It's important to maintain a balanced diet that includes a variety of nutrients.";
        }
        else
        {
            ProteinsText.text = "";
        }

        //Carbs
        if (results[1] == 1)
        {

            CarbText.text = "Too much carbs: Eating too many carbs can lead to weight gain, increased risk \nof chronic diseases, and energy crashes. Remember, balance is key! Opt for whole \ngrains, fruits, and vegetables instead of processed carbs like sugary snacks and refined grains.\r\n";
            CarbText.color = Color.red;
        }
        else
        {
            CarbText.text = "";
        }

        //Fats
        if (results[2] == 1)
        {

            FatText.text = "Too much fat:Consuming too much unhealthy fats can have detrimental effects on your health, including weight gain, increased risk of heart disease, and elevated cholesterol levels.";
        }
        else
        {
            FatText.text = "";
        }

        if (results[0] <= 0 && results[1] <= 0 && results[2] <= 0)
        {
            CarbText.text = "We're thrilled with your progress and dedication to nurturing your health. \nYour commitment to finding harmony in your eating habits is truly commendable.";
            ThanksTryAgainText.text = "Congratulations!";
            CarbText.color = Color.gray;
            ThanksTryAgainText.color = Color.gray;
            GameCompleted.enabled = true;
            GameOver.enabled = false;
            
        }else
        {
            ThanksTryAgainText.text = "Please try again!!";
            ThanksTryAgainText.color = Color.red;
            GameCompleted.enabled = false;
            GameOver.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
