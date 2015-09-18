module Tests

    open Xunit
    open MathsFunctions

    [<Fact>]
    let SimpleTest() =

        let s1 = "stuff"

        Assert.Equal<string>("stuff", s1)

    [<Fact>]
    let SimpleTest2() =

        let s1 = "stuff"

        Assert.Equal<string>("stuff", s1)
        
       
    [<Fact>]
    let ApplyingTheFactorialFunctionToTheValue5Yields120() = 
                
        let c = new MathClass()
       
        Assert.Equal<int> (120, c.GetFactorial 5)

    [<Fact>]
    let ApplyingTheFactorialFunctionToTheValueNegative5DoesSomething() = 
                
        let c = new MathClass()
       
        Assert.Equal<int> (120, c.GetFactorial -5)


    [<Fact>]
    let ApplyingTheFactorialFunctionToTheValue5p00Yields120() = 
                
        let c = new MathClass()
       
        Assert.Equal<float> (120.00, c.GetFactorialF 5.00)
