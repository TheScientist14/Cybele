using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ActionBehaviour))]
public class CardBehaviour : MonoBehaviour
{
    public GameObject confirmationGUITemplate;
    public AudioClip cardSound;

    private ActionBehaviour cardAction;
    private Vector3 standardScale;
    private GameObject confirmationGUI;
    private Image image;
    private Button button;

    void Awake()
    {
        cardAction = gameObject.GetComponent<ActionBehaviour>();
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSelection.instance.AddListener(HighlightIfSelected);
        standardScale = transform.localScale;
        confirmationGUI = Instantiate(confirmationGUITemplate, transform);
        confirmationGUI.SetActive(false);
    }

    void Update()
    {
    }

    public void Click()
    {
        CardSelection.instance.SelectAction(cardAction);
    }

    public void HighlightIfSelected()
    {
        if(CardSelection.instance.GetSelectedAction() == cardAction)
        {
            transform.localScale = standardScale*1.5f;
            confirmationGUI.SetActive(true);
        }
        else
        {
            transform.localScale = standardScale;
            confirmationGUI.SetActive(false);
        }
    }

    public void Hide()
    {
        image.enabled = false;
        button.enabled = false;
    }

    public void Show()
    {
        image.enabled = true;
        button.enabled = true;
    }

    public void PlaySound()
    {
        //cardSound;
    }
}
