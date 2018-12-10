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
    /// Represents the events builder
    /// </summary>
    public class CallbacksBuilder : IHtmlContent
    {

        List<(string key, string parameters, string functionName)> options;

        /// <summary>
        /// Initialize a new instance of <see cref="EventsBuilder"/>
        /// </summary>
        public CallbacksBuilder()
        {
            options = new List<(string key, string parameters, string functionName)>();
        }

        /// <summary>
        /// Adds or updates the event in events list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <param name="fn"></param>
        public CallbacksBuilder Add(string key, string parameters, string fn)
        {
            if (!options.Any(c => c.key == key))
            {
                options.Add((key, parameters, fn));
            }

            return this;
        }



        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            //table.on('select', function(e, dt, type, indexes) {
            //    if (type === 'row')
            //    {
            //        var data = table.rows(indexes).data().pluck('id');

            //        // do something with the ID of the selected items
            //    }
            //} );
            List<string> res = new List<string>();
            foreach (var opt in options)
            {
                res.Add($"'{opt.key}': function({ opt.parameters }) {{ {opt.functionName}({opt.parameters}); }}");
            }

            writer.Write("," + string.Join(",", res));

        }

        public List<JProperty> ToJObject()
        {
            var res = new List<JProperty>();

            foreach (var opt in options)
            {

                res.Add(new JProperty(opt.key, new JRaw($"function({ opt.parameters }) {{ {opt.functionName}({opt.parameters}); }}")));
                //res.Add($"'{opt.key}': function({ opt.parameters }) {{ {opt.functionName}({opt.parameters}); }}");
            }


            return res;
        }


    }
}
