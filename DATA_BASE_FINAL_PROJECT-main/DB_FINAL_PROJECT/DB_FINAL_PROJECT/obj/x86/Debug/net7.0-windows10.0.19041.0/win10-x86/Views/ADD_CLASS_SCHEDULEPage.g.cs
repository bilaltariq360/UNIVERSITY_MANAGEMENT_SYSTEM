﻿#pragma checksum "C:\Users\hafiz\OneDrive\Desktop\DATA_BASE_FINAL_PROJECT\DB_FINAL_PROJECT\DB_FINAL_PROJECT\Views\ADD_CLASS_SCHEDULEPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D2772FDF0C837246B1C17C8900EE3341F8A6CB707D94FA2541463DF9951707A"
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
    partial class ADD_CLASS_SCHEDULEPage : 
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
        private class ADD_CLASS_SCHEDULEPage_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IADD_CLASS_SCHEDULEPage_Bindings
        {
            private global::DB_FINAL_PROJECT.Views.ADD_CLASS_SCHEDULEPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.TeachingTip obj12;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj12TargetDisabled = false;

            public ADD_CLASS_SCHEDULEPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 32 && columnNumber == 64)
                {
                    isobj12TargetDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 12: // Views\ADD_CLASS_SCHEDULEPage.xaml line 32
                        this.obj12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TeachingTip>(target);
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

            // IADD_CLASS_SCHEDULEPage_Bindings

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
                    this.dataRoot = global::WinRT.CastExtensions.As<global::DB_FINAL_PROJECT.Views.ADD_CLASS_SCHEDULEPage>(newDataRoot);
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
            private void Update_(global::DB_FINAL_PROJECT.Views.ADD_CLASS_SCHEDULEPage obj, int phase)
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
                    // Views\ADD_CLASS_SCHEDULEPage.xaml line 32
                    if (!isobj12TargetDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(this.obj12, obj, null);
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
            case 2: // Views\ADD_CLASS_SCHEDULEPage.xaml line 9
                {
                    this.ContentArea = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // Views\ADD_CLASS_SCHEDULEPage.xaml line 11
                {
                    this.Visible1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target);
                }
                break;
            case 4: // Views\ADD_CLASS_SCHEDULEPage.xaml line 12
                {
                    this.schText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 5: // Views\ADD_CLASS_SCHEDULEPage.xaml line 13
                {
                    this.cidText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AutoSuggestBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AutoSuggestBox)this.cidText).TextChanged += this.Cid_TextChanged;
                }
                break;
            case 6: // Views\ADD_CLASS_SCHEDULEPage.xaml line 14
                {
                    this.tidText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AutoSuggestBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AutoSuggestBox)this.tidText).TextChanged += this.Tid_TextChanged;
                }
                break;
            case 7: // Views\ADD_CLASS_SCHEDULEPage.xaml line 15
                {
                    this.locText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 8: // Views\ADD_CLASS_SCHEDULEPage.xaml line 16
                {
                    this.strText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TimePicker>(target);
                }
                break;
            case 9: // Views\ADD_CLASS_SCHEDULEPage.xaml line 17
                {
                    this.endText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TimePicker>(target);
                }
                break;
            case 10: // Views\ADD_CLASS_SCHEDULEPage.xaml line 18
                {
                    this.dowText = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DropDownButton>(target);
                }
                break;
            case 11: // Views\ADD_CLASS_SCHEDULEPage.xaml line 31
                {
                    this.Insert_Button = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.Insert_Button).Click += this.InsertButton_Click;
                }
                break;
            case 12: // Views\ADD_CLASS_SCHEDULEPage.xaml line 32
                {
                    this.Error = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TeachingTip>(target);
                }
                break;
            case 13: // Views\ADD_CLASS_SCHEDULEPage.xaml line 21
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element13).Click += this.Monday_Click;
                }
                break;
            case 14: // Views\ADD_CLASS_SCHEDULEPage.xaml line 22
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element14 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element14).Click += this.Tuesday_Click;
                }
                break;
            case 15: // Views\ADD_CLASS_SCHEDULEPage.xaml line 23
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element15 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element15).Click += this.Wednesday_Click;
                }
                break;
            case 16: // Views\ADD_CLASS_SCHEDULEPage.xaml line 24
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element16 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element16).Click += this.Thursday_Click;
                }
                break;
            case 17: // Views\ADD_CLASS_SCHEDULEPage.xaml line 25
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element17 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element17).Click += this.Friday_Click;
                }
                break;
            case 18: // Views\ADD_CLASS_SCHEDULEPage.xaml line 26
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element18 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element18).Click += this.Saturday_Click;
                }
                break;
            case 19: // Views\ADD_CLASS_SCHEDULEPage.xaml line 27
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element19 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element19).Click += this.Sunday_Click;
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
            case 1: // Views\ADD_CLASS_SCHEDULEPage.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    ADD_CLASS_SCHEDULEPage_obj1_Bindings bindings = new ADD_CLASS_SCHEDULEPage_obj1_Bindings();
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

