using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static CompetitionTaskMars.Utilities.GlobalDefinitions;
using CompetitionTaskMars.Utilities;

internal class ManageListing : CommonDriver
{
    //private IWebDriver _driver;
    ManageListing ManageListingObj;
    

    private IWebElement ManageListingTab => driver.FindElement(By.XPath("//div/section[1]/div/a[3]"));

    //  string ManageListingTabWait => "//*[@id='service-listing-section']/section[1]/div/a[3]";
    ////  WaitHelpers.WaitToBeVisible(driver, "XPath", ManageListingTabWait, 2);


    //view details of listing
    private IWebElement viewButton => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]/i"));
    
    //deletebutton
      
     private IWebElement deleteButton => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
       
    //accept delete

    private IWebElement deleteButtonaccept => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
    //Edit Details
    private IWebElement EditButton => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
    


    private IList<IWebElement> ServiceTypeRadioButton = driver.FindElements(By.Name("serviceType"));
    //save
    private IWebElement SaveButton => driver.FindElement(By.XPath("//div[2]/div/form/div[11]/div/input[1]"));
    //title
    private IWebElement etitle => driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
    //description
    private IWebElement edescription => driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));

    //private IWebElement Description => driver.FindElement(By.Name("description"));


    //select category
    private IWebElement CategorySelect1 => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select/option[1]"));

    //Category dropdown
    private IWebElement CategorySelect => driver.FindElement(By.XPath("//div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]"));

    //subcategory dropdown
    private IWebElement SubCategory => driver.FindElement(By.XPath("//div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]"));

    //[FindsBy(How = How.XPath, Using XPath= "//div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")]
    //private IWebElement SubCategorySelect { get; set; }
    //Tag
    private IWebElement Tags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
    //deletetage

    private IWebElement dTags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/span/a"));
    //service Type radiobutton

    private IWebElement ServiceType => driver.FindElement(By.Name("serviceType"));

    private IWebElement ServiceTypeHourly => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
    private IWebElement ServiceTypeOneOff => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

    //Location Type radiobutton
    private IWebElement LocationType => driver.FindElement(By.Name("locationType"));
    private IWebElement LocationTypeOn_site => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
    private IWebElement LocationTypeOnline => driver.FindElement(By.XPath("//div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
    //start date calender
    private IWebElement StartDate => driver.FindElement(By.Name("startDate"));
    private IWebElement StartDateCalender => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

    //EndDate Calender
    private IWebElement EndDate => driver.FindElement(By.Name("endDate"));
    //click monday
    private IWebElement mon => driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));

    //Checkbox for days index of sunday- 0, monday- 1 so on
    private IList<IWebElement> AvailableDays => driver.FindElements(By.XPath("//input[@name='Available']"));

    //Start Time selector index changing
    private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));

    // StartTime
    private IWebElement starttime => driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
    //endtime
    private IWebElement endtime => driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
    //Finish Time selector index

    private IList<IWebElement> EndTime => driver.FindElements(By.Name("EndTime"));

    //Skill Trade selector index change skill exchange -0 and credit-1

    private IWebElement SkillTrade => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));


    private IWebElement skillExchange => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

    private IWebElement Credit => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

    //if skill trade is credit or index is 1 then amount for credit
    private IWebElement CreditCharge => driver.FindElement(By.Name("charge"));

    //work sample file upload
    private IWebElement WorkSample => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

    //Active Status

    private IWebElement ActiveStatus => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

    private IWebElement HiddenStatus => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));





    public void NavigateManageListing()
    {
        ManageListingTab.Click();
        Thread.Sleep(1000);
    }
    

    public void ViewManageListings()
    {
        ManageListingTab.Click();
        Thread.Sleep(1000);
        viewButton.Click();
        
        Thread.Sleep(3000);
        ManageListingTab.Click();
          Thread.Sleep(3000);

    }
    public void EditManageListing()
    {
        Thread.Sleep(2000);
        GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "Edit");
        ManageListingTab.Click();
        
        Thread.Sleep(2000);
        EditButton.Click();
        Thread.Sleep(1000);
        etitle.Clear();
        Thread.Sleep(1000);
        etitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        edescription.Clear();
        edescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
        string CategoryXl = (GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
        CategorySelect.Click();
        String subcategory = (GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
        //Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
        dTags.Click();
        Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
        SubCategory.Click();
        var servicetypeText = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
        if (servicetypeText == "Hourly basis service")
        {
            ServiceTypeHourly.Click();
        }
        else
        {
            ServiceTypeOneOff.Click();
        }
        var location = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");

        if (location == "On-site")
        {
            LocationTypeOn_site.Click();
        }
        else
        {
            LocationTypeOnline.Click();
        }
        StartDateCalender.Click();
        StartDateCalender.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));

        EndDate.Click();
        EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

        //EndTimeDropDownM.Click();

        //EndTimeM.SendKeys(DateTime.Parse(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime")).ToString("hh:mmtt"));
        //for (int j = 1; j < 8; j++)
        //{

        string daysInput = GlobalDefinitions.ExcelLib.ReadData(2, "AvailableDays");
        //  string Days = "";
        //switch (daysInput)
        //{
        //  case "Sun":
        //    Days = "0";
        //  break;
        //case "Mon":
        //  Days = "1";
        mon.Click();
        //break;
        //case "Tue":
        //  Days = "2";
        //break;
        //case "Wed":
        //  Days = "3";
        //break;
        //case "Thu":
        //  Days = "4";
        //break;
        //case "Fri":
        //  Days = "5";
        //break;
        //case "Sat":
        //  Days = "6";
        //break;

        //}

        //for (int i = 0; i < AvailableDays.Count; i++)
        //{




        //  string Available = AvailableDays[i].GetAttribute("index").ToString();


        //if (Days == Available)
        //{
        //  AvailableDays[i].Click();

        starttime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));

        endtime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FinishTime"));



        string SkillTradeXl = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
        if (SkillTradeXl == "Skill-exchange")
        {
            SkillTrade.Click();
            skillExchange.Click();
            skillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            skillExchange.SendKeys(Keys.Return);
        }
        else
        {
            Credit.Click();
            CreditCharge.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
        }
        Thread.Sleep(5000);
        WorkSample.Click();
        Thread.Sleep(2000);
        /* 
         Thread.Sleep(1000);

        */
        string ActiveStatusXl = ExcelLib.ReadData(2, "Active");

        if (ActiveStatusXl == "Active")
        {
            ActiveStatus.Click();
        }
        else
        {
            HiddenStatus.Click();
        }

        Thread.Sleep(1000);
        SaveButton.Click();
        Thread.Sleep(2000);
        //ManageListingT.Click();
        Thread.Sleep(3000);

    }


    public string TitleEditedExcel()
    {
        GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "Edit");
        string TitleExcel = (ExcelLib.ReadData(2, "Title")).ToString();
        return TitleExcel;
    }

    public string DescriptionEditedExcel()
    {
        GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "Edit");
        string DescriptionExcel = (ExcelLib.ReadData(2, "Description")).ToString();
        return DescriptionExcel;
    }





    public void DeleteManageListing()
    {
        Thread.Sleep(2000);
        deleteButton.Click();
        Thread.Sleep(1000);
        deleteButtonaccept.Click();
        Thread.Sleep(3000);

    }

    

    private string TitleVi = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span";
    private string DescriptionVi = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]";

    private IWebElement TitleView => driver.FindElement(By.XPath(TitleVi));
    private IWebElement DescriptionView => driver.FindElement(By.XPath(DescriptionVi));
    public string TitleViewD()
    {

        return TitleView.Text;

    }
    public string DescriptionViewD()
    {

        return DescriptionView.Text;

    }



}
