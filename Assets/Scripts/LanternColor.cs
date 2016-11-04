using UnityEngine;
using System.Collections;

public class LanternColor : MonoBehaviour {
    public Color normalColor;
    public Color warningColor;

    private int ghostCount = 0;

    private Light light;
    private Material material;

    private SphereCollider sphere;
    private Gradient g;

	// Use this for initialization
	void Start () {
        sphere = gameObject.GetComponent<SphereCollider>();
        light = transform.Find("FirstPersonCharacter/Hand/Lantern/Light").GetComponent<Light>();
        material = transform.Find("FirstPersonCharacter/Hand/Lantern/LanternModel").GetComponent<MeshRenderer>().material;
        material.EnableKeyword("_EMISSION");

        GradientColorKey[] gck;
        GradientAlphaKey[] gak;
        g = new Gradient();
        gck = new GradientColorKey[3];
        gck[0].color = warningColor;
        gck[0].time = 0.0F;
        gck[1].color = warningColor;
        gck[1].time = 0.7F;
        gck[2].color = normalColor;
        gck[2].time = 1.0F;
        gak = new GradientAlphaKey[3];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 1.0F;
        gak[1].time = 0.7F;
        gak[2].alpha = 1.0F;
        gak[2].time = 1.0F;
        g.SetKeys(gck, gak);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            ghostCount++;

            float maxDist = sphere.radius;
            float dist = (other.transform.position - transform.position).magnitude;

            float amount = dist / maxDist;

            material.SetColor("_EmissionColor", g.Evaluate(amount));
            light.color = g.Evaluate(amount);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            float maxDist = sphere.radius;
            float dist = (other.transform.position - transform.position).magnitude;

            float amount = dist / maxDist;

            material.SetColor("_EmissionColor", g.Evaluate(amount));
            light.color = g.Evaluate(amount);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            ghostCount--;
            if (ghostCount <= 0)
            {
                material.SetColor("_EmissionColor", normalColor);
                light.color = normalColor;
            }
        }
    }
}
