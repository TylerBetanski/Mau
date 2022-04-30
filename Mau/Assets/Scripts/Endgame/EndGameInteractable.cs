using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EndGameInteractable : InteractableObject {

    private int hearts = 0;
    [SerializeField] private float heartsRadius = 5f;
    private List<GameObject> heartObjects;
    private List<bool> doHeartAnim;
    ColorAnimate colAnim;
    new Light2D light;

    private float currentAngle;
    [SerializeField] private float rotTime = 9;

    private void Awake() {
        colAnim = GetComponent<ColorAnimate>();
        light = GetComponent<Light2D>();
        heartObjects = new List<GameObject>();

        doHeartAnim = new List<bool>();
    }

    public override void Interact(GameObject interactingObject) {
        if(interactingObject.tag == "Player") {
            PlayerController controller = interactingObject.GetComponent<PlayerController>();
            controller.gameObject.GetComponentInChildren<Light2D>().enabled = false;
            //controller.DisableControls();
            FindObjectOfType<PlayerInputController>().enabled = false;
            CameraZoom cz = FindObjectOfType<CameraZoom>();
            cz.StartCoroutine(cz.ZoomTo(25, 10));
            FindObjectOfType<CameraFollow>().SetTarget(gameObject);
            StartCoroutine(TakeHearts(controller));
        }
    }

    private IEnumerator TakeHearts(PlayerController controller) {
        if(controller.getMaxHealth() > 1 && hearts == 0) {
            colAnim.enabled = true;
        }

        for (int i = controller.getMaxHealth(); i > 0; --i) {
            yield return new WaitForSeconds(2.5f);
            AddHeart(controller);
        }

        if(hearts == 9) {
            StartCoroutine(EndGameGood());
        } else {
            StartCoroutine(EndGameBad());
            //controller.EnableMovement();
            //FindObjectOfType<CameraFollow>().SetTarget(controller.gameObject);
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
        doHeartAnim.Add(true);
    }


    private void Update() {
        currentAngle += (360f / rotTime) * Time.deltaTime;
        currentAngle %= 360f;

        for (int i = 0; i < heartObjects.Count; ++i) {
            if (doHeartAnim[i]) {
                GameObject current = heartObjects[i];
                float thisAngle = currentAngle - ((360 / 9f) * i);

                float xPos = Mathf.Cos(thisAngle * Mathf.Deg2Rad) * heartsRadius;
                float yPos = Mathf.Sin(thisAngle * Mathf.Deg2Rad) * heartsRadius;

                Vector3 newPos = transform.position + new Vector3(xPos, yPos);
                current.transform.position = newPos;
            }
        }
    }
    
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
        List<Color> ogColors;
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

    private IEnumerator EndGameBad() {

        while (rotTime > 0.1f) {
            yield return new WaitForSeconds(Time.deltaTime);
            rotTime -= .01f;
            rotTime = Mathf.Clamp(rotTime, 0.1f, 1000);
        }
        yield return new WaitForSeconds(3);

        for(int i = 0; i < heartObjects.Count; ++i) {
            yield return new WaitForSeconds(1);

            GameObject obj = heartObjects[i];
            doHeartAnim[i] = false;

            colAnim.transitionTime += 1f;
        }

        colAnim.enabled = false;

        float t = 0;
        Color ogCol = GetComponent<SpriteRenderer>().color;
        while(t < 3.0f) {
            yield return new WaitForSeconds(Time.deltaTime);
            t += Time.deltaTime;

            Color newCol = Color.Lerp(ogCol, Color.black, t / 3.0f);

            GetComponent<SpriteRenderer>().color = newCol;
            light.color = newCol;

        }

        yield return new WaitForSeconds(1.5f);

        GameObject L1 = transform.Find("Lights").Find("L1").gameObject;
        L1.GetComponentInChildren<Light2D>().enabled = false;
        foreach (ParticleSystem PS in L1.GetComponentsInChildren<ParticleSystem>()) {
            PS.Stop();
            PS.Clear();
        }

        yield return new WaitForSeconds(0.5f);

        GameObject L2 = transform.Find("Lights").Find("L2").gameObject;
        L2.GetComponentInChildren<Light2D>().enabled = false;
        foreach (ParticleSystem PS in L2.GetComponentsInChildren<ParticleSystem>()) {
            PS.Stop();
            PS.Clear();
        }

        for (int i = 0; i < heartObjects.Count; ++i) {
            yield return new WaitForSeconds(.2f);
            StartCoroutine(HeartFall(heartObjects[i]));
        }
    }

    private IEnumerator HeartFall(GameObject heart) {
        float velocity = 0;

        yield return new WaitForSeconds(1.5f);

        while(velocity > -1000) {
            yield return new WaitForSeconds(Time.deltaTime);
            velocity -= .5f;
            heart.transform.position += new Vector3(0, velocity) * Time.deltaTime;
        }

        Destroy(heart);
    }
}
