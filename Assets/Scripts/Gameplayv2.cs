using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Gameplayv2 : MonoBehaviour
{

    public AudioSource MunchSound;

    public GameObject Player;
    public GameObject startPoint;

    public GameObject AppleOriginal;
    public GameObject MeatOriginal;
    public GameObject MilkOriginal;

    public GameObject AppleOriginal2;
    public GameObject MeatOriginal2;
    public GameObject MilkOriginal2;

    public GameObject AppleContainer;
    public GameObject MeatContainer;
    public GameObject MilkContainer;
    public GameObject RespawnContainer;

    

    public int Appletaken;
    public int Milktaken;
    public int Meattaken;

    public int CarbsGoal;
    public int FatsGoal;
    public int ProteinsGoal;

    public int AppleGoal;
    public int MilkGoal;




    public TMP_Text ProteinsText;
    public TMP_Text FatsText;
    public TMP_Text CarbsText;
    public TMP_Text ResultText;
    public TMP_Text TimerText;


    private int proteins = 0;
    private int fats = 0;
    private int carbs = 0;

    public bool islevelfinished = false;
    public float timeremaining = 200;
    private string roundedtimeremaining;




    // Start is called before the first frame update
    void Start()
    {



        ResultText.text = "";

        int applenumber = Random.Range(6, 8);
        int meatnumber = Random.Range(4, 6);
        int milknumber = Random.Range(8, 10);

        GenerateLevel(applenumber, milknumber, meatnumber);


    }

    // Update is called once per frame
    void Update()
    {
        if (timeremaining > 0)
        {
            timeremaining -= Time.deltaTime;
            roundedtimeremaining = timeremaining.ToString("#.#");
            TimerText.text = roundedtimeremaining + "s";
        }
        else
        {
            //CheckLevelResult();
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene("Scenes/Level 1", LoadSceneMode.Additive);
        }



        if (islevelfinished)
        {
            fats = 0;
            proteins = 0;
            carbs = 0;
            DestroyAllFood();

            int applenumber = Random.Range(6, 8);
            int meatnumber = Random.Range(4, 6);
            int milknumber = Random.Range(8, 10);

            GenerateLevel(applenumber, milknumber, meatnumber);


            islevelfinished = false;
        }

        if (Player.transform.position.y <= -12)
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene("Scenes/Level 1", LoadSceneMode.Additive);
        }
    }



    void GenerateLevel(int applenum, int milknum, int meatnum)
    {
        var respawns = new List<GameObject>();
        foreach (Transform child in RespawnContainer.transform) respawns.Add(child.gameObject);

        var count = respawns.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = respawns[i];
            respawns[i] = respawns[r];
            respawns[r] = tmp;
        }




        timeremaining = 200;
        Player.transform.position = startPoint.transform.position;

        Milktaken = 0;
        Meattaken = 0;
        Appletaken = 0;

        CarbsGoal = applenum - Random.Range(1, 3);
        FatsGoal = meatnum - Random.Range(1, 3);
        ProteinsGoal = milknum - Random.Range(1, 3);

        CreateApples(applenum, 0, respawns);
        CreateMilks(milknum, applenum, respawns);
        CreateMeats(meatnum, applenum + milknum, respawns);

        CarbsText.text = "Carbs : " + carbs + "/" + CarbsGoal;
        FatsText.text = "Fats : " + fats + "/" + FatsGoal;
        ProteinsText.text = "Proteins : " + proteins + "/" + ProteinsGoal;
    }

    void CreateApples(int num, int depart, List<GameObject> respawns)
    {
        for (int i = 0; i < num; i++)
        {

            CreateAppleAtPosition(depart + i, i, respawns);
        }
    }

    void CreateAppleAtPosition(int pos, int indic, List<GameObject> respawns)
    {
        float foodin = Random.Range(0.00f, 1.00f);
        if (foodin <= 0.5)
        {
            GameObject AppleClone = Instantiate(AppleOriginal);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "AppleClone" + (indic + 1);
        }
        else
        {
            GameObject AppleClone = Instantiate(AppleOriginal2);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "AppleClone" + (indic + 1);
        }

        
    }

    void CreateMilks(int num, int depart, List<GameObject> respawns)
    {
        for (int i = 0; i < num; i++)
        {
            CreateMilksAtPosition(depart + i, i, respawns);
        }
    }

    void CreateMilksAtPosition(int pos, int indic, List<GameObject> respawns)
    {
        float foodin = Random.Range(0.00f, 1.00f);
        if (foodin <= 0.5)
        {
            GameObject AppleClone = Instantiate(MilkOriginal);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "MilkClone" + (indic + 1);
        }
        else
        {
            GameObject AppleClone = Instantiate(MilkOriginal2);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "MilkClone" + (indic + 1);
        }
    }

    void CreateMeats(int num, int depart, List<GameObject> respawns)
    {
        for (int i = 0; i < num; i++)
        {
            CreateMeatsAtPosition(depart + i, i, respawns);
        }
    }

    void CreateMeatsAtPosition(int pos, int indic, List<GameObject> respawns)
    {
        float foodin = Random.Range(0.00f, 1.00f);
        if (foodin <= 0.5)
        {
            GameObject AppleClone = Instantiate(MeatOriginal);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "MeatClone" + (indic + 1);
        }
        else
        {
            GameObject AppleClone = Instantiate(MeatOriginal2);
            AppleClone.transform.position = respawns[pos].transform.position;
            AppleClone.transform.parent = AppleContainer.transform;
            AppleClone.name = "MeatClone" + (indic + 1);
        }
    }

    void DestroyAllFood()
    {
        var food = new List<GameObject>();
        foreach (Transform child in AppleContainer.transform) food.Add(child.gameObject);
        foreach (Transform child in MilkContainer.transform) food.Add(child.gameObject);
        foreach (Transform child in MeatContainer.transform) food.Add(child.gameObject);
        food.ForEach(child => Destroy(child));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Appletaken += 1;
            carbs = carbs + 1;
            CarbsText.text = "Carbs : " + carbs + "/" + CarbsGoal;
            Destroy(other.gameObject);
            Debug.Log("coll");
            MunchSound.Play();
            timeremaining += 4;
        }
        if (other.gameObject.CompareTag("Milk"))
        {
            Milktaken += 1;
            proteins = proteins + 1;
            ProteinsText.text = "Proteins : " + proteins + "/" + ProteinsGoal;
            Destroy(other.gameObject);
            MunchSound.Play();
            timeremaining += 6;
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            Meattaken += 1;
            fats = fats + 1;
            FatsText.text = "Fats : " + fats + "/" + FatsGoal;
            Destroy(other.gameObject);
            MunchSound.Play();
            timeremaining -= 3;
        }

        if (other.gameObject.CompareTag("FinishPoint"))
        {
            if (proteins >= ProteinsGoal-1 && carbs >= CarbsGoal-1 && fats >= FatsGoal - 1)
            {
                Debug.Log("9st finish point");
                timeremaining += 3600;
                GetResult();
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
            }

        }


    }

    void CheckLevelResult()
    {

        ///if (Mathf.Abs(Milktaken - ProteinsGoal) <= 1 && Mathf.Abs(Appletaken - CarbsGoal) <= 1 && Mathf.Abs(Meattaken - FatsGoal) <= 1)
        if (Milktaken >= ProteinsGoal && Appletaken >= CarbsGoal && Meattaken >= FatsGoal)
        {
            islevelfinished = true;


            if (Milktaken >= ProteinsGoal + 2 || Appletaken >= CarbsGoal + 2 || Meattaken >= FatsGoal + 2)
            {
                islevelfinished = true;
                ResultText.text = "Try Again!";
            }
            else
            {
                ResultText.text = "Good Job!";
            }
        }


        else
        {
            if (timeremaining <= 0)
            {
                islevelfinished = true;
                ResultText.text = "Try Again!";
            }
        }
    }

    public void GetResult()
    {
        // Proteins Carbs Fats
        GamePlayManager.instance.reslist = new List<int>();
        //reslist = new List<int>();
        //Proteins
        if (Milktaken >= ProteinsGoal + 2)
        {
            GamePlayManager.instance.reslist.Add(1);
        }
        else if (Milktaken == ProteinsGoal)
        {
            GamePlayManager.instance.reslist.Add(0);
        }
        else
        {
            GamePlayManager.instance.reslist.Add(-1);
        }
        //Carbs
        if (Appletaken >= CarbsGoal + 2)
        {
            GamePlayManager.instance.reslist.Add(1);
        }
        else if (Appletaken == CarbsGoal)
        {
            GamePlayManager.instance.reslist.Add(0);
        }
        else
        {
            GamePlayManager.instance.reslist.Add(-1);
        }

        //Fats
        if (Meattaken >= FatsGoal + 2)
        {
            GamePlayManager.instance.reslist.Add(1);
        }
        else if (Meattaken == FatsGoal)
        {
            GamePlayManager.instance.reslist.Add(0);
        }
        else
        {
            GamePlayManager.instance.reslist.Add(-1);
        }
    }


}
