using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class filter
    {
        public static string gettextmark(string input)
        {
            string grade;
            if (input == "</t") return grade = " ";
            if (input == "Rút") return grade = "W";
            if (input == "Vắn") return grade = "F";
            if (input == null) return grade = "";
            double mark = double.Parse(input.Replace(",", "."));
            switch (mark)
            {
                case double n when (n >= 9.0):
                    grade = "A";
                    break;
                case double n when (n >= 8.0 && n <= 8.9):
                    grade = "B+";
                    break;
                case double n when (n >= 7.0 && n <= 7.9):
                    grade = "B";
                    break;
                case double n when (n >= 6.5 && n <= 6.9):
                    grade = "C+";
                    break;
                case double n when (n >= 5.5 && n <= 6.4):
                    grade = "C";
                    break;
                case double n when (n >= 5.0 && n <= 5.4):
                    grade = "D+";
                    break;
                case double n when (n >= 4.0 && n <= 4.9):
                    grade = "D";
                    break;
                case double n when (n < 4.0):
                    grade = "F";
                    break;
                default:
                    grade = "Invalid mark";
                    break;
            }
            return grade;
        }




        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            string result = "";
            int Start, End;
            int endl = strEnd.Length;
            int startl = strStart.Length;
            while (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = 0;
                End = 0;
                Start = strSource.IndexOf(strStart, 0) + startl;
                End = strSource.IndexOf(strEnd, Start);
                result += strSource.Substring(Start, End - Start);
                strSource = strSource.Remove(Start - startl, startl + endl + (End - Start));
                result += "-";
            }
            //      result = result.Remove(result.Length-1, 1);
            return result;
        }

        public static int getid(string strSource, studentSubjects[] subject, int num)
        {
            int Start;
            while (strSource.Contains("-"))

            {
                Start = strSource.IndexOf("-", 0);
                subject[num + 1].Id = strSource.Substring(Start - 5, 5);
                if (strSource.Length > 5)
                    strSource = strSource.Remove(Start - 5, 6);
                num++;
            }
            subject[0].Id = num.ToString();
            return num;
        }
        public static void gethk(string strSource, studentSubjects[] subjects)
        {
            string result;
            string id, strTrim2, strTrim3, mark;
            int Start, drl, markStart;
            int a = 1;
            int i = 0;
            int cou = 0;
            string strTrim = strSource.Replace("\t", "").Replace("\n", "").Replace("\r", "");
            while (strTrim.Contains("Học Kỳ 1") || strTrim.Contains("Học Kỳ 2") || strTrim.Contains("Học Kỳ Hè"))
            {
                if (strTrim.Contains("Học Kỳ 1"))
                {
                    cou++;
                    Start = strTrim.IndexOf("Học Kỳ 1", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);

                    result = strTrim.Substring(Start, 24);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Count = cou;
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);

                    }
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
                if (strTrim.Contains("Học Kỳ 2"))
                {
                    cou++;
                    Start = strTrim.IndexOf("Học Kỳ 2", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);
                    result = strTrim.Substring(Start, 24);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Count = cou;
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);

                    }
                    subjects[a].Count = cou;
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
                if (strTrim.Contains("Học Kỳ Hè"))
                {
                    cou++;
                    Start = strTrim.IndexOf("Học Kỳ Hè", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);

                    result = strTrim.Substring(Start, 25);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Count = cou;
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);
                    }
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
                subjects[0].Name = cou.ToString();
            }
        }
        public static string getuserid(string strSource)
        {
            string result, trim;
            int Start, end;
            string strTrim = strSource.Replace("\t", "").Replace("\n", "").Replace("\r", "");
            Start = strTrim.IndexOf("<strong>", 0);
            end = strTrim.IndexOf("</strong>", 0);
            result = "Họ và Tên: "+ strTrim.Substring(Start+8, end  - Start-8);
            trim = strTrim.Remove(Start, end - Start+8 );
            Start = trim.IndexOf("<strong>", 0);
            end = trim.IndexOf("</strong>", 0);
            result = result + "\nMã số sinh viên: " + trim.Substring(Start + 8, end - Start - 8);
            //trim = strTrim.Substring(Start, 24);
            Start = trim.IndexOf("<td><font face=\"Times new roman\" size=\"3\">", 0);
            end = trim.IndexOf("</font><font face=\"Times new roman\" size=\"3\"> (", 0);
            result = result + "\nNgành: " + trim.Substring(Start + 42, end - Start - 42);
            //trim = strTrim.Substring(Start, 24);
            Start = trim.IndexOf("</font><font face=\"Times new roman\" size=\"3\"> (", 0);
            end = trim.IndexOf(")</font></td>", 0);
            result = result + "\nLớp: " + trim.Substring(Start + 47, end - Start - 47);
            //trim = strTrim.Substring(Start, 24);

            // result = strTrim.Substring(Start, 24);
            return result;

        }
    }
}
