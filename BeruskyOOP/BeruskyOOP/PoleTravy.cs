using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BeruskyOOP
{
    class PoleTravy
    {
        public int width;
        public int height;
        public System.Data.DataTable data = new DataTable("Data");

        public PoleTravy(int width, int height)
        {
            this.width = width;
            this.height = height;

            DataColumn column;

            for (int i = 0; i < width; i++)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Column" + i;
                column.Unique = false;
                data.Columns.Add(column);

            }

            for (int i = 0; i < height; i++)
            {
                DataRow row;
                row = data.NewRow();
                for (int j = 0; j < width; j++) row[j] = " ";

                data.Rows.Add(row);
            }

            var rnd = new Random();
            for (int i = 0; i < height * width / 2; i++)
            {
                if (data.Rows[rnd.Next(0, height - 1)][rnd.Next(0, width)].ToString() != "T") data.Rows[rnd.Next(0, height - 1)][rnd.Next(0, width)] = "T";

            }

        }

        public void GrassGrows()
        {
            var rnd = new Random();
            for (int i = 0; i < (int)(height * width / 100); i++)
            {
                if (data.Rows[rnd.Next(0, width - 1)][rnd.Next(0, height - 1)].ToString() != "T") data.Rows[rnd.Next(0, width - 1)][rnd.Next(0, height - 1)] = "T";

            }
        }

        public void ShowMe()
        {
            string str;
            string horizontalLine = new String('_', width * 4);
            string emptyLine = "|" + new String(' ', width * 4 - 2) + "|";
            Console.WriteLine(horizontalLine + "\n" + emptyLine);
            for (int i = 0; i < height - 1; i++)
            {
                str = "| ";

                for (int j = 0; j < width - 1; j++) str = str + "  " + data.Rows[i][j].ToString().Substring(0, 1) + " ";

                str = str + " |" + "\n" + emptyLine;
                Console.WriteLine(str);
            }
            Console.WriteLine(horizontalLine);
        }

    }
}
