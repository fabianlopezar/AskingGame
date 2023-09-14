using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine.UI;

public class ReadTxtFile : MonoBehaviour
{
    public TextAsset _fileQuestions;
    private List<PreguntasMultiples> _listQuestions = new List<PreguntasMultiples>();
    #region text

    public TMP_Text _opc1Text;
    public TMP_Text _opc2Text;
    public TMP_Text _opc3Text;
    public TMP_Text _opc4Text;
    public TMP_Text _questionText;
    #endregion
    [Header("Paneles")]
    public  GameObject _panelGameOver;
    public  GameObject _panelGameWin;
    //public int _indice=0;
    public int _indice;

    private void Start()
    {
        _panelGameOver.SetActive(false);
        _panelGameWin.SetActive(false);    
        FileReading();
        UpdateUIQuestions();
        _indice = Random.Range(0, 22);

    }

    public void FileReading()
    {
        if (_fileQuestions != null)
        {
            //Split the file into lines.
            string[] lines = _fileQuestions.text.Split('\n');
            foreach (string elem in lines)
            {
                string[] parts = elem.Split("-");
                if (parts.Length == 7)// Make sure there are 8 parts (question, options, correct answer, verse, state)
                {

                    string question = parts[0].Trim();
                    string opc1 = parts[1].Trim();
                    string opc2 = parts[2].Trim();
                    string opc3 = parts[3].Trim();
                    string opc4 = parts[4].Trim();
                    string opcCorrect = parts[5].Trim();
                    string verse = parts[6].Trim();
                    bool status = false;

                    // Create an instance of Multiple Questions and add it to the list
                    PreguntasMultiples preguntaMultiple = new PreguntasMultiples(question, opc1, opc2, opc3, opc4, opcCorrect, verse, status);
                    _listQuestions.Add(preguntaMultiple);
                }
            }
        }
    }

    public void UpdateUIQuestions()
    {
        _opc1Text.text = _listQuestions[_indice].Opc1;
        _opc2Text.text = _listQuestions[_indice].Opc2;
        _opc3Text.text = _listQuestions[_indice].Opc3;
        _opc4Text.text = _listQuestions[_indice].Opc4;
        _questionText.text = _listQuestions[_indice].Pregunta;
       
    }
    public void OnButtonClick(TMP_Text pregunta)
    {
        if (pregunta.text == _listQuestions[_indice].OpcCorrecta)
        {
            CorrectResponse();
        }
        else
        {
            IncorrectResponse();
        }
    }
    public void CorrectResponse()
    {
        _panelGameWin.SetActive(true);
    }
    public void IncorrectResponse()
    {
        _panelGameOver.SetActive(true);
    }
   
    public void HidePanelGameOver()
    {
        _panelGameOver.SetActive(false);
    }
    public void NextQuestion()
    {
        _panelGameWin.SetActive(false);
       
        if (_listQuestions[_indice+1] == null)
        {
            _indice = 0;
            NextQuestion();
        }
        else
        {
            _indice++;
            UpdateUIQuestions();
            Debug.Log("SOY el indice:" + _indice);
            Debug.Log("SOY LA RESPUESTA: " + _listQuestions[_indice].OpcCorrecta);
        }
    }
    public void NextQuestionRandom()
    {
        _panelGameWin.SetActive(false);
        _indice = Random.Range(0, 22);
    }
}
