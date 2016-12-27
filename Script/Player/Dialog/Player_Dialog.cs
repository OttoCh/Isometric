using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Dialog : MonoBehaviour {


    public GameObject TextBox;
    public GameObject TextBoxPosition;  //ganti ini kalau mau ganti siapa yg ngomong
    public bool appear;
    public bool isTyping;
    public int currentLine;
    public int endLine;
    public string[] TextLines;
    public float typingSpeed;
    public Text theText;
    private bool cancelTyping;
    public GameObject Player;
    private Player_Move PlayerMove;
    //untuk transform -> recttransform
    public GameObject theCanvas;
    public Camera cam;

    public void WorldtoRect()
    {
        RectTransform CanvasRect = theCanvas.GetComponent<RectTransform>();
        RectTransform UI_Element = TextBox.GetComponent<RectTransform>();
        
        Vector2 ViewportPosition = cam.WorldToViewportPoint(TextBoxPosition.transform.position);
        Vector2 TextBoxPosition_ScreenPosition = new Vector2(
            ((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),    //0.5f karena asumsi bahwa canvas kita anchor ada di tengah, ingat rectTransform 0,0 ada di tengah
            ((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f))
        );
        UI_Element.anchoredPosition = TextBoxPosition_ScreenPosition;
    }

    //Fungsi API, untuk membuat sebuah dialog
    public void DialogTrigger(TextAsset GivenText, int startLine, int FinishLine)
    {
        ReloadText(GivenText);
        currentLine = startLine;
        endLine = FinishLine;
        PlayerMove.disable_Move();
        SetActiveText(true);
    }

    public IEnumerator TextScroll(string lineofText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && letter < lineofText.Length-1)
        {
            theText.text += lineofText[letter];
            letter += 1;
            yield return new WaitForSeconds(typingSpeed);
        }
        theText.text = lineofText;
        isTyping = false;
        cancelTyping = false;
    }

    //Kontrol text box dimunculkan atau tidak, panggil ini bila ingin memulai dialog baru!
    void SetActiveText(bool show)
    {
        WorldtoRect();
        //TextBox.transform.position = TextBoxPosition.transform.position;
        TextBox.SetActive(show);
        appear = show;
    }

    void ReloadText(TextAsset newText)
    {
        if(newText != null)
        {
            TextLines = new string[1];
            TextLines = newText.text.Split('\n');
        }
    }
 

	// Use this for initialization
	void Start () {
        PlayerMove = Player.GetComponent<Player_Move>();
        SetActiveText(appear);
        WorldtoRect();
    }
	
	// Update is called once per frame
	void Update () {
        //WorldtoRect();    kalau butuh kalibrasi uncomment ini dan aktifkan textbox di canvas
        if (!appear) return;
    
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!isTyping)
            {
                currentLine += 1;
                if(currentLine >= endLine)
                {
                    SetActiveText(false);
                    PlayerMove.enable_Move();
                }
                else
                {
                    StartCoroutine(TextScroll(TextLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
	}
}
