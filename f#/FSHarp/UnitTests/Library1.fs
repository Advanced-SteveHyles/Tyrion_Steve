Module UnitTests.UnitTest

open Xunit
open MathsFunctions

[<Fact>]
let ApplyingTheFactorialFunctionToTheValue5Yields120() = 
    let result =  Class1.Factorial 5

    Assert.Equal (120, fst(result))