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

    protected override void ChildAwake() {
        delay = new WaitForSeconds(Time.fixedDeltaTime);
        if (Locked) {
            tilesColor = backGround.color;
            lockChildren();
        } else {
            tilesColor = ground.color;
            unlockChildren();
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
            go.GetComponent<Collider2D>().enabled = false;
            go.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            go.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    private void unlockChildren() {

            tilesColor = ground.color;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                go.GetComponent<SpriteRenderer>().color = tilesColor;
                go.GetComponent<Collider2D>().enabled = true;
            go.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
            
    }

    private IEnumerator unlockChildrenAnimation() {
        float currentTime = 0;
        setColliders(true);
        while (currentTime < openTime) {
            yield return delay;
            currentTime+= Time.fixedDeltaTime;
            tilesColor = Color.Lerp(backGround.color, ground.color, currentTime / openTime);
            ColorChildren();
        }
    }

    private IEnumerator lockChildrenAnimation()
    {
        setColliders(false);
        float currentTime = 0;
        while (currentTime < openTime)
        {
            yield return delay;
            currentTime += Time.fixedDeltaTime;
            tilesColor = Color.Lerp(ground.color, backGround.color, currentTime / openTime);
            ColorChildren();
        }
        
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
            go.GetComponent<Collider2D>().enabled = enabled;

            if (enabled)
                go.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            else
            {
                go.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
                go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
    }
}
