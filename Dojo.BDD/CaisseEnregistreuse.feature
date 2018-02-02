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

Scenario Outline: Achat avec promotion
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