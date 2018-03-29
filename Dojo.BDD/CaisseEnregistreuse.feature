Feature: CaisseEnregistreuse

Scenario: achat simple
Given j'ai une caisse enregistreuse
Given 1 poire vaut 2€
And 1 pomme vaut 1€
When Un client achète 1 poires et 2 pommes
Then il doit payer 4€

Scenario: achat simple avec des bananes
Given j'ai une caisse enregistreuse
Given 1 poire vaut 2€
And 1 pomme vaut 1€
And 1 banane vaut 3€
When Un client achète 1 poires et 2 pommes et 3 bananes
Then il doit payer 13€

Scenario Outline: Promotion 4 poires achetées = 1 offerte
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And pour 4 poires achetées 1 poire offerte
When Un client achète <nbPoires> poires et <nbPommes> pommes
Then il doit payer <total>€

Examples:
| nbPoires | nbPommes | total |
| 1        | 2        | 4     |
| 4        | 2        | 8     |
| 6        | 2        | 12    |
| 9        | 2        | 16    |

Scenario Outline: Promotion 10 produits achetés le plus cher est offert
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And 1 banane vaut 3€
And pour 10 produits achetes le plus cher est offert
When Un client achète <nbPoires> poires et <nbPommes> pommes et <nbBananes> bananes
Then il doit payer <total>€

Examples:
| nbPoires | nbPommes | nbBananes | total |
| 3        | 6        | 1         | 12    |
| 4        | 6        | 0         | 12    |
| 0        | 10       | 0         | 9     |
| 3        | 6        | 2         | 15    |
| 6        | 6        | 0         | 16    |

Scenario Outline: Promotion de Noel
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And 1 banane vaut 3€
And 1 mandarine vaut 1.5€
And a partir de 10 mandarines achetées une remise de 10% est consentie sur les mandarines
When Un client achète <nbMandarines> mandarines
Then il doit payer <total>€

Examples:
| nbMandarines | total |
| 5            | 7.5   |
| 10           | 15    |
| 11           | 14.85 |
| 20           | 27    |