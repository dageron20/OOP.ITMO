using iniParser.exeptions;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using static iniParser.exeptions.iniExeptions;

namespace iniParser
{
    public class iniparser
    {
        private Hashtable pairsParameters = new Hashtable();
        private string pathToFile;
        private struct DataPairs
        {
            public string section;
            public string key;
        }
        public iniparser(string pathfile)
        {
            string strLine;
            string currentMain = null;
            string[] keyPair;
            pathToFile = pathfile;
            if (!File.Exists(pathToFile))
                throw new FileNotFoundException("Path not found " + pathfile);
            try
            {
                TextReader file = new StreamReader(pathToFile);
                var extension = Path.GetExtension(pathToFile); // получаем расширени файла
                if (extension != ".ini")
                {
                    throw new InvalidFormat("Error format"); // ошибка неверного расширение файла
                }
                strLine = file.ReadLine();
                while (strLine != null)
                {
                    strLine = strLine.Trim(); // удаляет все начальные и конечные символы пробела из текущей строки
                    /*if (strLine == "")
                    {
                        strLine = file.ReadLine();  Возможно бесмысленная конструкция из за того что мы в while и так проверяем не нулевую строку
                        continue;
                    }*/
                    if (strLine.StartsWith("[") && (!strLine.EndsWith("]"))) // проверка на название [Секции] (Случай если после секции идет комментарий)
                    {
                        strLine = Regex.Replace(strLine, @";.+$", string.Empty); // удаляем комментарий, если он находится в строке
                        currentMain = strLine.Substring(1, strLine.Length - 3); // считываем название
                    }
                    else
                    {
                        if (strLine.StartsWith("[") && (strLine.EndsWith("]")))
                        {
                            strLine = Regex.Replace(strLine, @";.+$", string.Empty); // удаляем комментарий, если он находится в строке (случай если строка состоит только из секции)
                            currentMain = strLine.Substring(1, strLine.Length - 2); // считываем название
                        }

                        if (strLine.StartsWith(";"))
                        {
                            // строка = коммент   
                            strLine = file.ReadLine();
                            continue;
                        }
                        strLine = strLine.Replace(" ", string.Empty); // удаляем пробелы 
                        keyPair = strLine.Split(new char[] { '=' }, 2); // разделяем строку на 2 подстроки разделенные знаком равно
                        DataPairs datapairs;
                        string value = null;
                        if (currentMain == null)
                        {
                            continue;
                        }
                        datapairs.section = currentMain;
                        datapairs.key = keyPair[0];
                        if (keyPair.Length > 1)
                        {
                            keyPair[1] = Regex.Replace(keyPair[1], @";.+$", string.Empty); // удаляем комментарий, если он находится в строке
                            value = keyPair[1];
                        }
                        if (pairsParameters[datapairs] != null)
                            ChangeParameter(datapairs.section, datapairs.key, value);
                        else
                            pairsParameters.Add(datapairs, value);
                    }
                    strLine = file.ReadLine();
                }
            }
            catch (iniExeptions ex)
            {
                throw ex;
            }
        }

        public string ReadData(string section, string setting)
        {
            DataPairs datapairs;
            datapairs.section = section;
            datapairs.key = setting;
            if (pairsParameters[datapairs] == null)
            {
                throw new InvalidParametr("Section or parametr not found");
            }
            return (string)pairsParameters[datapairs];
        }

        public void ChangeParameter(string section, string setting, string value)
        {
            DataPairs datapairs;
            datapairs.section = section;
            datapairs.key = setting;

            if (pairsParameters.ContainsKey(datapairs))
            {
                pairsParameters.Remove(datapairs);
                pairsParameters.Add(datapairs, value);
            }
        }

        public int TakeInt(string section, string setting)
        {
            DataPairs datapairs;
            datapairs.section = section;
            datapairs.key = setting;

            if (pairsParameters[datapairs] == null)
            {
                throw new InvalidParametr("Section or parametr not found");
            }
            string s = pairsParameters[datapairs].ToString();
            bool valid = int.TryParse(s, out int number);
            if (!valid)
                throw new InvalidParametr("Invalid format to Parse");
            return number;
        }
        public double TakeDouble(string section, string setting)
        {
            DataPairs datapairs;
            datapairs.section = section;
            datapairs.key = setting;
            if (pairsParameters[datapairs] == null)
            {
                throw new InvalidParametr("Section or parametr not found");
            }
            string s = pairsParameters[datapairs].ToString();
            bool valid = double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double number);
            if (!valid)
                throw new InvalidParametr("Invalid format to Parse");
            return number;
        }
    }
}