using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess
{
    public class Data
    {
        MySqlConnection connect = null;
        MySqlCommand cmd = null;
        MySqlDataReader read = null;
        DateTime datetime;

        protected int now = 0;
        protected string errorMsg = null;

        Dictionary<Int64, Dictionary<String, Object>> list = new Dictionary<Int64, Dictionary<String, Object>>();
        Dictionary<Int64, Dictionary<String, MySqlDbType>> type = new Dictionary<Int64, Dictionary<String, MySqlDbType>>();
        Dictionary<Int64, Dictionary<String, Object>> size = new Dictionary<Int64, Dictionary<String, Object>>();

        public void open()
        {
            string con = "SERVER=localhost;" +
                    "DATABASE=helpmifind;" +
                    "UID=root;" +
                    "PASSWORD=123;" +
                    "Allow User Variables = True";
            connect = new MySqlConnection(con);
            connect.Open();
        }

        public void close()
        {
            connect.Close();
            connect = null;
        }
        //==============================================MySQL Commands===========================================//
        public int insert(string query, Data data)
        {
            cmd = null;
            int result = 0;
            cmd = new MySqlCommand(query, connect);
            string key = null;
            MySqlDbType types = MySqlDbType.VarChar;
            int size = -1;
            Object[] keys = data.getKeys();
            object value = null;
            int length = keys.Length;

            if (keys != null)
            {
                for (int i = 0; i < length; i++)
                {
                    key = "@" + keys[i].ToString();
                    value = data.getValue(keys[i]);
                    size = data.getSize(keys[i]);
                    types = data.getType(keys[i]);

                    if (size > 0)
                    {
                        cmd.Parameters.Add(key, types);
                    }

                    else
                    {
                        cmd.Parameters.Add(key, types, size);
                    }

                    cmd.Parameters[key].Value = value;
                }
            }

            result = cmd.ExecuteNonQuery();
            cmd.BeginExecuteNonQuery();

            return result;

        }

        public Data select(String query, Data data)
        {
            cmd = null;
            Data result = new Data();
            cmd = new MySqlCommand(query, connect);
            String key = null;
            MySqlDbType types = MySqlDbType.VarChar;
            int size = -1;
            Object[] keys = data.getKeys();
            Object value = null;
            int now = 0;

            if (keys != null)
            {
                int length = keys.Length;

                for (int i = 0; i < length; i++)
                {
                    key = "@" + keys[i].ToString();
                    value = data.getValue(keys[i]);
                    size = data.getSize(keys[i]);
                    types = data.getType(keys[i]);

                    if (size > 0)
                    {
                        cmd.Parameters.Add(key, types);
                    }

                    else
                    {
                        cmd.Parameters.Add(key, types, size);
                    }

                    cmd.Parameters[key].Value = value;
                }
            }

            read = cmd.ExecuteReader();
            try
            {
                while (read.Read())
                {
                    int readCount = read.FieldCount;
                    for (int i = 0; i < readCount; i++)
                    {
                        result.add(now, read.GetName(i), read.GetValue(i));
                    }
                    ++now;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                errorMsg = e.Message;
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Parameters.Clear();
                }

                if (read != null)
                {
                    read.Close();
                }
            }
            return result;
        }

        public int delete(string query, Data data)
        {
            cmd = null;
            int result = 0;
            cmd = new MySqlCommand(query, connect);
            string key = null;
            MySqlDbType types = MySqlDbType.VarChar;
            int size = -1;
            Object[] keys = data.getKeys();
            object value = null;
            int length = keys.Length;

            if (keys != null)
            {
                for (int i = 0; i < length; i++)
                {
                    key = "@" + keys[i].ToString();
                    value = data.getValue(keys[i]);
                    size = data.getSize(keys[i]);
                    types = data.getType(keys[i]);

                    if (size > 0)
                    {
                        cmd.Parameters.Add(key, types);
                    }

                    else
                    {
                        cmd.Parameters.Add(key, types, size);
                    }

                    cmd.Parameters[key].Value = value;
                }
            }

            result = cmd.ExecuteNonQuery();
            cmd.BeginExecuteNonQuery();

            return result;

        }

        //==============================================END MYSQL Commands======================================//
        public int Now
        {
            get { return now; }
            set { now = value; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public String ErrorMsg
        {
            get { return errorMsg; }
            set { ErrorMsg = value; }
        }

        public void add(string key, object value)
        {
            add(0, key, value);
        }

        public void add(string key, string value)
        {
            add(0, key, value);
        }

        public void add(int index, string key, object value)
        {
            if (list.Count <= index)
            {
                index = list.Count;
                list.Add(index, new Dictionary<String, Object>());
                type.Add(index, new Dictionary<String, MySqlDbType>());
                size.Add(index, new Dictionary<String, Object>());
            }

            if (list[index].ContainsKey(key))
            {
                list[index].Remove(key);
                size[index].Remove(key);
                type[index].Remove(key);
            }

            list[index].Add(key, value);
            size[index].Add(key, sizeType(value));
            type[index].Add(key, valueType(value));
        }

        private void add(int index, string key, object value, int size)
        {

        }

        public int sizeType(Object value)
        {
            if (value is int || value is float || value is double || DateTime.TryParse(value.ToString(), out datetime))
            {
                return -1;
            }
            else
            {
                return value.ToString().Length;
            }

        }


        public MySqlDbType valueType(Object value)
        {
            if (value is int)
            {
                return MySqlDbType.Int64;
            }

            if (value is float)
            {
                return MySqlDbType.Float;
            }

            if (DateTime.TryParse(value.ToString(), out datetime))
            {
                return MySqlDbType.DateTime;
            }

            if (value is double)
            {
                return MySqlDbType.Double;
            }

            else
                return MySqlDbType.VarChar;
        }

        public Object[] getKeys()
        {
            return getKeys(0);
        }

        public Object[] getKeys(int index)
        {
            if (!list.ContainsKey(index)) return null;
            Dictionary<String, Object> temp = list[index];
            int count = list[index].Count;
            Object[] keys = new Object[count];
            int now = 0;
            foreach (var key in temp)
            {
                keys[now] = key.Key;
                ++now;
            }
            return keys;
        }

        public Object getValue(Object key)
        {
            return getValue(0, key);
        }

        public Object getValue(String key)
        {
            return getValue(0, key);
        }

        public Object getValue(int index, Object key)
        {
            return getValue(0, key.ToString());
        }

        public Object getValue(int index, int key)
        {
            return getValue(index, getKeys(index)[key].ToString());
        }

        public Object getValue(int index, String key)
        {
            if (!list.ContainsKey(index)) return null;
            Dictionary<String, Object> temp = list[index];
            if (!temp.ContainsKey(key)) return null;
            temp = list[index];
            return temp[key];
        }

        public int getSize(Object key)
        {
            return getSize(0, key);
        }

        public int getSize(int index, Object key)
        {
            return getSize(0, key.ToString());
        }

        public int getSize(int index, String key)
        {
            if (!size.ContainsKey(index)) return -1;
            Dictionary<String, Object> temp = size[index];
            if (!temp.ContainsKey(key)) return -1;
            temp = size[index];
            return int.Parse(temp[key].ToString());

        }

        public MySqlDbType getType(Object key)
        {
            return getType(0, key);
        }

        public MySqlDbType getType(int index, Object key)
        {
            return getType(0, key.ToString());
        }

        public MySqlDbType getType(int index, String key)
        {
            if (!type.ContainsKey(index)) return MySqlDbType.VarChar;
            Dictionary<String, MySqlDbType> temp = type[index];
            if (!temp.ContainsKey(key)) return MySqlDbType.VarChar;
            temp = type[index];
            return temp[key];
        }

        public DataTable Source
        {
            get
            {
                DataTable result = new DataTable();
                Object[] keys = this.getKeys();
                if (keys == null)
                {
                    return result;
                }

                if (keys.Length == 0)
                {
                    return result;
                }

                int length = keys.Length;

                for (int i = 0; i < length; i++)
                {
                    result.Columns.Add(keys[i].ToString(), typeof(String));
                }
                int count = list.Count;

                for (int i = 0; i < count; i++)
                {
                    DataRow row = result.NewRow();

                    for (int j = 0; j < length; j++)
                    {
                        row[keys[j].ToString()] = getValue(i, j);
                    }

                    result.Rows.Add(row);
                }

                return result;
            }

        }

        public Object get(Object key)
        {
            return get(0, key);
        }

        public Object get(string key)
        {
            return get(0, key);
        }

        public Object get(int index, int key)
        {
            return get(index, getKeys(index)[key].ToString());
        }

        public Object get(int index, Object key)
        {
            return get(index, key.ToString());
        }

        public Object get(int index, String key)
        {
            if (!list.ContainsKey(index)) return null;
            Dictionary<String, Object> temp = list[index];
            if (!temp.ContainsKey(key)) return null;
            temp = list[index];
            return temp[key];
        }

        public String getString(Object key)
        {
            object value = getValue(0, key);
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        public String getString(String key)
        {
            object value = getValue(0, key);
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        public void remove(int key)
        {
            list.Remove(key);
        }

        public void remove(Object key)
        {
            remove(0, key.ToString());
        }

        public void remove(String key)
        {
            remove(0, key);
        }

        public void remove(int index, Object key)
        {
            remove(0, key.ToString());
        }

        public void remove(int index, String key)
        {
            list[index].Remove(key);
        }


    }
}
