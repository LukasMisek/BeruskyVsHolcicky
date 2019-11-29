using System;
using System.Collections.Generic;
using System.Text;

namespace BeruskyOOP
{
    abstract class Bytost
    {
        public int posX;
        public int posY;

        public string nick;
        public int idBytosti;
        public int skore;

        public static int index = 0;

        public int zdravi;
        public int sila;
        public bool isAlive = true;

        public PoleTravy pole;

        public void Move()
        {
            if ( this.nick.Substring(0,1) != "T" && isAlive == true)
            {
                this.zdravi--;
                if (this.zdravi <= 0) Dead();

                else MoveIfAlive();
            }
        }

        public void Dead()
        {
            isAlive = false;
            if (pole.data.Rows[this.posY - 1][this.posX - 1].ToString() == this.nick) pole.data.Rows[this.posY - 1][this.posX - 1] = " ";
        }

        public void MoveIfAlive()
        {
            var rnd = new Random();

            int X = rnd.Next(1, 5);

            pole.data.Rows[this.posY - 1][this.posX - 1] = " ";

            if (X == 1 && this.posX < pole.height - 1) this.posX = this.posX + 1;

            else if (X == 2 && this.posX > 1) this.posX = this.posX - 1;

            else if (X == 3 && this.posY < pole.width - 1) this.posY = this.posY + 1;

            else if (X == 4 && this.posY > 1) this.posY = this.posY - 1;

            pole.data.Rows[this.posY - 1][this.posX - 1] = nick;

        }

        public void ShowMe()
        {
            pole.data.Rows[this.posY - 1][this.posX - 1] = nick;
        }
    }
}
