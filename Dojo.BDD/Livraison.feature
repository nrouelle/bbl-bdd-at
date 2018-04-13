Feature: Livraison

@CaisseEnregistreuseParDefaut
Scenario: achat avec livraison
Given j'ai un panier de 14 euros
Given la livraison en France vaut 10€
When Le client se fait livrer en France
Then il doit payer 24€

@CaisseEnregistreuseParDefaut
Scenario: achat avec livraison en Italie
Given j'ai un panier de 14 euros
Given la livraison en Italie vaut 20€
When Le client se fait livrer en Italie
Then il doit payer 34€

@CaisseEnregistreuseParDefaut
Scenario Outline: achat avec livraisons multiples
Given j'ai un panier de 10 euros
Given la livraison en France vaut 10€
And la livraison en Italie vaut 20€
When Le client se fait livrer en <pays>
Then il doit payer <prixTotal>€

Examples: 
| pays   | prixTotal |
| France | 20        |
| Italie | 30        |

@CaisseEnregistreuseParDefaut
Scenario: achat avec livraisons dans un pays inconnu 
Given j'ai un panier de 10 euros
Given la livraison en France vaut 10€
And la livraison en Italie vaut 20€
When La livraison n'est pas possible en Roumanie
Then La livraison est impossible en Roumanie