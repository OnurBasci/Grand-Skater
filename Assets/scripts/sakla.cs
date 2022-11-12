using UnityEngine;
using UnityEngine.SceneManagement;
public class sakla : MonoBehaviour
{
   public void sopa_ekle()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            TutorialScript.tutorialIndex = 0;
        }
        else
        {
            e_information degerler = GameObject.Find("gameManager").GetComponent<e_information>();
            wayPoinText score = GameObject.Find("metre ölçer").GetComponent<wayPoinText>();
            if (degerler.sopaCount < 2)
            {
                degerler.sopaCount = 2;
            }
            SaveSystem.SavePlayer(degerler, score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
