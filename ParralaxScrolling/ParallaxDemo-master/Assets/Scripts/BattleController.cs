using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Controller for battle scenes
public class BattleController : MonoBehaviour {
    //Singleton battle manager
    private static BattleController shared;

    //Battle UI
    public Text turnText;

    //GameObjects
    public GameObject player;

    //Delta time values for gameobjects
    public float playerDeltaTarget = 0;
    public float playerDelta = 0;
    public float enemyDelta;
    public float pauseSmoothTime = 0.5f;
    public float timer = 1;
    public float turnTime = 1;

    //Is Time Paused
    private bool isPause = false;

    void Awake() {
        //Make sure only one battle manager exists at a time
        if(shared == null) {
            shared = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if(isPause) {
            //Stop animations and player movement
            turnText.text = "Player Turn";
            player.GetComponent<Animator>().speed = 0;
            Mathf.SmoothDamp(playerDelta, playerDeltaTarget, ref playerDelta, pauseSmoothTime);

        } else {
            //Start animations and player movement
            playerDelta = Time.deltaTime;
            turnText.text = timer.ToString("F2");
            player.GetComponent<Animator>().speed = 1;

            //Run timer until 2 seconds have passed, then pause again
            Countdown();
        }
    }

    public static BattleController Shared() {
        return shared;
    }

    public bool IsPaused() {
        return isPause;
    }

    public void SwitchPause() {
        isPause = !isPause;
    }

    public void Countdown() {
        if(timer > 0) {
            timer -= Time.deltaTime;
        } else {
            isPause = true;
            timer = turnTime;
        }
    }
}
