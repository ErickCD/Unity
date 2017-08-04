using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class arrangeActions : MonoBehaviour {

    private RectTransform panelRectTransform;

	//Initializacion of a RectTransform
	void Start () {
        panelRectTransform = GetComponent<RectTransform>();
	}

    public void MoveDownOne() {
        print("(Before change)" + gameObject.name + "sibiling index = " + panelRectTransform.GetSiblingIndex());

        int concurrentSlibingIndex = panelRectTransform.GetSiblingIndex();
        panelRectTransform.SetSiblingIndex(concurrentSlibingIndex - 1);

        print("(after changes)" + gameObject.name + " Slibing index = " + panelRectTransform.GetSiblingIndex());
    }

    public void MoveUpOne() {
        print("(Before change)" + gameObject.name + ", Slibin indix = " + panelRectTransform.GetSiblingIndex());

        int concurrentSlibingindex = panelRectTransform.GetSiblingIndex();
        panelRectTransform.SetSiblingIndex(concurrentSlibingindex + 1);

        print("(After change)" + gameObject.name + ", Slibing index = "+ panelRectTransform.GetSiblingIndex());
    }
}
