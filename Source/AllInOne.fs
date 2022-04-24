namespace Domain.Shared

module Types =

    type Score = 
    | GOOD
    | BAD

    type TaxAmount = int


namespace Domain.Scoring1

module Main =
    open Domain.Shared.Types

    let go input :Score = Score.BAD


namespace Domain.Scoring2

module Main =
    open Domain.Shared.Types

    let go input :Score = Score.GOOD


namespace Domain.ComputeTaxes1

module Main =
    open Domain.Shared.Types

    let go input :TaxAmount = 1


namespace Application

module BankA =

    let standardize x = "a"

    let score input = 
        
        input
        |> standardize
        |> Domain.Scoring1.Main.go

    let computeTaxes input = 
        
        input
        |> standardize
        |> Domain.ComputeTaxes1.Main.go


module BankB =

    let standardize x = "b"

    let score input = 
        
        input
        |> standardize
        |> Domain.Scoring2.Main.go


namespace Infrastructure

module BankA =

    let read filename = "A"

    let score filename = 
        
        filename
        |> read
        |> Application.BankA.score

    let computeTaxes (filename:string) = 
        
        filename
        |> read
        |> Application.BankA.computeTaxes

module BankB =

    let read filename = "B"

    let score (filename:string) = 
        
        filename
        |> read
        |> Application.BankB.score

module Shell =

    [<EntryPoint>]
    let main (args: array<string>) =
        match args with
        | [| "A"; "score"; filename |] -> printfn "%A" (BankA.score filename)
        | [| "A"; "tax"; filename |] -> printfn "%A" (BankA.computeTaxes filename)
        | [| "B"; "score"; filename |] -> printfn "%A" (BankB.score filename)
        | _ -> printfn "Not implemented"
        0
