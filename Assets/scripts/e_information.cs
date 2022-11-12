using UnityEngine;
using UnityEngine.UI;
public class e_information : MonoBehaviour
{
    public int parasayisi = 0;
    public int sopaCount = 5;
    public Text para;
    public bool[] costumes;

    public void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        parasayisi = data.altin;
        sopaCount = data.sopa;
        // for indicate that which item is bought 
        costumes[0] = data.Costumes[0];
        costumes[1] = data.Costumes[1];
        costumes[2] = data.Costumes[2];
        costumes[3] = data.Costumes[3];
        costumes[4] = data.Costumes[4];
        costumes[5] = data.Costumes[5];
        costumes[6] = data.Costumes[6];
        costumes[7] = data.Costumes[7];
        costumes[8] = data.Costumes[8];
        costumes[9] = data.Costumes[9];
        costumes[10] = data.Costumes[10];
    }
    public void save()
    {
        DontDestroyOnLoad(this);
    }
    public void Update()
    {
        para.text = parasayisi.ToString();
    }
}
