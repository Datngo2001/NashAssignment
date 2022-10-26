using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Pages.Shared.Components.Paging
{
    [ViewComponent]
    public class Paging : ViewComponent
    {
        private readonly int TotalPageButton = 7;
        public IViewComponentResult Invoke(PagingViewModel model)
        {
            int page = model.page;
            int totalPage = model.totalPage;
            Func<int, string> getLink = model.getLink;

            bool isFirstPage = false;
            bool isLastPage = false;

            if (model.page == 1)
            {
                isFirstPage = true;
            }
            else if (page == totalPage)
            {
                isLastPage = true;
            }

            var pages = new List<PageButtonViewModel>();

            if (totalPage <= TotalPageButton)
            {
                for (int i = 1; i <= totalPage; i++)
                {
                    var isActive = "";
                    if (i == page)
                    {
                        isActive = "active";
                    }
                    pages.Add(new PageButtonViewModel
                    {
                        text = i.ToString(),
                        activeClass = isActive,
                        link = getLink(i)
                    });
                }
            }
            else if (isFirstPage == false && isLastPage == false)
            {
                pages.Add(new PageButtonViewModel
                {
                    text = "1",
                    activeClass = (page == totalPage) ? "active" : "",
                    link = getLink(1)
                });
                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });

                for (int i = page - (TotalPageButton / 2); i <= page + (TotalPageButton / 2); i++)
                {
                    var isActive = "";
                    if (i == page)
                    {
                        isActive = "active";
                    }
                    pages.Add(new PageButtonViewModel
                    {
                        text = totalPage.ToString(),
                        activeClass = isActive,
                        link = getLink(totalPage)
                    });
                }

                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });
                pages.Add(new PageButtonViewModel
                {
                    text = totalPage.ToString(),
                    activeClass = (page == totalPage) ? "active" : "",
                    link = getLink(totalPage)
                });
            }
            else if (isFirstPage == true)
            {
                pages.Add(new PageButtonViewModel
                {
                    text = "1",
                    activeClass = "active",
                    link = getLink(1)
                });
                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });

                for (int i = 2; i <= TotalPageButton - 2; i++)
                {
                    pages.Add(new PageButtonViewModel
                    {
                        text = i.ToString(),
                        activeClass = "",
                        link = getLink(i)
                    });
                }

                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });
                pages.Add(new PageButtonViewModel
                {
                    text = totalPage.ToString(),
                    activeClass = "",
                    link = getLink(totalPage)
                });
            }
            else if (isLastPage == true)
            {
                pages.Add(new PageButtonViewModel
                {
                    text = "1",
                    activeClass = "",
                    link = getLink(1)
                });
                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });

                for (int i = page - (TotalPageButton - 2); i <= totalPage - 1; i++)
                {
                    pages.Add(new PageButtonViewModel
                    {
                        text = i.ToString(),
                        activeClass = "",
                        link = getLink(i)
                    });
                }

                pages.Add(new PageButtonViewModel
                {
                    text = "...",
                });
                pages.Add(new PageButtonViewModel
                {
                    text = totalPage.ToString(),
                    activeClass = "active",
                    link = getLink(totalPage)
                });
            }

            ViewData["pages"] = pages;
            ViewData["is-first-page"] = isFirstPage;
            ViewData["is-last-page"] = isLastPage;
            ViewData["next-link"] = isLastPage ? "" : getLink(page + 1);
            ViewData["prev-link"] = isFirstPage ? "" : getLink(page - 1);
            return View();
        }
    }
}