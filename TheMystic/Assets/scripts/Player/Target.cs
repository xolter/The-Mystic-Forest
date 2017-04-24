﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public List<Transform> targets;
    public Transform selectedTarget;
    private Transform mytransform;
	// Use this for initialization
	void Start () {
        targets = new List<Transform>();
        selectedTarget = null;
        mytransform = transform;
        AddAllEnemies();
		
	}
    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in go)
        {
            AddTarget(enemy.transform);
        }
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }
    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2) 
        {
            return (Vector3.Distance(t1.position, mytransform.position).CompareTo(Vector3.Distance(t2.position, mytransform.position)));
        });
    }
    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            selectedTarget = targets[0];
        }
        else
        {
            int index = targets.IndexOf(selectedTarget);
            if (index < targets.Count -1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            DeselectTarget();
            selectedTarget = targets[index];
        }
    }
    private void SelectTarget()
    {
        PlayerAttk pa = (PlayerAttk)GetComponent("PlayerAttack");
        pa.target = selectedTarget.gameObject;
    }
    private void DeselectTarget()
    {
        selectedTarget = null;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();

        }
		
	}
}
