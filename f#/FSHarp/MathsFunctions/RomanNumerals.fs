namespace RomanNumerals

type Roman() =

    let rec ResolveNumeral = function
        | n when n < 0 -> "?"
        | 0 -> ""
        | n when n < 4 -> ResolveNumeral (n - 1) + "I"
        | 4 -> "IV"
        | 5 -> "V"
        | n when n < 9 ->  ResolveNumeral (n - 1) + "I"
        | 9 -> "IX" 
        | 10 -> "X" 
        | n when n <= 40 ->  "X" + ResolveNumeral (n - 10)
        | n when n < 100 ->  "L" + ResolveNumeral (n - 50)
        | n when n < 500 ->  "C" + ResolveNumeral (n - 100)
        | n when n < 1000 ->  ResolveNumeral (n - 500) + "D" 
        | n when n < 10000 ->  ResolveNumeral (n - 1000) + "M"
        | n -> "err"
        | n when n < 90 ->  "L" + ResolveNumeral (n - 50)
        | n when n = 500 ->  "D" 
        | n when n < 990 ->  ResolveNumeral (n - 990) + "M"
        | n ->  "M" + ResolveNumeral (n - 1000)        

    member this.toRoman x =
           ResolveNumeral x
