Feature: Livraison
	
Scenario: achat avec livraison
Given j'ai un panier qui vaut 14€
And la livraison en France vaut 10€
When Le client se fait livrer en France
Then il doit payer 24€


Scenario: achat avec livraison en Italie
Given j'ai un panier qui vaut 14€
And la livraison en Italie vaut 20€
When Le client se fait livrer en Italie
Then il doit payer 34€

@Panier10euros @CaisseEnregistreuseParDefaut
Scenario Outline: achat avec livraisons multiples
Given la livraison en France vaut 10€
And la livraison en Italie vaut 20€
When Le client se fait livrer en <pays>
Then il doit payer <prixTotal>€

Examples: 
| pays   | prixTotal |
| France | 20        |
| Italie | 30        |

@Panier10euros @CaisseEnregistreuseParDefaut
Scenario: achat avec livraisons dans un pays inconnu 
Given la livraison en France vaut 10€
And la livraison en Italie vaut 20€
When La livraison n'est pas possible en Roumanie
Then La livraison est impossible en Roumanie