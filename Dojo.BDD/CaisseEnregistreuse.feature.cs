﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dojo.BDD
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CaisseEnregistreuse")]
    public partial class CaisseEnregistreuseFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CaisseEnregistreuse.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CaisseEnregistreuse", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("achat simple")]
        public virtual void AchatSimple()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("achat simple", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
testRunner.Given("j\'ai une caisse enregistreuse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
testRunner.Given("1 poire vaut 2€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
testRunner.And("1 pomme vaut 1€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
testRunner.When("Un client achète 1 poires et 2 pommes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then("il doit payer 4€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("achat simple avec des bananes")]
        public virtual void AchatSimpleAvecDesBananes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("achat simple avec des bananes", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.Given("j\'ai une caisse enregistreuse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
testRunner.Given("1 poire vaut 2€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
testRunner.And("1 pomme vaut 1€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("1 banane vaut 3€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.When("Un client achète 1 poires et 2 pommes et 3 bananes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("il doit payer 13€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Promotion 4 poires achetées = 1 offerte")]
        [NUnit.Framework.TestCaseAttribute("1", "2", "4", null)]
        [NUnit.Framework.TestCaseAttribute("4", "2", "8", null)]
        [NUnit.Framework.TestCaseAttribute("6", "2", "12", null)]
        [NUnit.Framework.TestCaseAttribute("9", "2", "16", null)]
        public virtual void Promotion4PoiresAchetees1Offerte(string nbPoires, string nbPommes, string total, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Promotion 4 poires achetées = 1 offerte", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.Given("j\'ai une caisse enregistreuse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
testRunner.And("1 poire vaut 2€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("1 pomme vaut 1€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("pour 4 poires achetées 1 poire offerte", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.When(string.Format("Un client achète {0} poires et {1} pommes", nbPoires, nbPommes), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.Then(string.Format("il doit payer {0}€", total), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Promotion 10 produits acehtés le plus cher est offert")]
        [NUnit.Framework.TestCaseAttribute("3", "6", "1", "12", null)]
        [NUnit.Framework.TestCaseAttribute("4", "6", "0", "12", null)]
        [NUnit.Framework.TestCaseAttribute("0", "10", "0", "9", null)]
        [NUnit.Framework.TestCaseAttribute("3", "6", "2", "15", null)]
        [NUnit.Framework.TestCaseAttribute("6", "6", "0", "16", null)]
        public virtual void Promotion10ProduitsAcehtesLePlusCherEstOffert(string nbPoires, string nbPommes, string nbBananes, string total, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Promotion 10 produits acehtés le plus cher est offert", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
testRunner.Given("j\'ai une caisse enregistreuse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
testRunner.And("1 poire vaut 2€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.And("1 pomme vaut 1€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.And("1 banane vaut 3€", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.And("pour 10 produits achetes le plus cher est offert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.When(string.Format("Un client achète {0} poires et {1} pommes et {2} bananes", nbPoires, nbPommes, nbBananes), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then(string.Format("il doit payer {0}€", total), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion