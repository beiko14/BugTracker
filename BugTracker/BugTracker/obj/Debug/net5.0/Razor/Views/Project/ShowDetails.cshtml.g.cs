#pragma checksum "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86fac3919a62e0c75564764206482ddb48c57342"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_ShowDetails), @"mvc.1.0.view", @"/Views/Project/ShowDetails.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\_ViewImports.cshtml"
using BugTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\_ViewImports.cshtml"
using BugTracker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86fac3919a62e0c75564764206482ddb48c57342", @"/Views/Project/ShowDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"415cd50ac37814e1a4fb76bf7d07627084cdfa27", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_ShowDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/theme/vendor/datatables/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/theme/vendor/datatables/dataTables.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/theme/js/datatable-searchUnSo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/theme/vendor/datatables/dataTables.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
  
    ViewData["Title"] = "Projekte";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content Wrapper -->
<div id=""content-wrapper"" class=""d-flex flex-column"">

    <!-- Main Content -->
    <div id=""content"">

        <!-- Begin Page Content -->
        <div class=""container-fluid"">



            <!-- Page Heading -->
            <h1 class=""h3 mb-2 text-gray-800"">Detailansicht: Projekt</h1>
            <p></p>

            <!-- Basic Card Example -->
            <div class=""card shadow mb-4"">
                <div class=""card-header py-3"">
                    <h6 class=""m-0 font-weight-bold text-primary"">");
#nullable restore
#line 25 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                             Write(Model.foundProject.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    <p></p>\r\n                    <a class=\"btn btn-primary btn-icon-split btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 742, "\"", 815, 1);
#nullable restore
#line 27 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
WriteAttributeValue("", 749, Url.Action("Edit", "Project", new { id = Model.foundProject.Id }), 749, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span class=\"text\">Bearbeiten</span>\r\n                    </a>\r\n                    &nbsp;\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86fac3919a62e0c75564764206482ddb48c573427292", async() => {
                WriteLiteral("Zurück zur Liste");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    &nbsp;\r\n                    <a class=\"btn btn-danger btn-circle btn-sm\" data-toggle=\"modal\" data-target=\"#deleteModal\"");
            BeginWriteAttribute("href", " href=\"", 1137, "\"", 1212, 1);
#nullable restore
#line 33 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
WriteAttributeValue("", 1144, Url.Action("Delete", "Project", new { id = Model.foundProject.Id }), 1144, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                        <i class=""fas fa-trash""></i>
                    </a>
                </div>
                <div class=""card-body"">

                    <!-- Page Heading -->
                    <p class=""mb-2"">Beschreibung:</p>
                    <p class=""mb-4"">
                        ");
#nullable restore
#line 42 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                   Write(Model.foundProject.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>

                    <div class=""row"">
                        <div class=""col-lg-4"">
                            <!-- DataTales Example -->
                            <div class=""card shadow mb-4"">
                                <div class=""card-header py-3"">
                                    <h6 class=""m-0 font-weight-bold text-primary"">Zugewiesene Personen</h6>
                                    Derzeitige Nutzer des Projektes:
                                </div>
                                <div class=""card-body"">
                                    <div class=""table-responsive"">
                                        <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Email
                                 ");
            WriteLiteral(@"                   </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Rolle
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
");
#nullable restore
#line 70 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                 foreach (UserModel item in Model.foundData)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 74 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 77 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 80 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 83 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class=""col-lg-8"">
                            <!-- DataTales Example -->
                            <div class=""card shadow mb-4"">
                                <div class=""card-header py-3"">
                                    <h6 class=""m-0 font-weight-bold text-primary"">Tickets für dieses Projekt</h6>
                                    Zusammenfassung der Ticketdetails:
                                </div>
                                <div class=""card-body"">
                                    <div class=""table-responsive"">
                                        <table class=""table table-bordered"" id=""dataTableDetails2"" width=""100%"" cellspacing=""0"">
                                            <thead>
   ");
            WriteLiteral(@"                                             <tr>
                                                    <th>
                                                        Titel
                                                    </th>
                                                    <th>
                                                        Ersteller
                                                    </th>
                                                    <th>
                                                        Entwickler
                                                    </th>
                                                    <th>
                                                        Status
                                                    </th>
                                                    <th>
                                                        Erstellt am:
                                                    </th>
                                                    <th>");
            WriteLiteral("</th>\r\n                                                </tr>\r\n                                            </thead>\r\n                                            <tbody>\r\n");
#nullable restore
#line 122 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                 foreach (TicketModel item in Model.foundTickets)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 126 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.TicketName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 129 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.Submitter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 132 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.Dev);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 135 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.TicketStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n                                                            ");
#nullable restore
#line 138 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(item.TicketStart);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                        <td>\r\n");
            WriteLiteral("                                                            ");
#nullable restore
#line 142 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                       Write(Html.ActionLink("Mehr Details", "ShowDetails", "Ticket", new { id = item.TicketId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 145 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>





        </div>
        <!-- /.container-fluid -->

    </div>
    <!-- End of Main Content -->

</div>
<!-- End of Content Wrapper -->
<!-- Logout Modal-->
<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">");
#nullable restore
#line 175 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
                                                          Write(Model.foundProject.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" wirklich löschen?</h5>
                <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">×</span>
                </button>
            </div>
            <div class=""modal-body"">Wählen Sie ""Löschen"", wenn Sie dieses Projekt entgültig löschen möchten.</div>
            <div class=""modal-footer"">
                <button class=""btn btn-secondary"" type=""button"" data-dismiss=""modal"">Abbrechen</button>
                <a class=""btn btn-primary""");
            BeginWriteAttribute("href", " href=\"", 9365, "\"", 9440, 1);
#nullable restore
#line 183 "C:\Users\Nutzer1\source\repos\BugTracker\BugTracker\BugTracker\Views\Project\ShowDetails.cshtml"
WriteAttributeValue("", 9372, Url.Action("Delete", "Project", new { id = Model.foundProject.Id }), 9372, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Löschen</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<!-- Page level plugins -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86fac3919a62e0c75564764206482ddb48c5734221706", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86fac3919a62e0c75564764206482ddb48c5734222746", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Page level custom scripts -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86fac3919a62e0c75564764206482ddb48c5734223828", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Custom styles for this page -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "86fac3919a62e0c75564764206482ddb48c5734224912", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591