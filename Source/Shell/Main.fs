[<EntryPoint>]
let main (args: array<string>) =
    match args with
    | [| "A"; filename |] -> printfn "yeah"
    | [| "B"; filename |] -> printfn "yeah"
    | _ -> printfn "Not implemented"

    0
