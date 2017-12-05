Feature: CaisseEnregistreuse

Scenario: achat simple
Given j'ai une caisse enregistreuse
Given 1 poire vaut 2€
And 1 pomme vaut 1€
When Un client achète 1 poires et 2 pommes
Then il doit payer 4€

Scenario: Achat avec promotion
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And pour 4 poires achetées 1 poire offerte
When Un client achète 4 poires et 2 pommes
Then il doit payer 8€

Scenario: Achat avec promotion bis
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And pour 4 poires achetées 1 poire offerte
When Un client achète 6 poires et 2 pommes
Then il doit payer 12€

Scenario: Achat avec promotion ter
Given j'ai une caisse enregistreuse
And 1 poire vaut 2€
And 1 pomme vaut 1€
And pour 4 poires achetées 1 poire offerte
When Un client achète 9 poires et 2 pommes
Then il doit payer 16€
