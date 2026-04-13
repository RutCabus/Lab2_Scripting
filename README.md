# Lab2_Scripting
## 1. Increasing Sheep Spawn Difficulty Over Time

In `SheepSpawner.cs`, the spawn rate progressively increases to make the game more challenging as time goes on.

Added variables:

```
public float minSpawnTime = 0.5f;
public float decreaseAmount = 0.1f;
public float difficultyInterval = 10f;
```

Difficulty coroutine:

```
private IEnumerator DifficultyRoutine()
{
    while (canSpawn)
    {
        yield return new WaitForSeconds(difficultyInterval);

        if (timeBetweenSpawns > minSpawnTime)
        {
            timeBetweenSpawns -= decreaseAmount;
            Debug.Log("New spawn rate: " + timeBetweenSpawns);
        }
    }
}
```

Start method update:

```
void Start()
{
    StartCoroutine(SpawnRoutine());
    StartCoroutine(DifficultyRoutine());
}
```

## 2. Camera Shake When a Sheep Falls

A camera shake effect was added to improve game feedback when a sheep is dropped.

Implementation:

Created a new script: `CameraShake.cs`

In `Sheep.cs`:

```
private CameraShake cameraShake;
void Start()
{
    cameraShake = Camera.main.GetComponent<CameraShake>();
}
cameraShake.Shake();
```

## 3. Background Music System

Background music was implemented using a persistent SoundManager.

Added variables in `SoundManager.cs`:

```
public AudioSource musicSource;
public AudioClip backgroundMusic;
```

Music initialization:

```
void Awake()
{
    Instance = this;

    if (Camera.main != null)
        cameraPosition = Camera.main.transform.position;

    if (musicSource != null && backgroundMusic != null)
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    DontDestroyOnLoad(gameObject);
}
```

## 4. Fixed Double Sheep Counting Bug

A bug was fixed where sheep were sometimes counted twice. This happened due to multiple trigger detections firing for the same sheep. The logic was updated so each sheep is only processed once when dropped.

## 5. Background Music in Title Screen

The background music was also added to the Title screen. A Music GameObject was created in the Title scene.
