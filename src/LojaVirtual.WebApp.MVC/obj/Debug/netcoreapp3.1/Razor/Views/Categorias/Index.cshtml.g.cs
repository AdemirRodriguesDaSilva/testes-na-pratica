#pragma checksum "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6f504a910608b03a1076387f441761240378311"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categorias_Index), @"mvc.1.0.view", @"/Views/Categorias/Index.cshtml")]
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
#line 1 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\_ViewImports.cshtml"
using LojaVirtual.WebApp.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\_ViewImports.cshtml"
using LojaVirtual.WebApp.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6f504a910608b03a1076387f441761240378311", @"/Views/Categorias/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6355713c995d4b1c8acfcfeebbd0e1b0e431e17", @"/Views/_ViewImports.cshtml")]
    public class Views_Categorias_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LojaVirtual.Cadastro.Application.Categorias.ViewModel.CategoriaViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Categorias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdicionarCategoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtualizarCategoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    h4 {
        font-weight: 600;
    }

    p {
        font-size: 12px;
        margin-top: 5px;
    }

    .price {
        font-size: 30px;
        margin: 0 auto;
        color: #333;
    }

    .right {
        float: right;
        border-bottom: 2px solid #4B8E4B;
    }

    .thumbnail {
        opacity: 0.70;
        -webkit-transition: all 0.5s;
        transition: all 0.5s;
    }

        .thumbnail:hover {
            opacity: 1.00;
            box-shadow: 0px 0px 10px #4bc6ff;
        }

    .line {
        margin-bottom: 5px;
    }

    ");
            WriteLiteral(@"@media screen and (max-width: 770px) {
        .right {
            float: left;
            width: 100%;
        }
    }

    .product_view .modal-dialog {
        max-width: 800px;
        width: 100%;
    }

    .pre-cost {
        text-decoration: line-through;
        color: #a5a5a5;
    }

    .space-ten {
        padding: 10px 0;
    }
</style>
<div class=""container"">

    <h1>Administração de Categorias</h1>
    <hr />
    <div class=""row"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6f504a910608b03a1076387f4417612403783115718", async() => {
                WriteLiteral("+ Adicionar Novo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <hr />
    <div class=""row"">

        <div class=""col-md-3 col-sm-6"">
            <table>
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Código</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 79 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml"
                      
                        foreach (var categoria in Model.OrderBy(c => c.Nome))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 83 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml"
                               Write(categoria.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 84 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml"
                               Write(categoria.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6f504a910608b03a1076387f4417612403783118593", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml"
                                                                                                      WriteLiteral(categoria.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 87 "C:\Users\ademi\Desktop\Cursos\Exercícios Práticos\LojaVirtual\src\LojaVirtual.WebApp.MVC\Views\Categorias\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n");
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LojaVirtual.Cadastro.Application.Categorias.ViewModel.CategoriaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
