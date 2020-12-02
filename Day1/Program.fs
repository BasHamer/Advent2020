// Learn more about F# at http://fsharp.org

open System
open System.IO

let rec Smurf (target: int) (l: int list) : int list  =
  let rev = l |> List.rev 
  let sum = l.Head + rev.Head
  if sum = target then l
  elif sum < target then  Smurf target (l |> List.tail)   
  else Smurf target (rev |> List.tail |> List.rev)  

[<EntryPoint>]
let main argv =

    let lines = File.ReadAllLines(@"input.txt")

    // Convert file lines into a list.
    let data = [ for i in Seq.toList lines -> i |> int ]

    let small = List.sort data

    let r = Smurf 2020 small

    printfn "list.Length is %d" (small.Length)
    printfn "list.Head is %d" (small.Head)
    printfn "r.Length is %d" (r.Length)
    printfn "list.Head is %d" (r.Head)
    let rr = r |> List.rev
    printfn "list.Head is %d" (rr.Head)


    printfn "list.Head is %d" (rr.Head * r.Head)
    0 // return an integer exit code
