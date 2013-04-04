using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace General
{
    public class RequestPage
    {
        public RequestPage()
        {
        }

        public static Data Form(HttpRequest request)
        {
            Data parameters = new Data();
            int count = request.Form.Count;
            int pCount = 0;

            string key = null;
            string[] value = null;

            for (int i = 0; i < count; i++)
            {
                key = request.Form.GetKey(i);

                if (key.IndexOf("__") == 0)
                {
                    continue;
                }

                int keyIndex = key.LastIndexOf("$") + 1;

                if (keyIndex > 0)
                {
                    key = key.Substring(keyIndex, key.Length - keyIndex);
                }

                if (key.IndexOf("Btn") != -1)
                {
                    continue;
                }

                if (key.IndexOf("_ClientState") != -1)
                {
                    continue;
                }

                if (key.Length < 1)
                {
                    continue;
                }

                value = request.Form.GetValues(i);
                pCount = value.Length;
                if (value != null)
                {
                    if (key.Equals("now"))
                    {
                        parameters.Now = int.Parse(value[0]);
                    }

                    else
                    {
                        for (int j = 0; j < pCount; j++)
                        {
                            if (key.Equals("date")) //add time to date
                            {
                                DateTime date = DateTime.Parse(value[j]);
                                value[j] = date.ToString();
                            }
                            parameters.add(j, key, value[j]);
                        }
                    }
                }
            }
            return parameters;


        }

        public static Data Param(HttpRequest request)
        {
            Data parameters = new Data();
            int count = request.Params.Count;
            int pCount = 0;

            string key = null;
            string[] value = null;

            for (int i = 0; i < count; i++)
            {
                key = request.Params.GetKey(i);

                if (key == null)
                {
                    continue;
                }

                if (key.IndexOf("__") == 0)
                {
                    continue;
                }

                int keyIndex = key.LastIndexOf("$") + 1;

                if (keyIndex > 0)
                {
                    key = key.Substring(keyIndex, key.Length - keyIndex);
                }

                if (key.IndexOf("Btn") != -1)
                {
                    continue;
                }

                if (key.IndexOf("_ClientState") != -1)
                {
                    continue;
                }

                if (key.Length < 1)
                {
                    continue;
                }

                value = request.Params.GetValues(i);
                pCount = value.Length;
                if (value != null)
                {
                    if (key.Equals("now"))
                    {
                        parameters.Now = int.Parse(value[0]);
                    }

                    else
                    {
                        for (int j = 0; j < pCount; j++)
                        {
                            if (key.Equals("date")) //add time to date
                            {
                                DateTime date = DateTime.Parse(value[j]);
                                value[j] = date.ToString();
                            }
                            parameters.add(j, key, value[j]);
                        }
                    }
                }
            }
            return parameters;
        }

        public static Data Query(HttpRequest request)
        {
            Data parameters = new Data();
            int count = request.QueryString.Count;
            int pCount = 0;

            string key = null;
            string[] value = null;

            for (int i = 0; i < count; i++)
            {
                key = request.QueryString.GetKey(i);

                if (key == null)
                {
                    continue;
                }

                if (key.IndexOf("__") == 0)
                {
                    continue;
                }

                int keyIndex = key.LastIndexOf("$") + 1;

                if (keyIndex > 0)
                {
                    key = key.Substring(keyIndex, key.Length - keyIndex);
                }

                if (key.IndexOf("Btn") != -1)
                {
                    continue;
                }

                if (key.IndexOf("_ClientState") != -1)
                {
                    continue;
                }

                if (key.Length < 1)
                {
                    continue;
                }

                value = request.QueryString.GetValues(i);
                pCount = value.Length;
                if (value != null)
                {
                    if (key.Equals("now"))
                    {
                        parameters.Now = int.Parse(value[0]);
                    }

                    else
                    {
                        for (int j = 0; j < pCount; j++)
                        {
                            if (key.Equals("date")) //add time to date
                            {
                                DateTime date = DateTime.Parse(value[j]);
                                value[j] = date.ToString();
                            }
                            parameters.add(j, key, value[j]);
                        }
                    }
                }
            }
            return parameters;
        }
    }
}
