using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Models;
public class ReadTxtFile : MonoBehaviour
{
    public TextAsset _fileQuestions;
    private List<PreguntasMultiples> _listQuestions = new List<PreguntasMultiples>();
    private void Start()
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
            foreach (PreguntasMultiples elem in _listQuestions) 
            {
                Debug.Log("Pregunta: "+ elem.Pregunta);
                Debug.Log("Opcion Correcta: "+elem.OpcCorrecta);
            }
            
        }
        Debug.Log("SOY LA LISTA DE PREGUNTAS" + _listQuestions);
    }
}
