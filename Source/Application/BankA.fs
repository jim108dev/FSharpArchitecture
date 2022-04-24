namespace Application

module BankA =

    let standardize x = "a"

    let go input = 
        
        input
        |> standardize
        |> Scoring2.go
