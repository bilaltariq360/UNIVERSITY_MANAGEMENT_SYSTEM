﻿#pragma checksum "C:\Users\hafiz\OneDrive\Desktop\DATA_BASE_FINAL_PROJECT\DB_FINAL_PROJECT\DB_FINAL_PROJECT\Views\ADD_STUDENTPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B3ACB879A3A2E964C0237CC1788079B8460FEAE002B3092ECB62EF509A2CE9FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_FINAL_PROJECT.Views
{
    partial class ADD_STUDENTPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(global::Microsoft.UI.Xaml.Controls.TeachingTip obj, global::Microsoft.UI.Xaml.FrameworkElement value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.FrameworkElement) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.FrameworkElement), targetNullValue);
                }
                obj.Target = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ADD_STUDENTPage_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IADD_STUDENTPage_Bindings
        {
            private global::DB_FINAL_PROJECT.Views.ADD_STUDENTPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.TeachingTip obj15;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj15TargetDisabled = false;

            public ADD_STUDENTPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 51 && columnNumber == 64)
                {
                    isobj15TargetDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 15: // Views\ADD_STUDENTPage.xaml line 51
                        this.obj15 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TeachingTip>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IADD_STUDENTPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::DB_FINAL_PROJECT.Views.ADD_STUDENTPage>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::DB_FINAL_PROJECT.Views.ADD_STUDENTPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Insert_Button(obj.Insert_Button, phase);
                    }
                }
            }
            private void Update_Insert_Button(global::Microsoft.UI.Xaml.Controls.Button obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ADD_STUDENTPage.xaml line 51
                    if (!isobj15TargetDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(this.obj15, obj, null);
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\ADD_STUDENTPage.xaml line 9
                {
                    this.ContentArea = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // Views\ADD_STUDENTPage.xaml line 11
                {
                    this.Visible1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target);
                }
                break;
            case 4: // Views\ADD_STUDENTPage.xaml line 12
                {
                    this.rollText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 5: // Views\ADD_STUDENTPage.xaml line 13
                {
                    this.fnameText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 6: // Views\ADD_STUDENTPage.xaml line 14
                {
                    this.lnameText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 7: // Views\ADD_STUDENTPage.xaml line 15
                {
                    this.contactText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 8: // Views\ADD_STUDENTPage.xaml line 16
                {
                    this.addText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 9: // Views\ADD_STUDENTPage.xaml line 17
                {
                    this.passText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.PasswordBox>(target);
                }
                break;
            case 10: // Views\ADD_STUDENTPage.xaml line 18
                {
                    this.regText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DatePicker>(target);
                }
                break;
            case 11: // Views\ADD_STUDENTPage.xaml line 19
                {
                    this.genText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DropDownButton>(target);
                }
                break;
            case 12: // Views\ADD_STUDENTPage.xaml line 28
                {
                    this.feeText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DropDownButton>(target);
                }
                break;
            case 13: // Views\ADD_STUDENTPage.xaml line 36
                {
                    this.bgText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DropDownButton>(target);
                }
                break;
            case 14: // Views\ADD_STUDENTPage.xaml line 50
                {
                    this.Insert_Button = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.Insert_Button).Click += this.InsertButton_Click;
                }
                break;
            case 15: // Views\ADD_STUDENTPage.xaml line 51
                {
                    this.Error = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TeachingTip>(target);
                }
                break;
            case 16: // Views\ADD_STUDENTPage.xaml line 39
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element16 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element16).Click += this.BGAPositive_Click;
                }
                break;
            case 17: // Views\ADD_STUDENTPage.xaml line 40
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element17 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element17).Click += this.BGANegative_Click;
                }
                break;
            case 18: // Views\ADD_STUDENTPage.xaml line 41
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element18 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element18).Click += this.BGBPositive_Click;
                }
                break;
            case 19: // Views\ADD_STUDENTPage.xaml line 42
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element19 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element19).Click += this.BGBNegative_Click;
                }
                break;
            case 20: // Views\ADD_STUDENTPage.xaml line 43
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element20 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element20).Click += this.BGABPositive_Click;
                }
                break;
            case 21: // Views\ADD_STUDENTPage.xaml line 44
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element21 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element21).Click += this.BGABNegative_Click;
                }
                break;
            case 22: // Views\ADD_STUDENTPage.xaml line 45
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element22 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element22).Click += this.BGOBPositive_Click;
                }
                break;
            case 23: // Views\ADD_STUDENTPage.xaml line 46
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element23 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element23).Click += this.BGOBNegative_Click;
                }
                break;
            case 24: // Views\ADD_STUDENTPage.xaml line 31
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element24 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element24).Click += this.FeePaid_Click;
                }
                break;
            case 25: // Views\ADD_STUDENTPage.xaml line 32
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element25 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element25).Click += this.FeeUnpaid_Click;
                }
                break;
            case 26: // Views\ADD_STUDENTPage.xaml line 22
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element26 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element26).Click += this.GenderMale_Click;
                }
                break;
            case 27: // Views\ADD_STUDENTPage.xaml line 23
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element27 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element27).Click += this.GenderFemale_Click;
                }
                break;
            case 28: // Views\ADD_STUDENTPage.xaml line 24
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element28 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element28).Click += this.GenderOther_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\ADD_STUDENTPage.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    ADD_STUDENTPage_obj1_Bindings bindings = new ADD_STUDENTPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

