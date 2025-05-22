using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using QLThuVienMVC.ViewModels;

namespace QLThuVienMVC.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {

        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public Paging? PageModel { get; set; }
        public string? PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = string.Empty;
        public string PageClassNormal { get; set; } = string.Empty; 
        public string PageClassSelected { get; set; } = string.Empty;
        public string PageClassDisabled { get; set; } = "disabled";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");

                // === PREVIOUS BUTTON ===
                TagBuilder prevTag = new TagBuilder("a");
                bool isFirstPage = PageModel.CurrentPage <= 1;

                if (!isFirstPage)
                {
                    PageUrlValues["page"] = PageModel.CurrentPage - 1;
                    prevTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                }

                prevTag.InnerHtml.Append("« Previous");
                prevTag.AddCssClass("btn btn-outline-primary me-1");

                if (isFirstPage)
                {
                    prevTag.AddCssClass(PageClassDisabled);
                    prevTag.Attributes.Remove("href");
                }

                result.InnerHtml.AppendHtml(prevTag);

                int totalPages = PageModel.TotalPages;
                int currentPage = Math.Min(PageModel.CurrentPage, totalPages);
                PageModel.CurrentPage = currentPage;
                int range = 2;
                int minPage = Math.Max(1, currentPage - range);
                int maxPage = Math.Min(totalPages, currentPage + range);

                if (minPage > 1)
                {
                    result.InnerHtml.AppendHtml(CreatePageTag(urlHelper, 1));
                    if (minPage > 2)
                    {
                        result.InnerHtml.AppendHtml(CreateEllipsisTag());
                    }
                }

                for (int i = minPage; i <= maxPage; i++)
                {
                    result.InnerHtml.AppendHtml(CreatePageTag(urlHelper, i));
                }

                if (maxPage < totalPages)
                {
                    if (maxPage < totalPages - 1)
                    {
                        result.InnerHtml.AppendHtml(CreateEllipsisTag());
                    }
                    result.InnerHtml.AppendHtml(CreatePageTag(urlHelper, totalPages));
                }

                // === NEXT BUTTON ===
                TagBuilder nextTag = new TagBuilder("a");
                bool isLastPage = currentPage >= totalPages;

                if (!isLastPage)
                {
                    PageUrlValues["page"] = currentPage + 1;
                    nextTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                }

                nextTag.InnerHtml.Append("Next »");
                nextTag.AddCssClass("btn btn-outline-primary ms-1");

                if (isLastPage)
                {
                    nextTag.AddCssClass(PageClassDisabled);
                    nextTag.Attributes.Remove("href");
                }

                result.InnerHtml.AppendHtml(nextTag);

                // === PAGE INFO ===
                TagBuilder pageInfo = new TagBuilder("span");
                pageInfo.AddCssClass("page-info ms-2");
                pageInfo.InnerHtml.Append($"Page {currentPage} of {totalPages}");
                result.InnerHtml.AppendHtml(pageInfo);

                output.Content.AppendHtml(result.InnerHtml); ;
            }
        }

        private TagBuilder CreatePageTag(IUrlHelper urlHelper, int pageNumber)
        {
            TagBuilder tag = new TagBuilder("a");
            PageUrlValues["page"] = pageNumber;
            tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            tag.InnerHtml.Append(pageNumber.ToString());

            if (PageClassesEnabled)
            {
                tag.AddCssClass(PageClass);
                tag.AddCssClass(pageNumber == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }
            return tag;
        }

        private TagBuilder CreateEllipsisTag()
        {
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml.Append("...");
            span.AddCssClass("btn btn-light disabled");
            return span;
        }
    }
}
