using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button;



    private float lastCritterSpawn = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //check if critter needs to be spawned
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;

        if (Time.time >= nextSpawnTime && timer.IsTimerRunning() == true)
        {
            //choose random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //spawn critter
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //get access to critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            //tell critter script score object and timer object
            critterScript.scoreDisplay = scoreDisplay;
            critterScript.timer = timer;

            //update most recent critter spawn time to now
            lastCritterSpawn = Time.time;
        }

        //update button visiblity
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
        }
	}

    private void OnMouseDown()
    {
        //only respond if timer is not running
        if (timer.IsTimerRunning() == false)
        {
            //start new game
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }
}
