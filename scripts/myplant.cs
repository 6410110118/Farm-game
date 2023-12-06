    using UnityEngine;

    public class PlotManager : MonoBehaviour
    {
        bool isPlanted = false;
        SpriteRenderer myplant;
        BoxCollider2D myplantCollider;
        int plantStage = 0;
        SpriteRenderer plot;
        public PlantObject selectedPlant;
        float timer;


        

        // Start is called before the first frame update
        void Start()
        {
            myplant = transform.GetChild(0).GetComponent<SpriteRenderer>();
            myplantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
            plot = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
        {
            if (isPlanted)
            {
                timer -= Time.deltaTime;

                if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
                    {
                        timer = selectedPlant.timeBtwStages;
                        plantStage++;
                        UpdatePlant();
                    }
            }
        }

        private void OnMouseDown()
        {
            if (isPlanted)
            {
                if (plantStage == selectedPlant.plantStages.Length - 1)
                {
                    Harvest();
                }
            }
            else
            {
                Plant();
            }
        }

        void Harvest()
        {
            isPlanted = false;
            myplant.gameObject.SetActive(false);
        }

        void Plant()
        {
            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            timer = selectedPlant.timeBtwStages;
            myplant.gameObject.SetActive(true);
            Debug.Log("Plant");
        }

    void UpdatePlant()
    {
       
        myplant.sprite = selectedPlant.plantStages[plantStage];
      
    }

    private void OnMouseOver()
    {
        if (isPlanted)
        {
            plot.color = Color.red;
        }
        else
        {
            plot.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

}

    
