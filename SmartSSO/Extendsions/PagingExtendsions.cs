using System.Text;
using System.Web.Mvc;

namespace SmartSSO.Extendsions
{
    public static class PagingExtendsions
    {
        /// <summary>
        /// 分页工具栏
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sizeCount">记录总数</param>
        /// <param name="startPageNum">起始页码：默认1</param>
        /// <param name="pageOfNumber">每页页码个数：默认10</param>
        /// <param name="queryString">queryString查询参数</param>
        /// <returns></returns>
        public static MvcHtmlString Paging(this HtmlHelper htmlHelper, int pageIndex = 0, int pageSize = 10, int sizeCount = 0, int startPageNum = 1, int pageOfNumber = 10, string queryString = "")
        {
            //第一页，上一页 ... 5，6，7，8，9 ... 下一页，最后一页，转到{0}页，确定

            //计算出总页数
            var pageCount = sizeCount % pageSize == 0 ? sizeCount / pageSize : sizeCount / pageSize + 1;

            //如果只有一页不需要分页
            if (pageCount == 1) return new MvcHtmlString("");

            var pagedHtmlString = new StringBuilder();
            pagedHtmlString.Append("<ul class='pagination'>");

            //第一页
            if (pageIndex > startPageNum)
            {
                pagedHtmlString.AppendFormat("<li><a href='?pageindex={0}&pagesize={1}&{2}' title='第一页'>第一页</a></li>",
                    startPageNum,
                    pageSize,
                    queryString);
            }
            else
            {
                pagedHtmlString.Append("<li class='disabled'><a href='#' title='第一页'>第一页</a></li>");
            }


            //上一页
            if (pageIndex - 1 >= startPageNum && pageIndex - 1 <= pageCount)
            {
                pagedHtmlString.AppendFormat("<li><a href='?pageindex={0}&pagesize={1}&{2}' title='上一页'>上一页</a></li>",
                    pageIndex - 1,
                    pageSize,
                    queryString);
            }
            else
            {
                pagedHtmlString.Append("<li class='disabled'><a href='#' title='上一页'>上一页</a></li>");
            }

            //当前页
            var pageItem = pageOfNumber - 1 >= startPageNum ? pageOfNumber - 1 : startPageNum;
            var pageStartIndex = pageIndex - pageItem / 2 >= startPageNum ? pageIndex - pageItem / 2 : startPageNum;
            var pageEndIndex = pageIndex + pageItem / 2 <= pageCount ? pageIndex + pageItem / 2 : pageCount;

            //尽量平均分配分页按钮的数量
            var offset = pageItem - (pageEndIndex - pageStartIndex);
            if (offset > 0)
            {
                var leftPatch = pageStartIndex - offset > startPageNum;
                if (leftPatch)
                {
                    //向前扩展
                    pageStartIndex = pageStartIndex - offset;
                }
                else
                {
                    //向后扩展
                    pageEndIndex = pageEndIndex + offset < pageCount ? pageEndIndex + offset : pageEndIndex;
                }
            }

            for (var i = pageStartIndex; i < pageEndIndex; i++)
            {
                if (i == pageIndex)
                {
                    pagedHtmlString.AppendFormat("<li class='active'><a href='#' title='当前页'>{0}<span class='sr-only'>(current)</span></a></li>",
                        pageIndex + 1);
                }
                else
                {
                    pagedHtmlString.AppendFormat("<li><a href='?pageindex={0}&pagesize={1}&{2}' title='第{3}页'>{4}</a></li>",
                        i,
                        pageSize,
                        queryString,
                        i,
                        i + 1);
                }
            }

            //下一页
            if (pageIndex + 1 >= startPageNum && pageIndex + 1 < pageCount)
            {
                pagedHtmlString.AppendFormat("<li ><a href='?pageindex={0}&pagesize={1}&{2}' title='下一页'>下一页</a></li>",
                    pageIndex + 1,
                    pageSize,
                    queryString);
            }
            else
            {
                pagedHtmlString.Append("<li class='disabled'><a href='#' title='下一页'>下一页</a></li>");
            }

            //最后一页
            if (pageCount > pageIndex + 1)
            {
                pagedHtmlString.AppendFormat("<li ><a href='?pageindex={0}&pagesize={1}&{2}' title='最后一页'>最后一页</a></li>",
                    pageCount - 1,
                    pageSize,
                    queryString);
            }
            else
            {
                pagedHtmlString.Append("<li class='disabled'><a href='#' title='最后一页'>最后一页</a></li>");
            }


            pagedHtmlString.Append("</ul>");

            return new MvcHtmlString(pagedHtmlString.ToString());
        }

        /// <summary>
        /// 分页工具栏
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sizeCount">记录总数</param>
        /// <param name="queryString">queryString查询参数</param>
        /// <returns></returns>
        public static MvcHtmlString Paging(this HtmlHelper htmlHelper, int pageIndex = 0, int pageSize = 10, int sizeCount = 0, string queryString = "")
        {
            return Paging(htmlHelper, pageIndex, pageSize, sizeCount, 0, 10, queryString);
        }
    }
}