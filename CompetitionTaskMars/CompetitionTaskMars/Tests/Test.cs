using CompetitionTaskMars.Pages;
using CompetitionTaskMars.Utilities;
using NUnit.Framework;

internal class ShareSkillTest : CommonDriver
{

    ShareSkill ShareSkillObj;
    ManageListing ManageListingObj;

    [Test, Order(1)]
    public void AddSkillShare()
    {
        SignIn loginobj = new SignIn();
       // loginobj.NavigatetoHomepage();
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        Thread.Sleep(2000);
        ShareSkillObj = new ShareSkill();
        ShareSkillObj.NavigateToShareSkill();
        ShareSkillObj.AddSkillShare();

        //Assertion objects
        string ExcelAddTitle = ShareSkillObj.TitleAddedExcel().ToString();
       string ExecelAddDescription = ShareSkillObj.DescriptionAddedExcel().ToString();
       string AddTitle = ShareSkillObj.TitleAdded().ToString();
       string AddDescription = ShareSkillObj.DescriptionAdded().ToString();
       Assert.That(ExcelAddTitle == "testing", "Title Addded Does not match with the existing");
      Assert.That(ExecelAddDescription == AddDescription, "Description Addded Does not match with the existing");

    }
    [Test, Order(2)]
    public void EditSkill()
    {

        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        Thread.Sleep(2000);
        ManageListingObj = new ManageListing();
        ManageListingObj.ViewManageListings();
        Thread.Sleep(2000);
        ManageListingObj.EditManageListing();

        string EditedTitle = ManageListingObj.TitleEdited().ToString();
        string EditedDescription = ManageListingObj.DescriptionEdited().ToString();

        ManageListingObj.ViewManageListings();
        //Assertion Objects

       string ViewTitle = ManageListingObj.TitleViewD().ToString();
        string ViewDescription = ManageListingObj.DescriptionViewD().ToString();


        Assert.That(EditedTitle == ViewTitle, "Title Details Does not match with the selected");
        Assert.That(EditedDescription == ViewDescription, "Description details Does not match with the selected");

    }
    [Test, Order(3)]
    public void viewSkill()
    {


        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        Thread.Sleep(2000);
        ManageListingObj = new ManageListing();
        ManageListingObj.NavigateManageListing();
        ManageListingObj.ViewManageListings();
        ManageListingObj.NavigateManageListing();
        ManageListingObj.DeleteManageListing();
        //Assertion Objects
                     
       
        string EditExcelTitle = ManageListingObj.TitleEditedExcel().ToString();
       
        Assert.That(EditExcelTitle == "POM", "Title Edited Does not match with the existing");
       
    
        }
    [Test,Order(4)]
    public void login()
    {
        SignIn loginobj = new SignIn();
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        loginobj.TestNegative();
    }

}