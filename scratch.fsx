namespace Domain.Shared

    module Types =

        type Score = 
        | GOOD
        | BAD

        type Amount = int


namespace Domain.Scoring1

module Main =
    open Domain.Shared.Types

    let go input :Score = 
        Score.BAD

namespace Domain.Scoring2

module Main =
    open Domain.Shared.Types

    let go input :Score = 
        Score.GOOD

namespace Application

module BankA =

    let standardize x = "a"

    let go input = 
        
        input
        |> standardize
        |> Domain.Scoring1.Main.go


module BankB =

    let standardize x = "b"

    let go input = 
        
        input
        |> standardize
        |> Domain.Scoring2.Main.go


namespace Infrastructure

module BankA =

    let read filename = "A"

    let go filename = 
        
        filename
        |> read
        |> Application.BankA.go

module BankB =

    let read filename = "B"

    let go (filename:string) = 
        
        filename
        |> read
        |> Application.BankB.go

module Shell =

    [<EntryPoint>]
    let main (args: array<string>) =
        match args with
        | [| "A"; filename |] -> printfn "%A" (BankA.go filename)
        | [| "B"; filename |] -> printfn "%A" (BankB.go filename)
        | _ -> printfn "Not implemented"
        0
