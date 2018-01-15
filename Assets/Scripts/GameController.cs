using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float spawnWait;
    public float spawnLimit;
    public float spawnDelay;
    public float spawnDestroy;

    public int score;
    public int level;

    public Text HealthText;
    public Text scoreText;
    public Text levelText;

    public ShipsInicialization shipsInicialization;
    public SetLocalEulerAngles setLocalEulerAngles;

    public Image panelGameOverPref;
    public Image levelPanelPref;
    public Button buttonNoPref;
    public Button buttonYesPref;

    private bool gameOver;

    // Use this for initialization
    void Start ()
    {
        gameOver = false;
        scoreText.text = "Score: " + score;
        spawnDestroy = spawnLimit;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 1; i < spawnLimit + 1; i++)
        {
            shipsInicialization.MyRandomPositionGenerator();
            yield return new WaitForSeconds(spawnWait);
            spawnWait -= spawnDelay;

            if (gameOver)
            {
                break;
            }
        }

        Updat();

    }

    IEnumerator WaitForSeconds3()
    {
        yield return new WaitForSeconds(5);
    }

    public void SetHealthText(float health)
    {
        HealthText.text = "Planet health: " + health.ToString();
        if (health <= 0)
        {
            gameOver = true;
            GameOver();
        }
        
    }

    public void SetScoreText(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score;
    }

    public void SetLoseText()
    {
        panelGameOverPref.gameObject.SetActive(true);
        buttonNoPref.gameObject.SetActive(true);
        buttonYesPref.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        GameObject[] stopMovement = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in stopMovement)
        {
            enemy.gameObject.GetComponent<SetLocalEulerAngles>().ruszajsie = false;
        }
        SetLoseText();
    }

    public void SetWinGui()
    {
        Debug.Log("InGUI");
        levelText.text = "LEVEL " + (level + 1);
        levelPanelPref.gameObject.SetActive(true);
        NextLevel();
    }

    public void DeActiveWinGui()
    {
        Debug.Log("OutGUI");
        levelText.gameObject.SetActive(false);
        levelPanelPref.gameObject.SetActive(false);
        NextLevel();
    }

        public void NextLevel()
        {
            level++;
        setLocalEulerAngles.SetSpeed(0.5f);
        spawnWait = 3;
        spawnDestroy = spawnLimit;
        Debug.Log("BeforeWait");
        StartCoroutine(WaitForSeconds3());
        //       DeActiveWinGui();

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Updat ()
    {

        if (spawnDestroy == 0)
        {
            Debug.Log("0");
            SetWinGui();
        }

    }
}
