﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Dev2.CodedUI.Tests.UIMaps.RibbonUIMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Dev2.CodedUI.Tests;


    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class RibbonUIMap
    {
        public UITestControl getControl(string tabName, string buttonText)
        {
            UITestControl returnControl = new UITestControl();
            WpfTabList uIRibbonTabList = this.UIBusinessDesignStudioWindow.UIRibbonTabList;
            //int tabCount = uIRibbonTabList.Tabs.Count;
            foreach (WpfTabPage buttonList in uIRibbonTabList.Tabs)
            {
                if (buttonList.FriendlyName == tabName)
                {
                    UITestControlCollection buttonListChildren = buttonList.GetChildren();
                    foreach (UITestControl buttonGroup in buttonListChildren)
                    {
                        foreach (var potentialButton in buttonGroup.GetChildren())
                        {
                            if (potentialButton.GetChildren().Count > 0)
                            {
                                UITestControlCollection buttonProperties = potentialButton.GetChildren();
                                string friendlyName = buttonProperties[0].FriendlyName;
                                if (friendlyName == buttonText)
                                {
                                    return (UITestControl)buttonProperties[0];
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }


        private UITestControlCollection getRibbonItemListFromMenuName(string menuName)
        {
            UITestControlCollection theCollection = new UITestControlCollection();
            WpfTabList uIRibbonTabList = this.UIBusinessDesignStudioWindow.UIRibbonTabList;

            for (int j = 0; j < uIRibbonTabList.Tabs.Count; j++)
            {
                if (uIRibbonTabList.Tabs[j].FriendlyName == menuName)
                {
                    theCollection = uIRibbonTabList.Tabs[j].GetChildren();
                    break;
                }
            }
            return theCollection;
        }

        #region Properties
        public UIBusinessDesignStudioWindow UIBusinessDesignStudioWindow
        {
            get
            {
                if ((this.mUIBusinessDesignStudioWindow == null))
                {
                    this.mUIBusinessDesignStudioWindow = new UIBusinessDesignStudioWindow();
                }
                return this.mUIBusinessDesignStudioWindow;
            }
        }
        #endregion

        #region Fields
        private UIBusinessDesignStudioWindow mUIBusinessDesignStudioWindow;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIBusinessDesignStudioWindow : WpfWindow
    {

        public UIBusinessDesignStudioWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.Name, "Warewolf", PropertyExpressionOperator.Contains));
            #endregion
        }

        #region Properties
        public UIZf56a7f909cd342859f4Custom UIZf56a7f909cd342859f4Custom
        {
            get
            {
                if ((this.mUIZf56a7f909cd342859f4Custom == null))
                {
                    this.mUIZf56a7f909cd342859f4Custom = new UIZf56a7f909cd342859f4Custom(this);
                }
                return this.mUIZf56a7f909cd342859f4Custom;
            }
        }

        public WpfTabList UIRibbonTabList
        {
            get
            {
                if ((this.mUIRibbonTabList == null))
                {
                    this.mUIRibbonTabList = new WpfTabList(this);
                    #region Search Criteria
                    this.mUIRibbonTabList.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "ribbon";
                    this.mUIRibbonTabList.WindowTitles.Add(TestBase.GetStudioWindowName());
                    #endregion
                }
                return this.mUIRibbonTabList;
            }
        }
        #endregion Properties



        #region Fields
        private WpfTabList mUIRibbonTabList;
        private UIZf56a7f909cd342859f4Custom mUIZf56a7f909cd342859f4Custom;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIZf56a7f909cd342859f4Custom : WpfCustom
    {

        public UIZf56a7f909cd342859f4Custom(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.SplitPane";
            this.SearchProperties["AutomationId"] = "Zf56a7f909cd342859f48037f6770e93f";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UIUI_TabManager_AutoIDTabList UIUI_TabManager_AutoIDTabList
        {
            get
            {
                if ((this.mUIUI_TabManager_AutoIDTabList == null))
                {
                    this.mUIUI_TabManager_AutoIDTabList = new UIUI_TabManager_AutoIDTabList(this);
                }
                return this.mUIUI_TabManager_AutoIDTabList;
            }
        }
        #endregion

        #region Fields
        private UIUI_TabManager_AutoIDTabList mUIUI_TabManager_AutoIDTabList;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIUI_TabManager_AutoIDTabList : WpfTabList
    {

        public UIUI_TabManager_AutoIDTabList(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "UI_TabManager_AutoID";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UIStartPageTabPage UIStartPageTabPage
        {
            get
            {
                if ((this.mUIStartPageTabPage == null))
                {
                    this.mUIStartPageTabPage = new UIStartPageTabPage(this);
                }
                return this.mUIStartPageTabPage;
            }
        }
        #endregion

        #region Fields
        private UIStartPageTabPage mUIStartPageTabPage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIStartPageTabPage : WpfTabPage
    {

        public UIStartPageTabPage(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTabPage.PropertyNames.Name] = "Start Page";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UIStartPageCustom UIStartPageCustom
        {
            get
            {
                if ((this.mUIStartPageCustom == null))
                {
                    this.mUIStartPageCustom = new UIStartPageCustom(this);
                }
                return this.mUIStartPageCustom;
            }
        }
        #endregion

        #region Fields
        private UIStartPageCustom mUIStartPageCustom;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIStartPageCustom : WpfCustom
    {

        public UIStartPageCustom(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.ContentPane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Start Page";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public WpfCustom UIItemCustom
        {
            get
            {
                if ((this.mUIItemCustom == null))
                {
                    this.mUIItemCustom = new WpfCustom(this);
                    #region Search Criteria
                    this.mUIItemCustom.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.HelpWindow";
                    this.mUIItemCustom.WindowTitles.Add(TestBase.GetStudioWindowName());
                    #endregion
                }
                return this.mUIItemCustom;
            }
        }
        #endregion

        #region Fields
        private WpfCustom mUIItemCustom;
        #endregion
    }
}
