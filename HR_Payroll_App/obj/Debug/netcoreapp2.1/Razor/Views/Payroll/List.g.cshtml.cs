#pragma checksum "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d816807f87e8cefe507f995774c786631b78d77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payroll_List), @"mvc.1.0.view", @"/Views/Payroll/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payroll/List.cshtml", typeof(AspNetCore.Views_Payroll_List))]
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
#line 1 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\_ViewImports.cshtml"
using HR_Payroll_App.Models.ClassModel;

#line default
#line hidden
#line 2 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\_ViewImports.cshtml"
using HR_Payroll_App.Models;

#line default
#line hidden
#line 3 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\_ViewImports.cshtml"
using HR_Payroll_App.Models.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d816807f87e8cefe507f995774c786631b78d77", @"/Views/Payroll/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc4dd34d8c428a2b2a966d7a2018ee918fbd16a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Payroll_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Employee_Branch_position_SalaryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 507, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">

            <table class=""table text-white"">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Sirket</th>
                        <th>Vezife</th>
                        <th>Maas</th>
                        <th>Yekun Maas</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 19 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(638, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(701, 11, false);
#line 22 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                           Write(item.E_name);

#line default
#line hidden
            EndContext();
            BeginContext(712, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(752, 14, false);
#line 23 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                           Write(item.E_surname);

#line default
#line hidden
            EndContext();
            BeginContext(766, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(806, 15, false);
#line 24 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                           Write(item.BranchName);

#line default
#line hidden
            EndContext();
            BeginContext(821, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(861, 17, false);
#line 25 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                           Write(item.PositionName);

#line default
#line hidden
            EndContext();
            BeginContext(878, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(918, 11, false);
#line 26 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                           Write(item.Salary);

#line default
#line hidden
            EndContext();
            BeginContext(929, 59, true);
            WriteLiteral("</td>\r\n                            <td class=\"totalSalary\">");
            EndContext();
            BeginContext(989, 16, false);
#line 27 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                                               Write(item.TotalSalary);

#line default
#line hidden
            EndContext();
            BeginContext(1005, 112, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <input type=\"checkbox\" class=\"checkVal\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1117, "\"", 1135, 1);
#line 29 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
WriteAttributeValue("", 1125, item.E_Id, 1125, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1136, 71, true);
            WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 32 "C:\Users\HP\source\repos\Hr_Payroll\HR_Payroll_App\Views\Payroll\List.cshtml"
                    }

#line default
#line hidden
            BeginContext(1230, 171, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n            \r\n                <button class=\"btnCalc\" name=\"selected\">Calc</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1418, 1901, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        $("".btnCalc"").click(function () {

            var myCheckboxes = new Array();
            $("".checkVal:checked"").each(function () {
                $(this).parent().prev().attr(""data-employeeid"", $(this).val());
                myCheckboxes.push($(this).val());
            });
            $.ajax
                (
                {
                    url: ""/Payroll/Calculate"",
                    type: ""POST"",
                        data: { 'id': myCheckboxes },
                        success: function (data) {

                            $("".col-lg-12"").html(data);
                            
                            //$("".totalSalary"").each(function () {

                            //    if ($(this).next().children().is(':checked')) {
                            //        $.each(data, function (item, key) {
                            //            alert(key);
                            //            //if ($("".totalSalary"").dat");
                WriteLiteral(@"a(""employeeid"") == key) {
                            //            //    alert($("".totalSalary"").data(""employeeid""));
                            //            //    $("".totalSalary"").text(item);
                            //            //}
                            //        });                                    
                            //    }
                            //});

                            //if ($(this).next().children())
                                //    alert($(this).data(""employeeid""));


                                //$("".totalSalary"").data(""emplyeeid"")
                           
                            //data.forEach(function (item) {
                                   
                            //});           
                    }
                }
                )
        })

    </script>

");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Employee_Branch_position_SalaryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
