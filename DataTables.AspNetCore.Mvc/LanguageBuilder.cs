using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the language options
    /// </summary>
    public class LanguageBuilder : IJToken
    {
        LanguageOptions lg;

        /// <summary>
        /// Initialize a new instance of <see cref="LanguageBuilder"/>
        /// </summary>
        public LanguageBuilder()
        {
            this.lg = new LanguageOptions();
        }

        /// <summary>
        /// Load language information from remote file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public LanguageBuilder Url(string url)
        {
            this.lg.Url = url;
            return this;
        }

        public LanguageBuilder Decimal(string str)
        {
            this.lg.Decimal = str;
            return this;
        }

        public LanguageBuilder EmptyTable(string str)
        {
            this.lg.EmptyTable = str;
            return this;
        }

        public LanguageBuilder Info(string str)
        {
            this.lg.Info = str;
            return this;
        }

        public LanguageBuilder InfoEmpty(string str)
        {
            this.lg.InfoEmpty = str;
            return this;
        }

        public LanguageBuilder InfoFiltered(string str)
        {
            this.lg.InfoFiltered = str;
            return this;
        }

        public LanguageBuilder InfoPostFix(string str)
        {
            this.lg.InfoPostFix = str;
            return this;
        }

        public LanguageBuilder Thousands(string str)
        {
            this.lg.Thousands = str;
            return this;
        }

        public LanguageBuilder LengthMenu(string str)
        {
            this.lg.LengthMenu = str;
            return this;
        }

        public LanguageBuilder LoadingRecords(string str)
        {
            this.lg.LoadingRecords = str;
            return this;
        }

        public LanguageBuilder Processing(string str)
        {
            this.lg.Processing = str;
            return this;
        }

        public LanguageBuilder Search(string str)
        {
            this.lg.Search = str;
            return this;
        }

        public LanguageBuilder ZeroRecords(string str)
        {
            this.lg.ZeroRecords = str;
            return this;
        }

        //public LanguageBuilder Paginate(Paginate paginate)
        //{
        //    this.lg.Paginate = paginate;
        //    return this;
        //}

        //public LanguageBuilder Aria(Aria aria)
        //{
        //    this.lg.Aria = aria;
        //    return this;
        //}


        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(this.lg.Url)) jObject.Add("url", new JValue(this.lg.Url));

            if (!string.IsNullOrEmpty(this.lg.Decimal)) jObject.Add("decimal", new JValue(lg.Decimal));
            if (!string.IsNullOrEmpty(this.lg.EmptyTable)) jObject.Add("emptyTable", new JValue(this.lg.EmptyTable));
            if (!string.IsNullOrEmpty(this.lg.Info)) jObject.Add("info", new JValue(this.lg.Info));
            if (!string.IsNullOrEmpty(this.lg.InfoEmpty)) jObject.Add("infoEmpty", new JValue(this.lg.InfoEmpty));
            if (!string.IsNullOrEmpty(this.lg.InfoFiltered)) jObject.Add("infoFiltered", new JValue(this.lg.InfoFiltered));
            if (!string.IsNullOrEmpty(this.lg.InfoPostFix)) jObject.Add("infoPostFix", new JValue(this.lg.InfoPostFix));
            if (!string.IsNullOrEmpty(this.lg.Thousands)) jObject.Add("thousands", new JValue(this.lg.Thousands));
            if (!string.IsNullOrEmpty(this.lg.LengthMenu)) jObject.Add("lengthMenu", new JValue(this.lg.LengthMenu));
            if (!string.IsNullOrEmpty(this.lg.LoadingRecords)) jObject.Add("loadingRecords", new JValue(this.lg.LoadingRecords));
            if (!string.IsNullOrEmpty(this.lg.Processing)) jObject.Add("processing", new JValue(this.lg.Processing));
            if (!string.IsNullOrEmpty(this.lg.Search)) jObject.Add("search", new JValue(this.lg.Search));
            if (!string.IsNullOrEmpty(this.lg.ZeroRecords)) jObject.Add("zeroRecords", new JValue(this.lg.ZeroRecords));

            //if (this.lg.Paginate != null) jObject.Add("url", new JValue(this.lg.Url));
            //if (this.lg.Aria != null) jObject.Add("url", new JValue(this.lg.Url));





            return jObject;
        }
    }
}
