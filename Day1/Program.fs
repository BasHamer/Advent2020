// Learn more about F# at http://fsharp.org

open System
open System.IO

let rec Smurf (target: int) (l: int list) : int list  =
  match l.Length with
  | 1 -> []
  | _ ->
    let rev = l |> List.rev 
    let sum = l.Head + rev.Head
    if sum = target then [l.Head; rev.Head]
    elif sum < target then  Smurf target (l |> List.tail)   
    else Smurf target (rev |> List.tail |> List.rev)  

let rec Smurf2 (target: int) (l: int list)  =
  let current = l.Head
  let solution = Smurf (target - current) l.Tail
  match solution.Length with
    | 0 -> Smurf2 target l.Tail
    | _ -> 
      printfn "part two answer %d" (current * solution.Head * solution.Tail.Head)

[<EntryPoint>]
let main argv =

    let lines = File.ReadAllLines(@"input.txt")

    // Convert file lines into a list.
    let data = [ for i in Seq.toList lines -> i |> int ]

    let small = List.sort data

    let r = Smurf 2020 small

    let rr = r |> List.rev

    printfn "part one answer %d" (rr.Head * r.Head)

    Smurf2 2020 small
    0 // return an integer exit code
