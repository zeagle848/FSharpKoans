﻿namespace FSharpKoans
open NUnit.Framework

module Functions = 
   let [<Test>] ``A function takes one input and produces one output`` () =
      (fun a -> a + 100) ___ |> should equal 2097

   let [<Test>] ``The input to a function is a pattern`` () =
      (fun 7 -> 9) ___ |> should equal 9
      (fun (t,u) -> u, t) ___ |> should equal (9, 0)
      // remember our record types from AboutRecords.fs ?
      (fun { Author=k } -> "Author is " + k) ___ |> should equal "Author is Plato"

   let [<Test>] ``A function can have a name`` () =
      let one_third = fun ka -> ka / 3
      ___ 21 |> should equal 7

   let [<Test>] ``A function can span multiple lines`` () =
      (fun zorro ->
         let k = "swash"
         let b = "buckle"
         zorro + " likes to " + k + b) "Zorro the pirate" |> should equal __

   let [<Test>] ``A function can return a function`` () =
      let i = fun love -> fun hate -> love - hate
      let j = i 10
      let k = j 9
      k |> should equal ___

   let [<Test>] ``A function can return a function (one-liner!)`` () =
      (fun love -> fun hate -> love - hate) 10 9 |> should equal ___

   let [<Test>] ``'Multiple-argument' functions are one-input, one-output in disguise`` () =
      let i = fun love hate -> love-hate
      let j = i 10
      let k = j 9
      k |> should equal ___

   let [<Test>] ``'let'-syntax for functions`` () =
      let i love hate = love-hate
      let j = i 10
      let k = j 9
      k |> should equal ___

   let [<Test>] ``Keeping a function for later use`` () =
      let f animal noise = animal + " says " + noise
      let cows = f "cow"
      let kittehs = f "cat"
      cows "moo" |> should equal __
      kittehs "nyan" |> should equal __

   let [<Test>] ``Aliasing a function`` () =
      let f x = x + 2
      let y = f
      y 20 |> should equal ___

   let [<Test>] ``Using a value defined in an inner scope`` () =
      let g t =
         let result =
            match t%2 with
            | 0 -> 10
            | 1 -> 65
         fun x -> result - x
      g 5 8 |> should equal __
      g 8 5 |> should equal __
      // PS. I hope this one brought you some closure.

   let [<Test>] ``'rec' exposes the name of the function for use inside the function`` () =
      let rec isValid dino =
         match dino with
         | [] -> "All valid."
         | "Thesaurus"::_ -> "A thesaurus isn't a dinosaur!"
         | _::rest -> isValid rest
      isValid ["Stegosaurus"; "Bambiraptor"] |> should equal __
      isValid ["Triceratops"; "Thesaurus"; "Tyrannosaurus Rex"] |> should equal __

   let [<Test>] ``Nesting functions`` () =
      let hailstone x =
         let triple x = x * 3
         let addOne x = x + 1
         x
         |> triple
         |> addOne
      hailstone 5 |> should equal __