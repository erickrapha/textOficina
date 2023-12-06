using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogo", menuName = "ScriptableObjects/Dialogo", order = 0)]
public class Dialogo : ScriptableObject 
{
    public perfilPersonagem perfilPersonagem;
    public List<string> lista;

}
