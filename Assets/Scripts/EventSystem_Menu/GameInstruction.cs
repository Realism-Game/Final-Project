using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstruction : MonoBehaviour
{
	public static bool viewOn = false;
    public static bool firstTime = true;
	private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (viewOn)
        {
            if (!firstTime)
            {
                disableView();
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
            }
        } else {
            disableView();
        }
    }

    public void closeView() {
        firstTime = false;
    }

    private void disableView()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
        viewOn = false;
    }
}
