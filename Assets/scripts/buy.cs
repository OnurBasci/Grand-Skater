using UnityEngine;
using UnityEngine.UI;
public class buy : MonoBehaviour
{
    public GameObject costume, b_costume;
    public GameObject i_kolluk;
    public GameObject kolluk;
    public GameObject teyze;
    public Sprite purple, blue, green, light_blue, orange, red, yellow, wizard, doctor, wizard_arm, soldier, cat, cat2, kask, duz, agent, agent_arm, cat_arm, transparent;
    public GameObject store;
    public GameObject s_button;
    private int spend;
    private Color renk;
    private e_information bilgi;
    private Sprite selected, selected_arm;
    public int item_number = 0;  // oyun baslatildiginda hangi kostumle baslandigini belirtmek icin
    public GameObject Warning;
    private bool bought = false;
    private Color c_kolluk;
    public Animator teyze_an;  //o zaman dans
    public Animator shop_an;
    private float an_start = 0;
    private bool setSoldier = false;
    private void Awake()
    {
        renk = Color.white;
        renk.a = 1f;
        bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        wayPoinText score = GameObject.Find("metre ölçer").GetComponent<wayPoinText>();
        //oyun baslatildiginda save edilmis kostum yerlestirilir
        item_number = PlayerPrefs.GetInt("item_number");
    }
    public void Start()
    {
        if (item_number == -1)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = blue;
            kolluk.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (item_number == 0)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (item_number == 1)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = cat2;
            kolluk.GetComponent<SpriteRenderer>().color = Color.white;
            kolluk.GetComponent<SpriteRenderer>().sprite = cat_arm;
        }
        if (item_number == 2)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = light_blue;
            kolluk.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (item_number == 3)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = orange;
            kolluk.GetComponent<SpriteRenderer>().color = new Color(1, 0.4f, 0);
        }
        if (item_number == 4)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = red;
            kolluk.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (item_number == 5)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = yellow;
            kolluk.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (item_number == 6)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = wizard;
            kolluk.GetComponent<SpriteRenderer>().color = Color.white;
            kolluk.GetComponent<SpriteRenderer>().sprite = wizard_arm;
        }
        if (item_number == 7)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = agent;
            kolluk.GetComponent<SpriteRenderer>().color = Color.white;
            kolluk.GetComponent<SpriteRenderer>().sprite = agent_arm;
        }
        if (item_number == 8)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = doctor;
            kolluk.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (item_number == 9)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = soldier;
            kolluk.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.5f, 0);
            setSoldier = true;
        }
        if (item_number == 10)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = kask;
        }
    }
    public void default_set()
    {
        bought = true;
        costume.GetComponent<Image>().sprite = purple;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = new Color(0.7f, 0 ,1);
        item_number = 0;
        selected = null;
        c_kolluk =  new Color(0.7f, 0, 1);
        spend = 0;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
    }
    public void blue_set()
    {
        costume.GetComponent<Image>().sprite = blue;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = Color.blue;
        selected = blue;
        c_kolluk = Color.blue;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[1] == false && bilgi.parasayisi >= 20 && !bought) {
            bought = true;
            spend = 20;
            bilgi.costumes[1] = true;
            item_number = -1;
        }
        else if (bilgi.costumes[1])
        {
            bought = true;
            item_number = -1;
        }
        else if (bilgi.parasayisi < 20)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void cat_set()
    {
        b_costume.GetComponent<Image>().sprite = cat;
        i_kolluk.GetComponent<Image>().sprite = cat_arm;
        selected = cat2;
        i_kolluk.GetComponent<Image>().color = Color.white;
        c_kolluk = Color.white;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[0] == false && bilgi.parasayisi >= 200 && !bought)
        {
            bought = true;
            spend = 200;
            bilgi.costumes[0] = true;
            item_number = 1;
        }
        else if (bilgi.costumes[0])
        {
            bought = true;
            item_number = 1;
        }
        else if (bilgi.parasayisi < 200)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void lblue_set()
    {
        costume.GetComponent<Image>().sprite = light_blue;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = Color.cyan;
        selected = light_blue;
        c_kolluk = Color.cyan;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[2] == false && bilgi.parasayisi >= 20)
        {
            bought = true;
            spend = 20;
            bilgi.costumes[2] = true;
            item_number = 2;
        }
        else if (bilgi.costumes[2])
        {
            bought = true;
            item_number = 2;
        }
        else if (bilgi.parasayisi < 20)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void orange_set()
    {
        costume.GetComponent<Image>().sprite = orange;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = new Color(1, 0.4f, 0);
        selected = orange;
        c_kolluk = new Color(1, 0.4f, 0);
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[3] == false && bilgi.parasayisi >= 20)
        {
            bought = true;
            spend = 20;
            bilgi.costumes[3] = true;
            item_number = 3;
        }
        else if (bilgi.costumes[3])
        {
            bought = true;
            item_number = 3;
        }
        else if (bilgi.parasayisi < 20)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void red_set()
    {
        costume.GetComponent<Image>().sprite = red;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = Color.red;
        selected = red;
        c_kolluk = Color.red;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[4] == false && bilgi.parasayisi >= 20)
        {
            bought = true;
            spend = 20;
            bilgi.costumes[4] = true;
            item_number = 4;
        }
        else if (bilgi.costumes[4])
        {
            bought = true;
            item_number = 4;
        }
        else if (bilgi.parasayisi < 20)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void yellow_set()
    {
        costume.GetComponent<Image>().sprite = yellow;
        b_costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = Color.yellow;
        selected = yellow;
        c_kolluk = Color.yellow;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[5] == false && bilgi.parasayisi >= 20)
        {
            bought = true;
            spend = 20;
            bilgi.costumes[5] = true;
            item_number = 5;
        }
        else if (bilgi.costumes[5])
        {
            bought = true;
            item_number = 5;
        }
        else if (bilgi.parasayisi < 20)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void Wizard()
    {
        b_costume.GetComponent<Image>().sprite = wizard;
        i_kolluk.GetComponent<Image>().sprite = wizard_arm;
        selected = wizard;
        i_kolluk.GetComponent<Image>().color = Color.white;
        c_kolluk = Color.white;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[6] == false && bilgi.parasayisi >= 100)
        {
            bought = true;
            spend = 100;
            bilgi.costumes[6] = true;
            item_number = 6;
        }
        else if (bilgi.costumes[6])
        {
            bought = true;
            item_number = 6;
        }
        else if (bilgi.parasayisi < 100)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void agent_set()
    {
        b_costume.GetComponent<Image>().sprite = agent;
        i_kolluk.GetComponent<Image>().sprite = agent_arm;
        selected = agent;
        i_kolluk.GetComponent<Image>().color = Color.white;
        c_kolluk = Color.white;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[7] == false && bilgi.parasayisi >= 100)
        {
            bought = true;
            spend = 100;
            bilgi.costumes[7] = true;
            item_number = 7;
        }
        else if (bilgi.costumes[7])
        {
            bought = true;
            item_number = 7;
        }
        else if (bilgi.parasayisi < 100)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void doctor_set()
    {
        b_costume.GetComponent<Image>().sprite = doctor;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = Color.white;
        selected = doctor;
        c_kolluk = Color.white;
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[8] == false && bilgi.parasayisi >= 50)
        {
            bought = true;
            spend = 50;
            bilgi.costumes[8] = true;
            item_number = 8;
        }
        else if (bilgi.costumes[8])
        {
            bought = true;
            item_number = 8;
        }
        else if (bilgi.parasayisi < 50)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void soldier_set()
    {
        b_costume.GetComponent<Image>().sprite = soldier;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = new Color(0.1f, 0.5f, 0);
        selected = soldier;
        c_kolluk = new Color(0.1f, 0.5f, 0);
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[9] == false && bilgi.parasayisi >= 100)
        {
            bought = true;
            spend = 100;
            bilgi.costumes[9] = true;
            item_number = 9;
        }
        else if (bilgi.costumes[9])
        {
            bought = true;
            item_number = 9;
        }
        else if (bilgi.parasayisi < 100)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void kask_set()
    {
        b_costume.GetComponent<Image>().sprite = kask;
        costume.GetComponent<Image>().sprite = transparent;
        i_kolluk.GetComponent<Image>().sprite = duz;
        i_kolluk.GetComponent<Image>().color = new Color(0.7f, 0, 1);
        selected = kask;
        c_kolluk = new Color(0.7f, 0, 1);
        teyze_an.SetBool("dance", true);
        dance.dancing = true;
        if (bilgi.costumes[10] == false && bilgi.parasayisi >= 50)
        {
            bought = true;
            spend = 50;
            bilgi.costumes[10] = true;
            item_number = 10;
        }
        else if (bilgi.costumes[10])
        {
            bought = true;
            item_number = 10;
        }
        else if (bilgi.parasayisi < 50)
        {
            bought = false;
            spend = 0;
            Instantiate(Warning, new Vector2(0, 0), Quaternion.identity, this.transform);
        }
    }
    public void apply()
    {
        bilgi.parasayisi -= spend;
        if (bought)
        {
            teyze.GetComponent<SpriteRenderer>().sprite = selected;
            kolluk.GetComponent<SpriteRenderer>().sprite = selected_arm;
            kolluk.GetComponent<SpriteRenderer>().color = c_kolluk;
        }
        PlayerPrefs.SetInt("item_number", item_number);
        wayPoinText score = GameObject.Find("metre ölçer").GetComponent<wayPoinText>();
        SaveSystem.SavePlayer(bilgi, score);
        if (kaydir.solda)
        {
            shop_an.SetBool("s_kaydi", false);
            shop_an.SetBool("sa_kay", true);
            open_shop.clicked = true;
        }
        else 
        {
            if (!dance.dancing) 
            {
                store.SetActive(false);
                s_button.SetActive(true);
            }
        }
        if(item_number == 9)
        {
            FindObjectOfType<AudioManager>().Stop("music"); //asker kostumu giyildiginde muzik degisir
            FindObjectOfType<AudioManager>().Play("music2");
            setSoldier = true;
        }
        else if(setSoldier)
        {
            FindObjectOfType<AudioManager>().Stop("music2");
            FindObjectOfType<AudioManager>().Play("music");
            setSoldier = false;
        }
    }
    public void Update()
    {
        if(bilgi.parasayisi < 0)
        {
            bilgi.parasayisi = 0;
        }
        if (item_number < 6 && item_number != 1)
        {
            selected_arm = duz;
        }
        else if(item_number == 1)
        {
            selected_arm = cat_arm;
        }
        else if(item_number == 6)
        {
            selected_arm = wizard_arm;
        }
        else if (item_number == 7)
        {
            selected_arm = agent_arm;
        }
        else if (item_number == 8)
        {
            selected_arm = duz;
        }
        else if(item_number == 9)
        {
            selected_arm = duz;
        }
        else if(item_number == 10)
        {
            selected_arm = duz;
        }
    }
}
