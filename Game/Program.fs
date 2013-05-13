open System
open MyGame


[<EntryPoint>]
[<STAThread>]
let main argv = 
    
    use game = new Game1()
    game.Run()


    0 // return an integer exit code
