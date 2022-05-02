using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EndGameInteractable : InteractableObject {

    private int hearts = 0;
    [SerializeField] private float heartsRadius = 5f;
    [SerializeField] private Light2D mainLight;
    [SerializeField] private GameObject borderPanel;
    [SerializeField] AudioSource backgroundMusic;
    private List<GameObject> heartObjects;
    private List<bool> doHeartAnim;
    ColorAnimate colAnim;
    new Light2D light;

    private AudioSource crystalAudio;
    [SerializeField] AudioClip heartPop;
    [SerializeField] AudioClip interact;
    [SerializeField] AudioClip whirr;
    [SerializeField] AudioClip condense;
    [SerializeField] AudioClip charge;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip powerDown;
    [SerializeField] AudioClip heartStop;
    [SerializeField] AudioClip GoodEnd;
    [SerializeField] AudioClip BadEnd;
    [SerializeField] private GameObject ammit;
    [SerializeField] private GameObject ammitEye;


    private float currentAngle;
    [SerializeField] private float rotTime = 9;

    private void Awake() {
        colAnim = GetComponent<ColorAnimate>();
        light = GetComponent<Light2D>();
        heartObjects = new List<GameObject>();
        crystalAudio = GetComponent<AudioSource>();
        crystalAudio.loop = false;

        doHeartAnim = new List<bool>();
    }

    public override void Interact(GameObject interactingObject) {
        if(interactingObject.tag == "Player") {
            PlayerController controller = interactingObject.GetComponent<PlayerController>();
            controller.gameObject.GetComponentInChildren<Light2D>().enabled = false;
            FindObjectOfType<PlayerInputController>().enabled = false;

            CameraZoom cz = FindObjectOfType<CameraZoom>();
            cz.StartCoroutine(cz.ZoomTo(25, 10));

            FindObjectOfType<CameraFollow>().SetTarget(gameObject);

            borderPanel.gameObject.SetActive(true);

            crystalAudio.Stop();
            crystalAudio.clip = interact;
            crystalAudio.Play();

            backgroundMusic.Stop();
            if (controller.getMaxHealth() == 9)
                backgroundMusic.clip = GoodEnd;
            else
                backgroundMusic.clip = BadEnd;
            backgroundMusic.Play();

            StartCoroutine(TakeHearts(controller));
        }
    }

    private IEnumerator TakeHearts(PlayerController controller) {
        if(controller.getMaxHealth() > 1 && hearts == 0) {
            colAnim.enabled = true;
        }

        while (mainLight.intensity > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            mainLight.intensity -= .001f;
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

        for (int i = controller.getMaxHealth(); i > 0; --i) {
            yield return new WaitForSeconds(2.5f);
            AddHeart(controller);
        }

        yield return new WaitForSeconds(1f);

        if (hearts == 9) {
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

        crystalAudio.Stop();
        crystalAudio.clip = heartPop;
        crystalAudio.Play();

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
        backgroundMusic.Stop();
        backgroundMusic.clip = GoodEnd;
        backgroundMusic.Play();

        crystalAudio.Stop();
        crystalAudio.loop = true;
        crystalAudio.clip = whirr;
        crystalAudio.volume = 0f;
        crystalAudio.Play();
       
        while (rotTime > 0.1f) {
            yield return new WaitForSeconds(Time.deltaTime);
            rotTime -= .01f;
            rotTime = Mathf.Clamp(rotTime, 0.1f, 1000);
            if (crystalAudio.volume < .6f)
                crystalAudio.volume += 0.0005f;
        }

        

        while (heartsRadius > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            heartsRadius -= .1f;
            heartsRadius = Mathf.Clamp(heartsRadius, 0, 1000);
            colAnim.transitionTime -= .01f;
            colAnim.transitionTime = Mathf.Clamp(colAnim.transitionTime, .01f, Mathf.Infinity);
        }

        //yield return new WaitForSeconds(1);

        /*crystalAudio.Stop();
        crystalAudio.clip = condense;
        crystalAudio.time = 0.4f;
        crystalAudio.Play();*/

        yield return new WaitForSeconds(1f);
        crystalAudio.volume = 1f;
        crystalAudio.loop = false;
        crystalAudio.Stop();
        crystalAudio.clip = charge;
        crystalAudio.Play();

        

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
                heartObjects[i].GetComponent<SpriteRenderer>().color = Color.white;
                heartObjects[i].GetComponent<Light2D>().color = GetComponent<Light2D>().color;
            }
        }

        yield return new WaitForSeconds(2.4f);
        crystalAudio.Stop();
        crystalAudio.clip = explosion;
        crystalAudio.Play();

        while (light.intensity < 200) {
            yield return new WaitForSeconds(Time.deltaTime);
            light.intensity += 1;
        }
    }

    private IEnumerator EndGameBad() {
        crystalAudio.Stop();
        crystalAudio.loop = true;
        crystalAudio.clip = whirr;
        crystalAudio.Play();
        crystalAudio.volume = 0f;

        while (rotTime > 0.1f) {
            yield return new WaitForSeconds(Time.deltaTime);
            rotTime -= .01f;
            rotTime = Mathf.Clamp(rotTime, 0.1f, 1000);
            if (crystalAudio.volume < .6f)
                crystalAudio.volume += 0.0005f;
        }
        
        yield return new WaitForSeconds(3);

        for(int i = 0; i < heartObjects.Count; ++i) {
            yield return new WaitForSeconds(1);

            GameObject obj = heartObjects[i];
            doHeartAnim[i] = false;

            colAnim.transitionTime += 1f;
        }

        crystalAudio.volume = 1f;
        crystalAudio.loop = false;
        crystalAudio.Stop();
        crystalAudio.clip = heartStop;
        crystalAudio.Play();


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
        ammit.SetActive(true);
        bool isAttack = false;
        while(ammit.transform.position.y < 430) {
            yield return new WaitForSeconds(Time.deltaTime);
            if(ammit.transform.position.y > 350 && !isAttack) {
                isAttack = true;
                ammit.GetComponent<Animator>().SetTrigger("Attack");
            }
            ammit.transform.position += new Vector3(0, 0.65f);
        }
        
        //yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < heartObjects.Count; ++i) {
            yield return new WaitForSeconds(.2f);
            StartCoroutine(HeartFall(heartObjects[i]));
        }

        yield return new WaitForSeconds(5.0f);

        while(ammit.transform.GetComponentInChildren<Light2D>().intensity > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            ammit.transform.GetComponentInChildren<Light2D>().intensity -= 0.01f;
            ammitEye.GetComponent<SpriteRenderer>().material.SetFloat("_em",
                ammitEye.GetComponent<SpriteRenderer>().material.GetFloat("_em") - .1f);
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
