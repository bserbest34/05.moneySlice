using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour
{
	Knife knifeScript;
	public GameObject bladeTrailPrefab;
	public GameObject knifeTrail;
	public float minCuttingVelocity = .001f;
	bool isCutting = false;
	Vector2 previousPosition;
	Rigidbody rb;
	Camera cam;
	CapsuleCollider capsuleCollider;
	int combo;
	public GameObject comboUI;
	public Animator blurAnim;
	internal bool kniferotate;
	internal GameObject knife;
	internal bool setKnife = true;
	void Start()
	{
		knifeScript = FindObjectOfType<Knife>();
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		knife = transform.Find("Knife2").gameObject;
		knife.SetActive(false);
	}

	void FixedUpdate()
	{
		RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, new Vector2(Input.mousePosition.x + 1, Input.mousePosition.y));

		// If it hits something...
		if (hit.transform != null)
		{
			if (hit.transform.name == "Upgrade1" || hit.transform.name == "Upgrade2" || hit.transform.name == "Upgrade3")
				return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
			rb.position = newPosition;
		}
		else if (Input.GetMouseButton(0))
		{
			capsuleCollider.enabled = true;
			StartCutting();
		}
		else
		{
			capsuleCollider.enabled = false;
			StopCutting();
		}
		if (isCutting)
		{
			UpdateCut();
			if (setKnife)
			{
				knife.SetActive(true);
				knifeScript.Rotate();
			}
		}
		else
		{
			if (setKnife)
			{
				knife.SetActive(false);
			}
		}

		StartCoroutine(KnifeTrailSetFalse());
	}
    private void LateUpdate()
    {
		previousPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag(Tags.OneDollar) || other.CompareTag(Tags.TwoDollar) || other.CompareTag(Tags.FiveDollar) || other.CompareTag(Tags.TenDollar)
			|| other.CompareTag(Tags.FiftyDollar) || other.CompareTag(Tags.OneHundredDollar) || other.CompareTag(Tags.TwoHundredDollar) || other.CompareTag(Tags.FiveHundredDollar) || other.CompareTag(Tags.ThousandDollar))
		{
			knifeTrail.SetActive(true);
			combo++;
			StartCoroutine(ComboSifirla());
			if(combo >= 2)
            {
				StartCoroutine(ComboUI());
			}
		}
        if (other.CompareTag("Tax"))
        {
			StartCoroutine(BlueAnim());
        }
        if (other.CompareTag("Bomb"))
        {
			StartCoroutine(BlueAnim());
        }
	}
	IEnumerator KnifeTrailSetFalse()
    {
        if (knifeTrail.activeInHierarchy)
        {
			yield return new WaitForSeconds(1f);
			knifeTrail.SetActive(false);
		}
    }
	IEnumerator ComboSifirla()
    {
		yield return new WaitForSeconds(0.6f);
		combo = 0;
    }
	IEnumerator ComboUI()
	{
		comboUI.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "x" + combo.ToString() + "Combo";
		comboUI.SetActive(true);
		yield return new WaitForSeconds(1f);
		combo = 0;
		comboUI.SetActive(false);
    }

	void UpdateCut()
	{
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (Vector3.Distance(newPosition,previousPosition) >= minCuttingVelocity)
        {
            capsuleCollider.enabled = true;
        }
        else
        {
            capsuleCollider.enabled = false;
        }

    }

	void StartCutting()
	{
		isCutting = true;
		bladeTrailPrefab.gameObject.SetActive(true);
    }

	void StopCutting()
	{
		isCutting = false;
		bladeTrailPrefab.gameObject.SetActive(false);
		capsuleCollider.enabled = false;
		combo = 0;
    }

	IEnumerator BlueAnim()
    {
		blurAnim.SetBool("blur", true);
		yield return new WaitForSeconds(0.5f);
		blurAnim.SetBool("blur", false);
    }
}
