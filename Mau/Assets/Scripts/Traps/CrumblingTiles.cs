using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingTiles : MonoBehaviour
{
    [SerializeField] float crumbleTime;
    [SerializeField] float RespawnTime;
    [SerializeField] Sprite[] crumblingSprites;
    private GameObject[] crumblingTiles;

    private bool isCrumbling;
    private bool isRespawning;
    private WaitForSeconds crumbleWait;
    private WaitForSeconds RespawnWait;
    private void Awake()
    {
        crumblingTiles = new GameObject[transform.childCount];
        for (int i = 0; i < crumblingTiles.Length; i++) {
            crumblingTiles[i] = transform.GetChild(i).gameObject;
        }
        crumbleWait = new WaitForSeconds(crumbleTime);
        RespawnWait = new WaitForSeconds(RespawnTime);
        isCrumbling = false;
        isRespawning = false;
    }

    private IEnumerator CrumbleTiles() {
        if (!isRespawning && !isCrumbling)
        {
            isCrumbling = true;
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().Play();
            for (int i = 0; i < crumblingSprites.Length; i++)
            {
                yield return crumbleWait;
                for (int j = 0; j < crumblingTiles.Length; j++)
                {
                    crumblingTiles[j].GetComponent<SpriteRenderer>().sprite = crumblingSprites[i];
                }
            }
            GetComponent<Collider2D>().enabled = false;
            for (int j = 0; j < crumblingTiles.Length; j++)
            {
                crumblingTiles[j].GetComponent<SpriteRenderer>().enabled = false;
            }

            isCrumbling = false;
            yield return RespawnWait;
            StartCoroutine(RebuildTiles());
        }
    }

    private IEnumerator RebuildTiles()
    {
        if (!isCrumbling && !isRespawning)
        {
            isRespawning = true;
            GetComponent<Collider2D>().enabled = true;
            for (int j = 0; j < crumblingTiles.Length; j++)
            {
                crumblingTiles[j].GetComponent<SpriteRenderer>().enabled = true;
            }
            for (int i = crumblingSprites.Length - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(crumbleTime / 2f);
                for (int j = 0; j < crumblingTiles.Length; j++)
                {
                    crumblingTiles[j].GetComponent<SpriteRenderer>().sprite = crumblingSprites[i];
                }
            }
            isRespawning = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        if (!isCrumbling)
            StartCoroutine(CrumbleTiles());
    }

}
