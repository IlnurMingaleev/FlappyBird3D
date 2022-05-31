using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool SharedInstance;
    private LinkedList<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private Camera mainCamera;
    //[SerializeField] private List<GameObject> objectsToPool;
    private float yPos;
    private float zInterval;
    private GameObject player;

    private bool isPipe;
    private bool isRoadChunk;
    private bool isEnvChunk;
    private bool isBush;

    private PlayerController playerController;

    public bool IsPipe { get; set; }

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        isPipe = objectToPool.name == "Pipe";
        isRoadChunk = objectToPool.name == "RoadChunk";
        isEnvChunk = objectToPool.name == "EnvironmentChunk";
        isBush = objectToPool.name == "BushesByTheRoad";
        player = GameObject.Find("Player");
        pooledObjects = new LinkedList<GameObject>();
        GameObject temp;
        


        if (isRoadChunk)
        {
            zInterval = objectToPool.transform.GetChild(0).GetComponent<BoxCollider>().size.z;
            yPos = 0;
        }
        else if (isPipe)
        {
            zInterval = 15.0f;
            yPos = Random.Range(0, 7.0f);
        }
        else if (isEnvChunk)
        {
            zInterval = objectToPool.transform.GetChild(0).GetComponent<BoxCollider>().size.z;
            yPos = 0;
        }
        else if (isBush)
        {
            zInterval = 3.0f;
            yPos = 0;
        }
        else 
        {
            zInterval = 10.0f;
            yPos = 0;
        }
        for (int i = 0; i < amountToPool; i++) 
        {
            
            temp = Instantiate(objectToPool, new Vector3(objectToPool.transform.position.x, yPos, i * zInterval), objectToPool.transform.rotation);
            if (isPipe) 
            {
                yPos = Random.Range(0, 7.0f);
            }
            temp.SetActive(true);
            pooledObjects.AddLast(temp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tmp = pooledObjects.First.Value;
        if (mainCamera.transform.position.z > tmp.transform.position.z) 
        {
            Vector3 lastObjectPos = pooledObjects.Last.Value.transform.position;
            tmp.SetActive(false);
            if (isPipe)
            {
                yPos = Random.Range(0, 7.0f);
            }
            tmp.transform.position = new Vector3(lastObjectPos.x, yPos, lastObjectPos.z + zInterval);
            pooledObjects.RemoveFirst();
            pooledObjects.AddLast(tmp);
            tmp.SetActive(true);
        }
        
    }
}
