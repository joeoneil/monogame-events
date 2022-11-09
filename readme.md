# MonoGame-Events

This is a repo containing classes which will manage key, button, and mouse events for you! No more bullshit if statements and manual rising edge detection on your buttons and keys.
All the classes are designed with the callback event handling design pattern in mind. If you don't know what that is, don't worry, you don't need to, it just works.

## InputManager

The input manager handles all keyboard and gamepad input and interacts with the `genericButton` and `compoundButton` classes to handle button events simultaneously and interchangeable between both keyboard and gamepad inputs.

### Usage

To use the input manager, you must first create an instance of it. This is done by calling the constructor with the `Game` object as the parameter. This is done in the `Initialize()` method of your game class.

```csharp
protected override void Initialize() {
    inputManager = new InputManager();
    base.Initialize();
}
```

You must also define key bindings for your game. This is done by calling the `onPressed()`, `onReleased()`, or `onHeld()` method of the input manager. This method takes two parameters, the first is a `GenericButton` or `CompoundButtton`, and the second is an `Action` you want to bind to that button. This is done in the `Initialize()` method of your game class.

```csharp
protected override void Initialize() {
    inputManager = new InputManager();
    inputManager.onPressed(GenericButton.KeySpace, () => {
        // Do something when the space key is pressed
        // This is a lambda expression, but you can use a method instead
        // All Keyboard keys are prefixed with "Key"
    });
    inputManager.onReleased(GenericButton.GPStart, () => {
        // Do something when the start button is released
        // All Gamepad buttons are prefixed with "GP"
    });
    inputManager.onHeld(GenericButton.DevA1, () => {
        // Do something while the Devcade A1 button is held
        // All Devcade buttons are prefixed with "Dev"
    });
    base.Initialize();
}
```

After that, you must call the `Update()` method of the input manager in the `Update()` method of your game class.

```csharp
protected override void Update(GameTime gameTime) {
    // For Keyboard input
    inputManager.Update(Keyboard.getState());
    // For Gamepad input
    inputManager.Update(GamePad.getState(PlayerIndex.One));
    // For both
    inputManager.Update(Keyboard.getState(), GamePad.getState(PlayerIndex.One));
    base.Update(gameTime);
}
```
### Compound Buttons

The input manager also allows compound buttons. For example, if you want an action to happen only when two buttons are pressed, or you want to bind an action to two different buttons in a way that allows for code reuse. The library comes with two classes for this: `GenericButton` and `CompoundButton`.

The compound button is constructed from generic buttons using overloaded operators or static methods of the `CompoundButton` class.

```csharp
// Using static methods
CompoundButton c1 = CompoundButton.and(GenericButton.KeyLeftShift, GenericButton.KeyW);
CompoundButton c2 = CompoundButton.or(GenericButton.KeyW, GenericButton.KeyUp);
CompoundButton c3 = CompoundButton.not(GenericButton.KeyW);

// Using overloaded operators
CompoundButton c4 = !c1; // This button is pressed whenever c1 is not pressed
CompoundButton c5 = c1 & c2; // This button is pressed whenever both c1 and c2 are pressed
CompoundButton c6 = c1 | c2; // This button is pressed whenever either c1 or c2 are pressed
```
due to c# restrictions, you cannot use the & and | operators when both operands are generic buttons. However, you can use the static methods with generic buttons, and the overloaded operators with compound buttons. Or, you can use `CompoundButton.fromGeneric` to convert a generic button to a compound button.
```csharp

CompoundButton c7 = CompoundButton.fromGeneric(GenericButton.KeyW) & GenericButton.KeyLeftShift; // same as c1
CompoundButton c8 = GenericButton.KeyW & CompoundButton.fromGeneric(GenericButton.KeyLeftShift); // same as c1
CompoundButton c9 = CompoundButton.fromGeneric(GenericButton.KeyW) | GenericButton.KeyUp; // same as c2
```

### Compile-time input switching

The generic design of the input manager allows for compile-time switching between keyboard and gamepad input. This is done by using the `#if` compiler directive when defining key bindings.

```csharp
#if RELEASE
    CompoundButton upButton = CompoundButton.fromGeneric(GenericButton.DevA1);
#else
    CompoundButton upButton = CompoundButton.fromGeneric(GenericButton.KeyW) | GenericButton.KeyUp;
#endif

// ...

inputManager.onPressed(upButton, () => {
    // Do something when the up button is pressed
});

// ...

#if RELEASE
    inputManager.update(GamePad.GetState(PlayerIndex.One));
#else
    inputManager.update(Keyboard.GetState());
#endif
```

Once you've defined your button bindings in this manner, you'll want to build the project with the release flag to switch to devcade bindings

```sh
$ dotnet build /p:DefineConstants="RELEASE"
$ dotnet run --no-build
```

## ButtonManager

The Button manager manages physical buttons on the screen. The Button class contains only a rectangle and a callback, and will need to be created in Initialize and added to a ButtonManager with ButtonManager.Add(button). As ButtonManager is much simpler, it is a static class so it doesn't need to be constructed. Like the other two event handlers you'll need to pass in the Mouse's state every frame for it to handle events. Don't use this class though, as arcade cabinets typically do not have mouse pointers.
