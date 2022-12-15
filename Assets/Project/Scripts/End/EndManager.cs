using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndManager : MonoBehaviour
{
    public ManagerManager mM;

    public TextMeshProUGUI garbagesScoreTotal;
    public TextMeshProUGUI bossScoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        mM = FindObjectOfType<ManagerManager>();

        garbagesScoreTotal.text = mM.recoltedGarbages.ToString();
        bossScoreTotal.text = mM.nbrBossKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ReDo()
    {
        SceneManager.LoadScene("PlayingScene");
    }
}
