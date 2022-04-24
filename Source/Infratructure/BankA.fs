namespace Infrastructure

module BankA =

    let read filename = "A"

    let go filename = 
        
        filename
        |> read
        |> measureCreditScore
