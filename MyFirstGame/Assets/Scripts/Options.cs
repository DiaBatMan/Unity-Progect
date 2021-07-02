using UnityEngine;
using UnityEngine.UI;
//—крипт насторек в меню
public class Options : MonoBehaviour
{
    public GameObject yellow,blue,red,black;
    public int yCount, bCount, rCount, bkCount;
    public Text yText, bText, rText, bkText;
    private void Start()
    {
        //установка цветов дл€ врагов
        red.GetComponent<Renderer>().material.color = Color.red;
        yellow.GetComponent<Renderer>().material.color = Color.yellow;
        blue.GetComponent<Renderer>().material.color = Color.blue;
        black.GetComponent<Renderer>().material.color = Color.black;

        
        //загрузка из сохранени€ текущего цвета —≈Ѕя
        if (PlayerPrefs.HasKey("myColor"))
        {
            if (PlayerPrefs.GetString("myColor") == "r")
                GetComponent<Renderer>().material.color = Color.red;
            if (PlayerPrefs.GetString("myColor") == "g")
                GetComponent<Renderer>().material.color = Color.green;
            if (PlayerPrefs.GetString("myColor") == "b")
                GetComponent<Renderer>().material.color = Color.blue;
            if (PlayerPrefs.GetString("myColor") == "p")
                GetComponent<Renderer>().material.color = Color.magenta;
            if (PlayerPrefs.GetString("myColor") == "o")
                GetComponent<Renderer>().material.color = new Color(255, 134, 0);
            if (PlayerPrefs.GetString("myColor") == "y")
                GetComponent<Renderer>().material.color = Color.yellow;
            if (PlayerPrefs.GetString("myColor") == "bk")
                GetComponent<Renderer>().material.color = Color.black;
        }
        else GetComponent<Renderer>().material.color = Color.green;
        //загрузка из сохранение количества врагов
        if(PlayerPrefs.HasKey("bkCount")|| PlayerPrefs.HasKey("rCount")|| PlayerPrefs.HasKey("yCount")|| PlayerPrefs.HasKey("bCount"))
        {
            yCount = PlayerPrefs.GetInt("yCount");
            bCount = PlayerPrefs.GetInt("bCount");
            rCount = PlayerPrefs.GetInt("rCount");
            bkCount = PlayerPrefs.GetInt("bkCount");

        }
        else
        {
            yCount = 30;
            bCount = 8;
            rCount = 6;
            bkCount = 2;

        }

        bText.text = bCount.ToString();
        rText.text = rCount.ToString();
        yText.text = yCount.ToString();
        bkText.text = bkCount.ToString();
    }
    

    public void changeColor(string color)
    {
        //установка цвета —≈Ѕя
        if (color == "r")
        {
            GetComponent<Renderer>().material.color = Color.red;
            PlayerPrefs.SetString("myColor", "r");
        }
        if (color == "g")
        {
            GetComponent<Renderer>().material.color = Color.green;
            PlayerPrefs.SetString("myColor", "g");
        }
        if (color == "b")
        {
            GetComponent<Renderer>().material.color = Color.blue;
            PlayerPrefs.SetString("myColor", "b");
        }
        if (color == "p")
        {
            GetComponent<Renderer>().material.color = Color.magenta;
            PlayerPrefs.SetString("myColor", "p");
        }
        if (color == "y")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            PlayerPrefs.SetString("myColor", "y");
        }
        if (color == "bk")
        {
            GetComponent<Renderer>().material.color = Color.black;
            PlayerPrefs.SetString("myColor", "bk");
        }
        if (color == "o")
        {
            GetComponent<Renderer>().material.color = new Color(255,134,0);
            PlayerPrefs.SetString("myColor", "o");
        }
    }

    public void Count(string Case)
    {
        //изменение количества врагов
        if (Case == "+B")
        {
            if(bCount<8)
            bCount++;
            bText.text = bCount.ToString();
        }           
        if (Case == "-B")
        {
            if(bCount>0)
            bCount--;
            bText.text = bCount.ToString();
        }
           

        if (Case == "+R")
        {
            if(rCount<6)
            rCount++;
            rText.text = rCount.ToString();
        }           
        if (Case == "-R")
        {
            if(rCount>0)
            rCount--;
            rText.text = rCount.ToString();
        }           

        if (Case == "+Y")
        {
            if(yCount<30)
            yCount++;
            yText.text = yCount.ToString();
        }
        if (Case == "-Y")
        {
            if(yCount>0)
            yCount--;
            yText.text = yCount.ToString();
        }


        if (Case == "+BK")
        {
            if(bkCount<2)
            bkCount++;
            bkText.text = bkCount.ToString();
        }

        if (Case == "-BK")
        {   if(bkCount>0)
            bkCount--;
            bkText.text = bkCount.ToString();
        }

    }
    
    public void Save()
    {
        PlayerPrefs.SetInt("yCount", yCount);
        PlayerPrefs.SetInt("bCount", bCount);
        PlayerPrefs.SetInt("rCount", rCount);
        PlayerPrefs.SetInt("bkCount", bkCount);
    }
}
