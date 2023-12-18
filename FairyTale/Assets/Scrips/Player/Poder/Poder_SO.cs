using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder_SO : ScriptableObject
{
    public string titulo;
    public string descricao;
  [SerializeField]  Sprite indentificadorPoder;
    virtual public void ExecutarPoder()
    {

    }
    virtual public void RemoverEfeitoPoder()
    {

    }
    public Sprite GetIndentificadorPoder()=> indentificadorPoder;
    
}
