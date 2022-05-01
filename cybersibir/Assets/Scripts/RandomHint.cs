using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomHint : MonoBehaviour
{
    public List<string> hints;
    public Text hintText;
    private void Start()
    {
        hintText.text = hints[Random.Range(0, hints.Count)];
    }
}
