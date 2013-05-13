namespace MyGame

open System
open System.Collections.Generic
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Storage
open Microsoft.Xna.Framework.GamerServices

type Game1() as this =
  inherit Game()

  let graphics = new GraphicsDeviceManager(this)
  do this.Content.RootDirectory <- "Content"

  let mutable gridFont = Unchecked.defaultof<SpriteFont>
  let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>

  override this.Initialize() =
    graphics.PreferredBackBufferWidth <- 480
    graphics.PreferredBackBufferHeight <- 800
    base.Initialize()

  override this.LoadContent() =
    spriteBatch <- new SpriteBatch(this.GraphicsDevice)
    gridFont <- this.Content.Load<SpriteFont>("MyFont")

  override this.UnloadContent() = ()

  override this.Update(gameTime) =
    if GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)
      then this.Exit()

    base.Update(gameTime)

  override this.Draw(gameTime) =
    this.GraphicsDevice.Clear(Color.CornflowerBlue)

    spriteBatch.Begin()

    for i = 0 to 99 do
      for j = 0 to 99 do
        let str = sprintf "%d, %d" i j
        spriteBatch.DrawString(gridFont, str, Vector2(float32 i * 60.F, float32 j * 20.F), Color.White)

    spriteBatch.End()

    base.Draw(gameTime)