using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EndGameInteractable : InteractableObject {

    private int hearts = 0;
    [SerializeField] private float heartsRadius = 5f;
    private List<GameObject> heartObjects;
    ColorAnimate colAnim;
    new Light2D light;

    private float currentAngle;
    [SerializeField] private float rotTime = 9;

    private void Awake() {
        colAnim = GetComponent<ColorAnimate>();
        light = GetComponent<Light2D>();
        heartObjects = new List<GameObject>();
    }

    public override void Interact(GameObject interactingObject) {
        if(interactingObject.tag == "Player") {
            PlayerController controller = interactingObject.GetComponent<PlayerController>();
            controller.DisableMovement();
            FindObjectOfType<CameraFollow>().SetTarget(gameObject);
            StartCoroutine(TakeHearts(controller));
        }
    }

    private IEnumerator TakeHearts(PlayerController controller) {
        if(controller.getMaxHealth() > 1 && hearts == 0) {
            colAnim.enabled = true;
        }

        for (int i = controller.getMaxHealth(); i > 1; --i) {
            yield return new WaitForSeconds(2.5f);
            AddHeart(controller);
        }
        if(hearts == 8) {
            yield return new WaitForSeconds(2.5f);
            AddHeart(controller);
        }

        if(hearts == 9) {
            StartCoroutine(EndGameGood());
        } else {
            controller.EnableMovement();
            FindObjectOfType<CameraFollow>().SetTarget(controller.gameObject);
        }
    }

    private void AddHeart(PlayerController controller) {
        controller.decreaseMaxHealth();
        hearts++;
        colAnim.transitionTime -= .5f;
        light.intensity += (2f / 9f);

        GameObject newHeart = Instantiate(transform.Find("Heart").gameObject);
        newHeart.transform.SetParent(transform);
        newHeart.SetActive(true);
        newHeart.GetComponent<Light2D>().enabled = true;
        heartObjects.Add(newHeart);
    }


    private void Update() {
        currentAngle += (360f / rotTime) * Time.deltaTime;
        currentAngle %= 360f;

        for(int i = 0; i < heartObjects.Count; ++i) {
            GameObject current = heartObjects[i];
            float thisAngle = currentAngle - ((360 / 9f) * i);

            float xPos = Mathf.Cos(thisAngle * Mathf.Deg2Rad) * heartsRadius;
            float yPos = Mathf.Sin(thisAngle * Mathf.Deg2Rad) * heartsRadius;

            Vector3 newPos = transform.position + new Vector3(xPos, yPos);
            current.transform.position = newPos;
        }
    }
    List<Color> ogColors;
    private IEnumerator EndGameGood() {
        //yield return new WaitForSeconds(5);

        while(rotTime > 0.1f) {
            yield return new WaitForSeconds(Time.deltaTime);
            rotTime -= .01f;
            rotTime = Mathf.Clamp(rotTime, 0.1f, 1000);
        }

        while(heartsRadius > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            heartsRadius -= .1f;
            heartsRadius = Mathf.Clamp(heartsRadius, 0, 1000);
            colAnim.transitionTime -= .01f;
            colAnim.transitionTime = Mathf.Clamp(colAnim.transitionTime, .01f, Mathf.Infinity);
        }
        ogColors = new List<Color>();

        for (int i = 0; i < colAnim.targetColors.Count; ++i) {
            ogColors.Add(colAnim.targetColors[i]);
        }

        float satVal = 0;
        while(satVal < 1) {
            yield return new WaitForSeconds(Time.deltaTime);
            satVal += .005f;
            for (int i = 0; i < colAnim.targetColors.Count; ++i) {
                colAnim.targetColors[i] = Color.Lerp(ogColors[i], Color.white, satVal);
            }
            for(int i = 0; i < heartObjects.Count; ++i) {
                heartObjects[i].GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                heartObjects[i].GetComponent<Light2D>().color = GetComponent<Light2D>().color;
            }
        }

        while(light.intensity < 200) {
            yield return new WaitForSeconds(Time.deltaTime);
            light.intensity += 1;
        }
    }
}
