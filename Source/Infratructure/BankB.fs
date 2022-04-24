namespace Infrastructure

module BankB =

    let read filename = "B"

    let go filename = 
        
        filename
        |> read
        |> measureCreditScore
