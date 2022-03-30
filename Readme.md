# A WebAPI to calculate the change from a transaction in UK denominations 

Create an application that will, given a UK currency amount
and the purchase price of a product, display the change to be
returned split down by denomination, largest first.

Example:

Given £20 and a product price of £5.50,the applicaton will output:

Your change is:
1 x £10
2 x £2
1 x 50p

## How to run
- Requires the .NET 6 SDK (installed automatically by VS 2022, otherwise manual @ https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- There is a VSCode launch.json file providing VSCode debug options and a launchSettings.json that is picked up by VS, so either should work
- Being .NET 6 and running in Kestrel by default, this should run on Windows, Mac or Linux (tested on Windows and Mac)

## Project Notes
- Looks like the .NET 6 webapi comes with swashbuckle/swagger out-the-box, nice!
