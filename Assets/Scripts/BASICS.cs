using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASICS : MonoBehaviour
{
    public GameObject Cylinder;
    public GameObject Cube;
    public GameObject Sphere;
    public Transform SphereTransform;
    public TextMesh TEXT;

    // Start is called before the first frame update
    void Awake()
    {
        //EXERCICE 1 : Récupérer des GameObjects et des composants dans un script

        // find a GameObject by name
        Cylinder = GameObject.Find("CylinderShape");

        // find a GameObject by tag
        Cube = GameObject.FindGameObjectWithTag("Special");
        // Attribute a GameObject with unity inspector
        // Do this for Sphere
        // DONE

        // get the Transform of the sphere 
        SphereTransform = Sphere.GetComponent<Transform>(); //or Sphere.transform;

        // Attribute a component with unity editor
        // Do this for TEXT
        //DONE

        //EXERCICE 2 : Modifier des GameObjects et des composants dans un script

        //Set Cylinder position to (-2,1,1)
        //Cylinder.GetComponent<Transform>().position = new Vector3(-2,1,1);
        Cylinder.transform.position = new Vector3(-2, 1, 1);
        //Set TEXT Text to "Hello World"
        TEXT.text = "Hello World";
        //Set a new color on Cube
        Cube.GetComponent<MeshRenderer>().material.color = Color.red;

        //EXERCICE 3 : Créer ou supprimer des GameObjects / ajouter ou supprimer des composants dans un script

        //Remove SphereCollider on Sphere GameObject
        Destroy(Sphere.GetComponent<Collider>());
        //Create a new GameObject named OBJECT1
        GameObject OBJECT1 = new GameObject("OBJECT1");

        //Add TestA script on OBJECT1 (reminder TestA is a component)
        TestA testa = OBJECT1.AddComponent<TestA>();
        //Add TestB Script on Sphere GameObject
        TestB testb = Sphere.AddComponent<TestB>();
        //Destroy Directional Light GameObject
        Destroy(GameObject.Find("Directional Light"));
        //EXERCICE 4 : Communication entre script

        // Attribute TestA component to TestB other variable
        //OBJECT1.GetComponent<TestA>().other = Sphere.GetComponent<TestB>();
        testb.other = testa;
        // Attribute TestB component to TestA other variable
        testa.other = testb;
        // Set TestA value to 5 in this script and print it in the console
        testa.value = 5;
        Debug.Log(testa.value);
        // Run Calculate method of TestA and TestB  in this script
        testa.Calculate();
        testb.Calculate();
        // Modify TestA to run ShowMessage method in Start Method
        //DONE
        // Modify TestA ShowMessage method to print TestB otherMessage string at the end of previous printed string
        //DONE
        // Modify TestB to run ShowMessage from this script
        testb.ShowMessage();
    }

}
