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

## Project Notes
- Looks like the .NET 6 webapi comes with swashbuckle/swagger out-the-box, nice!