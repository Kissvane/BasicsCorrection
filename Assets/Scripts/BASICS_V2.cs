using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BASICS_V2 : MonoBehaviour
{
    //initialisation de listes
    public List<int> liste1 = new List<int>();
    public List<int> liste4;
    public List<int> liste2;
    public List<int> liste3;
    
    //initialisation de tableaux
    public int[] tableau1 = new int[3];
    public int[] tableau2;

    public int testCounter;
    public int whileTestLimit = 1;
    public float waitTime = 5f;

    public GameObject NeigePfb;
    public Transform NeigeContainer;
    public int NumberToCreate;

    //les listes sont plus faciles à manipuler mais moins rapides
    //on peut facilement changer le nombre d'éléments qu'il y a dans une liste
    public void ListManipulation()
    {
        //initialisation de liste2 et liste3
        liste2 = new List<int> { 0, 1, 2, 5, 8 };
        ForLoopExample(liste3);

        //ajouter 6 et 3 dans liste1 (Add) 
        liste1.Add(6);
        liste1.Add(3);
        //retirer 1 de liste2 (Remove)
        liste2.Remove(1);
        //retirer le 2e élément de liste2 (RemoveAt)
        liste2.RemoveAt(1);
        //ajouter liste2 dans liste1 (Addrange)
        liste1.AddRange(liste2);
        //ajouter 2 fois liste3 dans liste4  (Addrange)
        liste4.AddRange(liste3);
        liste4.AddRange(liste3);
        //enlever les 3e, 4e et 5e éléments de liste1 (RemoveRange) 
        liste1.RemoveRange(2,3);
        //afficher tous les éléments de liste1 dans la console
        foreach (int i in liste1)
        {
            print(i);
        }
        //remplacer tous les élements de liste1 par des -1
        for (int i = 0; i < liste1.Count; i++)
        {
            liste1[i] = -1;
        }
        //vider la liste 3
        liste3.Clear();
        //afficher le nombre d'éléments de toutes les listes (Count)
        Debug.Log("Liste1 "+ liste1.Count);
        Debug.Log("Liste2 " + liste2.Count);
        Debug.Log("Liste3 " + liste3.Count);
        Debug.Log("Liste4 " + liste4.Count);
    }

    void ForLoopExample(List<int> toFill)
    {
        //remplir la liste avec les chiffres de 0 à 9
        for (int i = 0; i < 10; i++)
        {
            toFill.Add(i);
        }
    }

    void WhileExemple()
    {
        testCounter = 1;
        int i = 0;
        while (i < whileTestLimit)
        {
            testCounter *= 2;
            Debug.Log("TEST COUNTER "+testCounter);
            //si on oublie cette ligne la boucle devient infinie
            i++;
        }
    }

    //les tableaux sont plus difficile à manipuler mais plus rapide
    //pour le moment on ne les utilise que quand on connait le nombre d'éléments à manipuler
    public void TableauManipulation()
    {
        //initialisation tableau1 et tableau2
        tableau1 = new int[3];
        tableau2 = new int[] { 5, 9, 6 };

        //lire la valeur des 2e éléments de tableau1 et tableau2
        print(tableau1[1]);
        print(tableau2[1]);
        //remplacer la valeur du 1er élément de tableau1 par 9000
        tableau1[0] = 9000;
    }

    // Start is called before the first frame update
    void Start()
    {
        ListManipulation();
        TableauManipulation();
        WhileExemple();
        //pour appeler une coroutine il faut utiliser la méthode StartCoroutine
        StartCoroutine(MyCoroutineExample());
        //faire et lancer une coroutine s'appelant MyCoroutine qui compte jusqu'à 15 et affiche chaque chiffre dans la console 
        //en attendant 2 secondes entre chaque chiffre
        StartCoroutine(MyCoroutine());

        //Modifier le script CollisionExample comme l'indique les consignes à l'intérieur

        //exemple de création d'un objet à partir de NeigePfb en position (0,0,0) et rotation (0,0,0)
        GameObject createdObject = Instantiate(NeigePfb, Vector3.zero, Quaternion.identity);
        //parenter l'objet créer à l'objet portant ce script
        createdObject.transform.parent = NeigeContainer;

        //dans une boucle, créer NumberToCreate autres objets à partir de NeigePfb
        for (int i = 0; i < NumberToCreate; i++)
        {
            Instantiate(NeigePfb, new Vector3(Random.Range(-5f,5f), Random.Range(5f, 10f), Random.Range(-5f, 5f)), Quaternion.identity, NeigeContainer);
        }
        //créer et lancer une coroutine qui détruit un objet contenant neige dans son nom toute les 5 secondes
        StartCoroutine(SnowDestroyer());
    }

    //une coroutine est toujours de type IEnumerator
    IEnumerator MyCoroutineExample()
    {
        Debug.Log("START WAITING "+Time.time);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("END WAITING " + Time.time);
    }

    IEnumerator MyCoroutine()
    {
        for (int i = 0; i < 16; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SnowDestroyer()
    {
        /*GameObject[] snowflakes = GameObject.FindGameObjectsWithTag("Special");
        List<GameObject> snowflakesList = snowflakes.ToList();

        while (snowflakesList.Count > 0)
        {
            Destroy(snowflakesList[0]);
            snowflakesList.RemoveAt(0);
            yield return new WaitForSeconds(1f);
        }*/

        while (NeigeContainer.childCount > 0)
        {
            Destroy(NeigeContainer.GetChild(0).gameObject);
            yield return new WaitForSeconds(1f);
        }
    }


}
