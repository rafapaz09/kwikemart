#pragma checksum "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05ad19510129ae79626ce726ed0dc9e7e53c81f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductListDetail), @"mvc.1.0.view", @"/Views/Home/ProductListDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ProductListDetail.cshtml", typeof(AspNetCore.Views_Home_ProductListDetail))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\_ViewImports.cshtml"
using Kwikemart_APP;

#line default
#line hidden
#line 2 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\_ViewImports.cshtml"
using Kwikemart_APP.Models;

#line default
#line hidden
#line 3 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\_ViewImports.cshtml"
using Kwikemart_APP.Helpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05ad19510129ae79626ce726ed0dc9e7e53c81f5", @"/Views/Home/ProductListDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd107f690c375df8a0850b4600e012af564f9ca1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductListDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Kwikemart_APP.Models.Products>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
 if(Model != null && Model.Count > 0)
{
    

#line default
#line hidden
#line 4 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
            BeginContext(126, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(157, 9, false);
#line 7 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
           Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(166, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(190, 10, false);
#line 8 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
           Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(200, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(224, 15, false);
#line 9 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
           Write(item.Popularity);

#line default
#line hidden
            EndContext();
            BeginContext(239, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 11 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
    }

#line default
#line hidden
#line 11 "C:\Users\rjpazs\source\repos\kwikemart\Kwikemart_APP\Kwikemart_APP\Views\Home\ProductListDetail.cshtml"
     
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Kwikemart_APP.Models.Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591