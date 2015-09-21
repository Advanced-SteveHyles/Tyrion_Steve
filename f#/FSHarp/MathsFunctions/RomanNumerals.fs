namespace RomanNumerals

type Roman() =

    let rec ResolveNumeral = function
        | n when n < 0 -> "Error"
        | 0 -> ""
        | n when n < 4 -> ResolveNumeral (n - 1) + "I"
        | 4 -> "IV"
        | 5 -> "V"
        | n when n < 9 ->  ResolveNumeral (n - 1) + "I"
        | 9 -> "IX"        
        | n when n < 40 ->  "X" + ResolveNumeral (n - 10)
        | n when n < 90 ->  "C" + ResolveNumeral (n - 100)
        | n when n >= 50 -> ResolveNumeral (n - 90) + "L"
        | n when n >= 10 ->   "X" + ResolveNumeral (n - 10) 
        | n when n < 900 ->  "D" + ResolveNumeral (n - 500)
        | n when n < 100000 ->  "M" + ResolveNumeral (n - 1000)

    member this.toRoman x =
           ResolveNumeral x
