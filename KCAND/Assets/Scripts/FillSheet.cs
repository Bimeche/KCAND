using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillSheet : MonoBehaviour {

    public TextMesh ligne1;
    public TextMesh ligne2;
    public TextMesh ligne3;
    public TextMesh ligne4;
    public TextMesh ligne5;
    int age;
    string pulOed;
    bool pulmonaryOedema;
    bool breathlessness;
    string breath;
    int temp;

    private string meat;
    private string milk;
    private string butter;
    private string cake;
    private int dose;
    private int nb;
    public string word;
    private int random_word;
    private int texture;

    // Use this for initialization


    public bool getPulmonaryOedema()
    {
        return pulmonaryOedema;
    }
    public bool getBreathlessness()
    {
        return breathlessness;
    }

    public int getDose()
    {
        return dose;
    }
    public int getTexture()
    {
        return texture;
    }
    public int getWord()
    {
        return random_word;
    }
    public string getWordMesh()
    {
        return word;
    }
    void Start () {
        age = Random.Range(15, 81);
        temp = Random.Range(0, 4);
        if (temp == 0)
        {
            pulmonaryOedema = false;
            pulOed = "";
        }
        else
        {
            pulmonaryOedema = true;
            pulOed = "A un oedème pulmonaire.";
        }
        temp = Random.Range(0, 4);
        if (temp == 0)
        {
            breathlessness = false;
            breath = "";
        }
        else
        {
            breathlessness = true;
            breath = "Est sujet à des essouflements";
        }
        

        dose = 0;

        switch (Random.Range(0, 3))
        {
            case 0:
                meat = "plus de 100 g de viande mi-maigre,";
                dose += 5;
                break;
            case 1:
                meat = "moins de 50 g de viande grasse,";
                dose += 2;
                break;
            case 2:
                meat = "plus de 200 g de viande maigre,";
                dose += 7;
                break;
        }
        switch (Random.Range(0, 4))
        {
            case 0:
                butter = "15 g de beurre végétal,";
                dose += 2;
                break;
            case 1:
                butter = "50 g de beurre doux,";
                dose += 10;
                break;
            case 2:
                butter = "25 g de beurre salé,";
                dose += 12;
                break;
            case 3:
                butter = "100 g de beurre léger,";
                dose += 15;
                break;
        }
        switch (Random.Range(0, 3))
        {
            case 0:
                milk = "20 ml de lait 10%,";
                dose += 10;
                break;
            case 1:
                milk = "100 ml de lait 2%,";
                dose += 5;
                break;
            case 2:
                milk = "100 ml de lait 1%,";
                dose += 2;
                break;
        }
        switch (Random.Range(0, 2))
        {
            case 0:
                cake = "gâteaux d’une boulangerie.";
                dose += 10;
                break;
            case 1:
                cake = "gâteaux de supermarché.";
                dose += 5;
                break;
            case 2:
                cake = "pas de gâteaux.";
                break;
        }


        texture = Random.Range(0, 2);
        random_word = Random.Range(0, 3);
        switch (random_word)
        {
            case 0:
                word = "café";
                break;
            case 1:
                word = "alcool";
                if (texture == 0)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        FillDocument(ligne1.text, ligne2.text, ligne3.text, "Boit beaucoup d'alcool.", ligne5.text);
                    }
                    else
                    {
                        nb = Random.Range(2, 9);
                        FillDocument(ligne1.text, ligne2.text, ligne3.text, "A perdu " + nb + " fois connaissances.", ligne5.text);
                    }
                }
                break;
            case 2:
                word = "tabac";
                break;
        }


        FillDocument("age : " + age.ToString(), pulOed, breath, ligne4.text, "Alimentation journalière : \n" + meat + "\n" + butter + "\n" + milk + "\n" + cake);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillDocument(string inf1, string inf2, string inf3, string inf4, string inf5)
    {
        ligne1.text = inf1;
        ligne2.text = inf2;
        ligne3.text = inf3;
        ligne4.text = inf4;
        ligne5.text = inf5;
    }
}
