using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //recuperer l'objet qui vient d'entrer en collision avec le porteur du script
        GameObject collisioningObject = collision.gameObject;
        //afficher le nom de l'objet qui vient d'entrer en collision dans la console
        Debug.Log(collisioningObject.name);
        //faire en sorte que si le nom de l'objet contient Neige
        if (collisioningObject.name.Contains("Neige")) 
        {
            //il soit déplacé d'une valeur aléatoire entre 5 et 10 unités en y
            collisioningObject.transform.position += new Vector3(0f, Random.Range(5f, 10f), 0f);
            //et que sa couleur change
            collisioningObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //collisioningObject.GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256));
        }

    }

}
