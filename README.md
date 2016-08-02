# monogame-scenegraph-pcl

This small scenegraph is my beginning step to implementing the [component pattern](http://gameprogrammingpatterns.com/component.html)  on monogame. The built in XNA component classes aren't really applicable to the component pattern so I decided to write one myself. If you are just getting started in monogame, check out this repo. It should save you a bit of time and get you up and running with monogame.

*Pull Requests happily accepted*
This is quite minimal and still needs some building out but its enough to get anyone new started quickly. Currently there are six classes. App, Scene, Layer, Entity, Component, and Sprite. Each of these is extendable.

* App is a global singleton
* A Scene is a collection of layers
* Component is a reusable base class 
* A Layer is a collection of components
* An Entity is a container. Its both a type of component and a collection of components.
* A Sprite is a type of component

![dependencies](https://github.com/digital-synapse/monogame-scenegraph-pcl/raw/master/assets/TypeDependencies.PNG)

The idea here is to compose game entities of reusable components. These components may control sprites, animations, sounds, input, or whatever else you want. The advantage to the component pattern is that we get alot more flexibility and code reusability over complex inheritance hierarchies! 

*Communication via Shared State*
Layers, Entities, and Components have a small amount of shared state. This is intentionally limited as to reduce the memmory footprint. Shared state properties include:
* X
* Y
* Rotation
* Scale(X/Y)
* Velocity

Changes to these local values will flow down to children through the corresponding World properties (read only).
* WorldX
* WorldY
* WorldRotation
* WorldScale
* WorldVelocity

For example: The world position of a component is the sum of the component position + the entity position + the layer position. 

*Communication via Component Broadcasts*
A component can broadcast (fire and forget it) message to all of its siblings using the BroadcastMessage() / ReceiveMessage() methods. This is a great way to do simple cross component communication without making components tightly bound to eachother!
```
// a component update method...
public override void Update(GameTime gameTime, TouchCollection touchCollection)
{
    if (touchCollection.Count==0){
		BroadcastMessage(MessageType.MovementStopped);
	}
	else {
		// movement code here
	}
}

// ... in another component
public override void ReceiveMessage(object[] message){
    var messageType = object[0] as MessageType;
	if (mesageType != null){
		if (messageType == messageType.MovementStopped){
			// Do some custom logic here
		}
	}
}
```

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
