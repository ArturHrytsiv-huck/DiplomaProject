using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public Canvas pointUI;
    private void Awake()
    {
        pointUI = Instantiate(pointUI, transform.position, pointUI.transform.rotation);
        pointUI.gameObject.SetActive(false);
        
    }
    private void Start()
    {
        Vector3 posUI = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        pointUI.transform.position = posUI;
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 posUI = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        pointUI.transform.position = posUI;
        pointUI.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        pointUI.gameObject.SetActive(false);
    }
}
