using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartWizardProject.Persistences.Domain.Enums
{
    public static class EnumUtils
    {

        /// <summary>
        /// Add all the enum item to select list.
        /// </summary>
        /// <typeparam name="T">T constrains as enum type.</typeparam>
        /// <param name="optionText"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public static IList<SelectListItem> ToSelectList<T>(T? selected = null, string optionText = null) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new TypeAccessException(string.Format("The type: \"{0}\" is not a Enum type.", type.Name));
            }

            var enumArray = new ReadOnlyCollection<T>((T[])Enum.GetValues(typeof(T)));
            Func<T, bool> s = x => selected != null && selected.Value.Equals(x);
            return enumArray.ToSelectList(x => x.ToString(), x => (int)((object)x), s, optionText);
        }

         
        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, Func<T, bool> selected, string optionalText)
        {
            return source.ToSelectList(text, value, selected, optionalText, string.Empty);
        }

        public static IList<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, Func<T, bool> selected, string optionalText, string optionalValue)
        {
            if (string.IsNullOrEmpty(optionalValue))
            {
                optionalValue = "-32767";
            }

            var items = new List<SelectListItem>();
            if (source == null)
            {
                return items;
            }
            foreach (var entity in source)
            {
                var item = new SelectListItem();
                item.Text = text(entity).ToString();
                item.Value = value(entity).ToString();
                if (selected != null)
                {
                    item.Selected = selected(entity);
                }

                if (item.Value != optionalValue)
                {
                    items.Add(item);
                }
            }
            items = items.OrderBy(d => d.Text).ToList();          

            if (!string.IsNullOrEmpty(optionalText))
            {
                items.Insert(0, new SelectListItem() { Text = optionalText, Value = optionalValue });
            }
            return items;
        }
    }
}