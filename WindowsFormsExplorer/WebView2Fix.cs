/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Reflection;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// <see cref="WebView2"/> has a bug that causes it to flicker when disposed.  This is tracked by the 
    /// WebView2 team (see below link) and intended to be fixed, but it hasn't been as of this writing.  
    /// This derived class is a workaround to fix the flickering for now (workaround also from below link).
    /// https://github.com/MicrosoftEdge/WebView2Feedback/issues/650
    /// </summary>
    public class WebView2Fix : WebView2
    {
        protected override void OnHandleDestroyed(EventArgs e)
        {
            var controller = typeof(WebView2).GetField("_coreWebView2Controller", BindingFlags.Instance | 
                BindingFlags.NonPublic).GetValue(this) as CoreWebView2Controller;
            controller.IsVisible = false;
            base.OnHandleDestroyed(e);
        }
    }
}
