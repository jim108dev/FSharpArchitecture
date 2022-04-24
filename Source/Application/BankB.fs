namespace Infrastructure

module BankB =

    let standardize x = "b"

    let go input = 
        
        input
        |> standardize
        |> Scoring1.go
