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

*I know the brief doesn't suggest it needs to be a WebAPI, but it was implied by the conversion and role!*

## How to run
- It requires the .NET 6 SDK to run (installed by default with VS 2022, manual otherwise)
- Requires the C# extension in VS Code
- There is a VSCode launch.json file providing VSCode debug options and a launchSettings.json that is picked up by VS, so either should work
- Being .NET 6 and running in Kestrel by default, this should run on Windows, Mac or Linux 

## Project Notes
- Looks like the .NET 6 webapi comes with swashbuckle/swagger out-the-box, nice!