using UnityEngine;

public class LevelGrid
{
    private Vector2Int bonusGridPosition;

    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private GameObject bonusGameObject;


    private int width;
    private int height;

    //////////////////////////////////////////////////////////////////////////////////
    private Bonus bonus;
    //////////////////////////////////////////////////////////////////////////////////
    ///
    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
        //////////////////////////////////////////////////////////////////////////////////

        SpawnBonus();

        //////////////////////////////////////////////////////////////////////////////////

    }

    
    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
           
            SpawnFood();
            Score.AddScore(Score.POINTS);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TrySnakeEatBonus(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == bonusGridPosition)
        {
           
            Object.Destroy(bonusGameObject);
           
            SpawnBonus();

            return true;
        }
        else
        {
            return false;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////
    private void SpawnBonus()
    {

        do
        {
            bonusGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(bonusGridPosition) != -1);


        bonusGameObject = new GameObject("Bonus");
        SpriteRenderer bonusSpriteRenderer = bonusGameObject.AddComponent<SpriteRenderer>();
        bonusSpriteRenderer.sprite = GameAssets.Instance.bonusSprite;
        bonusGameObject.transform.position = new Vector3(bonusGridPosition.x, bonusGridPosition.y, 0);

        //bonus = bonusObject.AddComponent<Bonus>();



    }


    //////////////////////////////////////////////////////////////////////////////////
    private void SpawnFood()
    {
     
        
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);
        
        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }
   

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}
