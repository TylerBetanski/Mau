using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LockableTiles : LockableObject
{
    [SerializeField] Tilemap backGround;
    [SerializeField] Tilemap ground;
    [SerializeField] float openTime = 1;
    private Color tilesColor = Color.white;
    private WaitForSeconds delay;

    private void Awake()
    {
        delay = new WaitForSeconds(Time.fixedDeltaTime);
        if (Locked)
        {

            tilesColor = backGround.color;
            lockChildren();
        }
        else { 
            tilesColor = ground.color;
            unlockChildern();
        }  
    }
    protected override void Unlock()
    {
        StartCoroutine(unlockChildrenAnimation());
    }

    protected override void Lock()
    {
        StartCoroutine(lockChildrenAnimation());
    }

    private void lockChildren()
    {

        tilesColor = backGround.color;
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            go.GetComponent<SpriteRenderer>().color = tilesColor;
            go.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
    private void unlockChildern() {

            tilesColor = ground.color;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                go.GetComponent<SpriteRenderer>().color = tilesColor;
                go.GetComponent<BoxCollider2D>().enabled = true;
            }
    }

    private IEnumerator unlockChildrenAnimation() {
        float currentTime = 0;
        while (currentTime < openTime) {
            yield return delay;
            currentTime+= Time.fixedDeltaTime;
            tilesColor = Color.Lerp(backGround.color, ground.color, currentTime / openTime);
            ColorChildren();
        }
        setColliders(true);
    }

    private IEnumerator lockChildrenAnimation()
    {
        float currentTime = 0;
        while (currentTime < openTime)
        {
            yield return delay;
            currentTime += Time.fixedDeltaTime;
            tilesColor = Color.Lerp(ground.color, backGround.color, currentTime / openTime);
            ColorChildren();
        }
        setColliders(false);
    }

    private void ColorChildren() {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            go.GetComponent<SpriteRenderer>().color = tilesColor;
        }

    }

    private void setColliders(bool enabled) {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            go.GetComponent<BoxCollider2D>().enabled = enabled;
        }
    }
}
