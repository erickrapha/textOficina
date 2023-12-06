using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    public EfeitoDigitador caixaDeDialogo;
    public GameObject botaoContinuar;
    public bool rodando, proximo;
    public Image imagePerfil;
    public TextMeshProUGUI nomep;

    void Start()
    {
        Resetar();
    }
    public void PlayDialogo(Dialogo dialogo)
    {
        imagePerfil.sprite = dialogo.perfilPersonagem.sprite;
        nomep.text = dialogo.perfilPersonagem.nome;

        StartCoroutine(ExibirSequencia(dialogo.lista));
    }

    public void Resetar()
    {
        imagePerfil.sprite = null;
        nomep.text = "";
    }
    IEnumerator ExibirSequencia(List<string> lista)
    {
        if (rodando)
        {
            yield break;
        }
        rodando = true;
        proximo = false;
        botaoContinuar.SetActive(false);
        foreach(var mensagem in lista)
        {
            caixaDeDialogo.ImprimirMensagem(mensagem);
            while (caixaDeDialogo.imprimindo)
            {
                yield return new WaitForEndOfFrame();
            }
            botaoContinuar.SetActive(true);
            while (!proximo)
            {
                yield return new WaitForEndOfFrame();
            }
            botaoContinuar.SetActive(false);
            proximo = false;
        }
        caixaDeDialogo.Limpar();
        rodando = false;
        Resetar();
        StopCoroutine(ExibirSequencia(lista));
    }
    void Update()
    {   
               
        if (!caixaDeDialogo.imprimindo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                proximo = true;
            }
        }
    }
}
