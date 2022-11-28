using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask;

    [SerializeField] GameObject northSphere;
    [SerializeField] GameObject eastSphere;
    [SerializeField] GameObject southSphere;
    [SerializeField] GameObject westSphere;

    [SerializeField] private bool northIsActivated = false;
    [SerializeField] private bool southIsActivated = false;
    [SerializeField] private bool eastIsActivated = false;
    [SerializeField] private bool westIsActivated = false;

    [SerializeField] private bool northIsOrigin;
    [SerializeField] private bool southIsOrigin;
    [SerializeField] private bool westIsOrigin;
    [SerializeField] private bool eastIsOrigin;


    [SerializeField] private Color activatedColor;



    [SerializeField] private bool isCurrentlytargeted = false;

    // Start is called before the first frame update
    void Start()
    {
        activatedColor = new Color(1f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        NorthDetection();
        SouthDetection();
        EastDetection();
        WestDetection();

    }


    private void NorthDetection()
    {
        Vector3 northDirection = new Vector3(0, 0, 1);
        Renderer northSphereRenderer = northSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, northDirection, out RaycastHit forwardHit, 100f, playerLayerMask))
        {


            isCurrentlytargeted = true;
            northIsActivated = true;

            if (southIsActivated == false && eastIsActivated == false && westIsActivated == false)
            {
                northIsOrigin = true;
                northSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                northSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }

        else
        {
            isCurrentlytargeted = false;
        }

        if (Physics.Raycast(transform.position, northDirection, 100f, playerLayerMask) && northIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(this.gameObject);
        }
    }

    private void SouthDetection()
    {
        Vector3 southDirection = new Vector3(0, 0, -1);
        Renderer southSphereRenderer = southSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, southDirection, out RaycastHit backwardHit, 100f, playerLayerMask))
        {
            southIsActivated = true;
            isCurrentlytargeted = true;


            if (northIsActivated == false && eastIsActivated == false && westIsActivated == false)
            {
                southIsOrigin = true;
                southSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                southSphereRenderer.material.SetColor("_Color", activatedColor);
            }



        }
        else
        {
            isCurrentlytargeted = false;
        }

        if (Physics.Raycast(transform.position, southDirection, 100f, playerLayerMask) && southIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(this.gameObject);
        }



    }


    private void EastDetection()
    {
        Vector3 eastDirection = new Vector3(1, 0, 0);
        Renderer eastSphereRenderer = eastSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, eastDirection, out RaycastHit eastwardHit, 100f, playerLayerMask))
        {
            eastIsActivated = true;
            isCurrentlytargeted = true;


            if (northIsActivated == false && southIsActivated == false && westIsActivated == false)
            {
                eastIsOrigin = true;
                eastSphereRenderer.material.SetColor("_Color", Color.red);
            }

            else
            {
                eastSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }
        else
        {
            isCurrentlytargeted = false;
        }

        if (Physics.Raycast(transform.position, eastDirection, 100f, playerLayerMask) && eastIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(this.gameObject);
        }
    }


    private void WestDetection()
    {


        Vector3 westDirection = new Vector3(-1, 0, 0);
        Renderer westSphereRenderer = westSphere.GetComponent<Renderer>();

        if (Physics.Raycast(transform.position, westDirection, out RaycastHit westwardHit, 100f, playerLayerMask))
        {
            westIsActivated = true;
            isCurrentlytargeted = true;


            if (northIsActivated == false && eastIsActivated == false && southIsActivated == false)
            {
                westIsOrigin = true;
                westSphereRenderer.material.SetColor("_Color", Color.red);
            }
            else
            {
                westSphereRenderer.material.SetColor("_Color", activatedColor);
            }

        }
        else
        {
            isCurrentlytargeted = false;
        }

        if (Physics.Raycast(transform.position, westDirection, 100f, playerLayerMask) && westIsOrigin == true && northIsActivated == true && southIsActivated == true && westIsActivated == true && eastIsActivated == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(this.gameObject);
        }

    }





}
