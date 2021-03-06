﻿using Examine.Providers;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace Our.Umbraco.Look.BackOffice.Services
{
    /// <summary>
    /// common place for static helpers to get css class names for icons
    /// </summary>
    internal static class IconService
    {
        /// <summary>
        /// The icon for a searcher varies dependent on its state
        /// </summary>
        /// <param name="searcher"></param>
        /// <returns></returns>
        internal static string GetSearcherIcon(BaseSearchProvider searcher)
        {
            if (searcher is LookSearcher)
            {
                return "icon-files";
            }
            else // must be an examine one
            {
                var name = searcher.Name.TrimEnd("Searcher");

                if (LookConfiguration.ExamineIndexers.Select(x => x.TrimEnd("Indexer")).Any(x => x == name))
                {
                    return "icon-categories";
                }
                else // not hooked in 
                {
                    return "icon-file-cabinet";
                }
            }

        }

        internal static string GetNodeTypeIcon(PublishedItemType nodeType)
        {
            return nodeType == PublishedItemType.Content ? "icon-umb-content"
            : nodeType == PublishedItemType.Media ? "icon-umb-media"
            : nodeType == PublishedItemType.Member ? "icon-umb-members"
            : null;
        }

        /// <summary>
        /// gets the icon associated with the docType, mediaType or memberType (by alias)
        /// </summary>
        /// <param name="nodeType">whether it's a node, media or member</param>
        /// <param name="isDetached">flag indicating the item is detached (so will always be a document type_</param>
        /// <param name="alias">alias of the node, media or member type</param>
        /// <returns></returns>
        internal static string GetAliasIcon(PublishedItemType nodeType, bool isDetached, string alias)
        {
            string icon = null;

            try
            {
                if (nodeType == PublishedItemType.Content || isDetached)
                {
                    var contentType = ApplicationContext.Current.Services.ContentTypeService.GetContentType(alias);

                    icon = contentType.Icon;
                }
                else
                {
                    switch (nodeType)
                    {
                        case PublishedItemType.Media:

                            var mediaType = ApplicationContext.Current.Services.ContentTypeService.GetMediaType(alias);

                            icon = mediaType.Icon;

                            break;

                        case PublishedItemType.Member:

                            var memberType = ApplicationContext.Current.Services.MemberTypeService.Get(alias);

                            icon = memberType.Icon;

                            break;
                    }
                }
            }
            catch
            {
                icon = "icon-alert-alt";
            }

            return icon;
        }
    }
}
