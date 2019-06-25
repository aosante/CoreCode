using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CoreCode.Web.UI.Models.HtmlComponents;

namespace CoreCode.Web.UI.Models.Helpers
{
    public static class HtmlComponentHelper
    {

        public static HtmlString GenericButton(this HtmlHelper helper, string htmlId, string customCssClasses, string buttonValue,
            string buttonColor = "", string buttonHoverColor = "")
        {
            var genericButton = new GenericButtonHtmlComponent
            {
                Id = htmlId,
                ButtonValue = buttonValue,
                Color = buttonColor,
                HoverColor = buttonHoverColor,
                CustomCssClasses = customCssClasses
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/GenericButton.cshtml", genericButton).ToString());
        }



        public static HtmlString GetConfirmButton(this HtmlHelper helper, string htmlId, string scriptFunction, string scriptInstanceName, string parameters, string text = "Aceptar")
        {
            return GetButton(helper, htmlId, scriptFunction, scriptInstanceName, parameters, "btn btn-outline-success", "", text);


        }


        public static HtmlString GetButton(this HtmlHelper helper, string htmlId, string scriptFunction, string scriptInstanceName, string parameters, string boostrapClasses, string customCssClasses = "", string text = "Aceptar")
        {
            var confirmBtnComponent = new ConfirmButtonHtmlComponent(htmlId, boostrapClasses)
            {
                ButtonValue = text,
                ScriptFunction = scriptFunction,
                ScriptInstanceName = scriptInstanceName,
                ScriptParameters = parameters,
                CustomCssClasses = customCssClasses
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/ConfirmButton.cshtml", confirmBtnComponent).ToString());
        }

        public static HtmlString GetTable(this HtmlHelper helper, string htmlId,
            string viewName, string functionName, string customClasses, List<string> columnHeaders, List<string> columnsTitle)
        {
            var tableContentModel = new TableHtmlComponent()
            {
                Id = htmlId,
                ViewName = viewName,
                OnSelectFunctionName = functionName,
                TableHeaderColumns = columnHeaders,
                CustomCssClasses = customClasses,
                Columns = columnsTitle
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/Table.cshtml", tableContentModel).ToString());
        }

        public static HtmlString GetSelectDropdown(this HtmlHelper helper, string elementId, string viewName, string onSelectFunction, string onLoadFunction = "",
            string columnDataName = "", Dictionary<string, string> listOfOptions = null, string cssClasses = "")
        {
            var dropdownModel = new SelectDropdownHtmlComponent()
            {
                Id = elementId,
                ViewName = viewName,
                OnChangeFunction = onSelectFunction,
                OptionList = listOfOptions,
                ColumnDataName = columnDataName,
                OnLoadFunction = onLoadFunction,
                CustomCssClasses = cssClasses
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/SelectDropdown.cshtml", dropdownModel).ToString());
        }

        public static HtmlString GetSmallModal(this HtmlHelper helper)
        {
            return new HtmlString(helper.Partial("~/Views/PartialViews/SmallModal.cshtml").ToString());
        }

        public static HtmlString GetBigModal(this HtmlHelper helper, string partialPathToRender, string formId, string title = "", bool showGenericCloseButtons = false)
        {
            var modalComponent = new BigModalHtmlComponent
            {
                Id = formId,
                PartialPathToRenderContent = partialPathToRender,
                Title = title,
                ShowGenericCloseButtons = showGenericCloseButtons 
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/BigModal.cshtml", modalComponent).ToString());
        }

        public static HtmlString GetButtonModal(this HtmlHelper helper)
        {
            var modalHtmlComponent = new ModalHtmlComponent
            {
                ModalContent = new HtmlString(@"
                <div>Cesar</div>")
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/ButtonModal.cshtml", modalHtmlComponent).ToString());
        }

        public static HtmlString GetForm(this HtmlHelper helper)
        {
            return new HtmlString(helper.Partial("~/Views/PartialViews/Form.cshtml").ToString());
        }

        public static HtmlString GetCancelButton(this HtmlHelper helper, string htmlId)
        {
            var cancelButtonComponent = new ConfirmButtonHtmlComponent(htmlId, "btn btn-outline-success")
            {
                ButtonValue = "Cancelar"
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/CancelButton.cshtml", cancelButtonComponent).ToString());
        }

        public static HtmlString GetAlert(this HtmlHelper helper)
        {
            return new HtmlString(helper.Partial("~/Views/PartialViews/Alert.cshtml").ToString());
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A HtmlHelper extension method that gets an input. </summary>
        ///
        /// <remarks>   Celopez </remarks>
        ///
        /// <param name="helper">       The helper to act on. </param>
        /// <param name="elementId">    Identifier for the element. </param>
        /// <param name="inputType">    Type of the input. </param>
        /// <param name="label">        The label. </param>
        /// <param name="placeHolder">  The place holder. </param>
        ///
        /// <returns>   The input. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static HtmlString GetInputWithLabel(this HtmlHelper helper, string elementId,
            string inputType, string label, string extraCssClasses, string placeHolder, string columnData,
            bool required = false, bool disabled = false)
        {
            var componentModel = new InputHtmlComponent
            {
                Id = elementId,
                Type = inputType,
                PlaceHolder = placeHolder,
                Label = label,
                Required = required,
                CustomCssClasses = extraCssClasses,
                ColumnDataName = columnData,
                IsDisabled = disabled
            };
            return new HtmlString(helper.Partial("~/Views/PartialViews/Input.cshtml", componentModel).ToString());
        }

        public static HtmlString GetDateTimePicker(this HtmlHelper helper)
        {
            return new HtmlString(helper.Partial("~/Views/PartialViews/DateTimePicker.cshtml").ToString());
        }

    }
}