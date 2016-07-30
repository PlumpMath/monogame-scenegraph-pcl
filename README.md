# monogame-scenegraph-pcl

MonoGame is awesome for writing games on android/IOS in Xamarin but its entirely functional. This small scenegraph is my beginning step to writing an object-oriented game api on monogame. If you are just getting started in monogame, check out this repo. It should save you a bit of time and get you up and running with monogame.

*Pull Requests happily accepted*
This is quite minimal and still needs some building out but its enough to get anyone new started quickly. Currently there are four classes. Scene, Layer, Entity, and Sprite. Each of these is extendable.

* A Scene is a collection of layers
* A Layer is a collection of components
* An Entity is a type of component and a collection of components.
* A Sprite is a type of component

![dependencies](https://github.com/digital-synapse/monogame-scenegraph-pcl/raw/master/assets/TypeDependencies.PNG)

Things i would like to see added:
* A resource manager to allow loading/unloading assets for levels
* methods for draw order within layers
* method for draw order within scenes
* whatever else you think of

Here is a simple game class to get you started...
```
/// <summary>
/// Allows the game to perform any initialization it needs to before starting to run.
/// This is where it can query for any required services and load any non-graphic
/// related content.  Calling base.Initialize will enumerate through any components
/// and initialize them as well.
/// </summary>
protected override void Initialize()
{
    scene = new Scene(GraphicsDevice);
    base.Initialize();

}

/// <summary>
/// LoadContent will be called once per game and is the place to load
/// all of your content.
/// </summary>
protected override void LoadContent()
{
    // Here you will load all your needed textures. Sprites should be initialized with a texture
    //resources.Load();  
    
    // this is where you will add your layers and sprites to the scene graph
    var firstLayer = new Layer();
    scene.Add(firstLayer);

    // your scene setup here...
}

/// <summary>
/// Allows the game to run logic such as updating the world,
/// checking for collisions, gathering input, and playing audio.
/// </summary>
/// <param name="gameTime">Provides a snapshot of timing values.</param>
protected override void Update(GameTime gameTime)
{
    scene.Update(gameTime);            
    base.Update(gameTime);
}

/// <summary>
/// This is called when the game should draw itself.
/// </summary>
/// <param name="gameTime">Provides a snapshot of timing values.</param>
protected override void Draw(GameTime gameTime)
{
    scene.Draw(gameTime);
    base.Draw(gameTime);
}
```
