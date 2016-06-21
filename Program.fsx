open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open ForecastIO

let request = new ForecastIORequest("8fa1a8798aaafef8dabd413af871819c", 37.8267f, -122.423f, Unit.si);
let response = request.Get();

let app =
  choose
    [ GET >=> choose
        [ path "/webhook" >=> OK "Hello GET"
          path "/" >=> OK "Hello World" ]
      POST >=> choose
        [ path "/webhook" >=> OK "Hello POST"] ]

startWebServer defaultConfig app